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
    internal class LatestDataByExchangeAssetPairCollectionProvider : BaseCollectionProvider<LatestTradesResponse>
    {
        public LatestDataByExchangeAssetPairCollectionProvider(ICryptoManager manager, Exchange exchange, Asset baseAsset, Asset quoteAsset)
            : base(manager)
        {
            _exchange = exchange;
            _baseAsset = baseAsset;
            _quoteAsset = quoteAsset;
        }

        public override IEnumerable<object> Items()
        {
            return InternalItems()?.Result.Trades;
        }

        public override ITask<LatestTradesResponse> GetPartItemsAsync(int skip, int limit)
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

        private ITask<LatestTradesResponse> InternalItems(int skip = 0, int limit = 50)
        {
            Task<LatestTradesResponse> task = null;
            task = Manager.Exchanges.Trades.LatestAsync(
                CancellationToken.None, _exchange, _baseAsset, _quoteAsset, skip, limit);

            return task.AsITask();
        }

        private readonly Exchange _exchange;
        private readonly Asset _baseAsset;
        private readonly Asset _quoteAsset;
    }
}