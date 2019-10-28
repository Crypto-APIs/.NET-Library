using System;
using CryptoApisLibrary;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;
using MorseCode.ITask;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DataProviders
{
    internal class ExchangesByPairCollectionProvider : BaseCollectionProvider<ExchangesAssetsResponse>
    {
        public ExchangesByPairCollectionProvider(ICryptoManager manager, Asset asset1, Asset asset2, IEnumerable<ExchangeMeta> exchanges)
            : base(manager)
        {
            _asset1 = asset1;
            _asset2 = asset2;
            _exchanges = exchanges;
        }

        public override IEnumerable<object> Items()
        {
            return InternalItems()?.Result.Infos;
        }

        public override ITask<ExchangesAssetsResponse> GetPartItemsAsync(int skip, int limit)
        {
            return InternalItems(skip, limit);
        }

        public override IEnumerable<string> Headers { get; } = new[] { "exchangeId", "exchangeSymbol" };

        public override IEnumerable<string> ItemContent(object item)
        {
            return item is ExchangeAssets exchangeRate
                ? new[] { _exchanges.FirstOrDefault(e =>
                    string.Equals(e.Id, exchangeRate.ExchangeId, StringComparison.OrdinalIgnoreCase))?.Name.ToString(), 
                    exchangeRate.ExchangeSymbol }
                : Enumerable.Empty<string>();
        }

        private ITask<ExchangesAssetsResponse> InternalItems(int skip = 0, int limit = 50)
        {
            Task<ExchangesAssetsResponse> task = Manager.Exchanges.Info.ExchangesSupportingPairsAsync(
                CancellationToken.None, _asset1, _asset2, skip, limit);

            return task.AsITask();
        }

        private readonly Asset _asset1;
        private readonly Asset _asset2;
        private readonly IEnumerable<ExchangeMeta> _exchanges;
    }
}