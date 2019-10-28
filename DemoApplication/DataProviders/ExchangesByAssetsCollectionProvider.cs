using CryptoApisLibrary;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;
using MorseCode.ITask;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WindowsFormsApp1.DataProviders
{
    internal class ExchangesByAssetsCollectionProvider : BaseCollectionProvider<ExchangesSupportingAssetResponse>
    {
        public ExchangesByAssetsCollectionProvider(ICryptoManager manager, Asset baseAsset)
            : base(manager)
        {
            _baseAsset = baseAsset;
        }

        public override IEnumerable<object> Items()
        {
            return InternalItems()?.Result.Infos;
        }

        public override ITask<ExchangesSupportingAssetResponse> GetPartItemsAsync(int skip, int limit)
        {
            return InternalItems(skip, limit);
        }

        public override IEnumerable<string> Headers { get; } = new[] { "pairsAsBaseCount", "pairsAsQuoteCount" };

        public override IEnumerable<string> ItemContent(object item)
        {
            return item is ExchangeSupportingAsset exchange
                ? new[] { exchange.PairsAsBaseCount.ToString(), exchange.PairsAsQuoteCount.ToString() }
                : Enumerable.Empty<string>();
        }

        private ITask<ExchangesSupportingAssetResponse> InternalItems(int skip = 0, int limit = 50)
        {
            var task = Manager.Exchanges.Info.ExchangesSupportingAssetAsync(
                CancellationToken.None, _baseAsset, skip, limit);

            return task.AsITask();
        }

        private readonly Asset _baseAsset;
    }
}