using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CryptoApisLibrary;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;
using MorseCode.ITask;

namespace WindowsFormsApp1.DataProviders
{
    internal class HistoricalTradesByAssetPairCollectionProvider : BaseCollectionProvider<HistoricalTradesResponse>
    {
        public HistoricalTradesByAssetPairCollectionProvider(ICryptoManager manager,
            Asset baseAsset, Asset quoteAsset, DateTime? startDate, DateTime? endDate) : base(manager)
        {
            _baseAsset = baseAsset;
            _quoteAsset = quoteAsset;
            _startDate = startDate;
            _endDate = endDate;
        }

        public override IEnumerable<object> Items()
        {
            return InternalItems()?.Result.Trades;
        }

        public override ITask<HistoricalTradesResponse> GetPartItemsAsync(int skip, int limit)
        {
            return InternalItems(skip, limit);
        }

        public override IEnumerable<string> Headers { get; } = new[] { "EventTime", "Amount" };

        public override IEnumerable<string> ItemContent(object item)
        {
            return item is Trade trade
                ? new[] { trade.EventTime.ToString(), trade.Amount.ToString() }
                : Enumerable.Empty<string>();
        }

        private ITask<HistoricalTradesResponse> InternalItems(int skip = 0, int limit = 50)
        {
            Task<HistoricalTradesResponse> task = null;
            if (_startDate == null)
            {
                task = Manager.Exchanges.Trades.HistoricalAsync(
                    CancellationToken.None, _baseAsset, _quoteAsset, skip, limit);
            }
            else if (_startDate != null && _endDate == null)
            {
                task = Manager.Exchanges.Trades.HistoricalAsync(
                    CancellationToken.None, _baseAsset, _quoteAsset, _startDate.Value, skip, limit);
            }
            else if (_startDate != null && _endDate != null)
            {
                task = Manager.Exchanges.Trades.HistoricalAsync(
                    CancellationToken.None, _baseAsset, _quoteAsset, _startDate.Value, _endDate.Value, skip, limit);
            }

            return task.AsITask();
        }

        private readonly Asset _baseAsset;
        private readonly Asset _quoteAsset;
        private readonly DateTime? _startDate;
        private readonly DateTime? _endDate;
    }
}