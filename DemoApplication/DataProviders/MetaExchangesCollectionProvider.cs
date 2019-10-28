using CryptoApisLibrary;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;
using MorseCode.ITask;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WindowsFormsApp1.DataProviders
{
    internal class MetaExchangesCollectionProvider : BaseCollectionProvider<ExchangesMetaResponse>
    {
        public MetaExchangesCollectionProvider(ICryptoManager manager)
            : base(manager)
        {
        }

        public override IEnumerable<object> Items()
        {
            return InternalItems()?.Result.Exchanges;
        }

        public override ITask<ExchangesMetaResponse> GetPartItemsAsync(int skip, int limit)
        {
            return InternalItems(skip, limit);
        }

        public override IEnumerable<string> Headers { get; } = new[] { "Name", "Markets" };

        public override IEnumerable<string> ItemContent(object item)
        {
            return item is ExchangeMeta exchange
                ? new[] { exchange.Name, exchange.Markets.ToString() }
                : Enumerable.Empty<string>();
        }

        private ITask<ExchangesMetaResponse> InternalItems(int skip = 0, int limit = 50)
        {
            var task = Manager.Exchanges.Info.ExchangesMetaAsync(CancellationToken.None, skip, limit);
            return task.AsITask();
        }
    }
}