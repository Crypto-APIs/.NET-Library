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
    internal class AllCurrentRatesCollectionProvider : BaseCollectionProvider<ExchangeRatesResponse>
    {
        public AllCurrentRatesCollectionProvider(ICryptoManager manager, Asset baseAsset, DateTime? timeStamp)
            : base(manager)
        {
            _baseAsset = baseAsset;
            _timeStamp = timeStamp;
        }

        public override IEnumerable<object> Items()
        {
            return InternalItems()?.Result.Rates;
        }

        public override ITask<ExchangeRatesResponse> GetPartItemsAsync(int skip, int limit)
        {
            return InternalItems(skip, limit);
        }

        public override IEnumerable<string> Headers { get; } = new[] { "Timestamp", "MedianPrice" };

        public override IEnumerable<string> ItemContent(object item)
        {
            return item is ExchangeRate exchangeRate
                ? new[] { exchangeRate.Timestamp.ToString(), exchangeRate.MedianPrice.ToString() }
                : Enumerable.Empty<string>();
        }

        private ITask<ExchangeRatesResponse> InternalItems(int skip = 0, int limit = 50)
        {
            Task<ExchangeRatesResponse> task;
            if (_timeStamp == null)
            {
                task = Manager.Exchanges.Rates.GetAnyAsync(
                    CancellationToken.None, _baseAsset, skip, limit);
            }
            else
            {
                task = Manager.Exchanges.Rates.GetAnyAsync(
                    CancellationToken.None, _baseAsset, _timeStamp.Value, skip, limit);
            }

            return task.AsITask();
        }

        private readonly Asset _baseAsset;
        private readonly DateTime? _timeStamp;
    }
}