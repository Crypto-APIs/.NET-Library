using CryptoApisLibrary;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;
using MorseCode.ITask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DataProviders
{
    internal class AllCurrentRatesByExchangeCollectionProvider : BaseCollectionProvider<CurrentRatesInExchangeResponse>
    {
        public AllCurrentRatesByExchangeCollectionProvider(
            ICryptoManager manager, Asset baseAsset, Exchange exchange, DateTime? timeStamp)
            : base(manager)
        {
            _baseAsset = baseAsset;
            _exchange = exchange;
            _timeStamp = timeStamp;
        }

        public override IEnumerable<object> Items()
        {
            return InternalItems()?.Result.Rates;
        }

        public override ITask<CurrentRatesInExchangeResponse> GetPartItemsAsync(int skip, int limit)
        {
            return InternalItems(skip, limit);
        }

        public override IEnumerable<string> Headers { get; } = new[] { "Timestamp", "MedianPrice" };

        public override IEnumerable<string> ItemContent(object item)
        {
            return item is ExchangeRateInSpecificExchange exchangeRate
                ? new[] { exchangeRate.Timestamp.ToString(), exchangeRate.MedianPrice.ToString() }
                : Enumerable.Empty<string>();
        }

        private ITask<CurrentRatesInExchangeResponse> InternalItems(int skip = 0, int limit = 50)
        {
            Task<CurrentRatesInExchangeResponse> task;
            if (_timeStamp == null)
            {
                task = Manager.Exchanges.Rates.GetAnyAsync(
                    CancellationToken.None, _baseAsset, _exchange, skip, limit);
            }
            else
            {
                task = Manager.Exchanges.Rates.GetAnyAsync(
                    CancellationToken.None, _baseAsset, _exchange, _timeStamp.Value, skip, limit);
            }

            return task.AsITask();
        }

        private readonly Asset _baseAsset;
        private readonly DateTime? _timeStamp;
        private readonly Exchange _exchange;
    }
}