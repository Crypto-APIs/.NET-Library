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
    internal class SymbolsInExchangeCollectionProvider : BaseCollectionProvider<ExchangesAssetsResponse>
    {
        public SymbolsInExchangeCollectionProvider(ICryptoManager manager, Exchange exchange)
            : base(manager)
        {
            _exchange = exchange;
        }

        public override IEnumerable<object> Items()
        {
            return InternalItems()?.Result.Infos;
        }

        public override ITask<ExchangesAssetsResponse> GetPartItemsAsync(int skip, int limit)
        {
            return InternalItems(skip, limit);
        }

        public override IEnumerable<string> Headers { get; } = new[] { "exchangeSymbol" };

        public override IEnumerable<string> ItemContent(object item)
        {
            return item is ExchangeAssets exchange
                ? new[] { exchange.ExchangeSymbol }
                : Enumerable.Empty<string>();
        }

        private ITask<ExchangesAssetsResponse> InternalItems(int skip = 0, int limit = 50)
        {
            Task<ExchangesAssetsResponse> task = Manager.Exchanges.Info.SymbolsInExchangeAsync(
                CancellationToken.None, _exchange, skip, limit);

            return task.AsITask();
        }

        private readonly Exchange _exchange;
    }
}