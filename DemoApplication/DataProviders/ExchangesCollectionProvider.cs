using CryptoApisLibrary;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;
using MorseCode.ITask;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WindowsFormsApp1.DataProviders
{
    internal class ExchangesCollectionProvider : BaseCollectionProvider<ExchangesResponse>
    {
        public ExchangesCollectionProvider(ICryptoManager manager)
            : base(manager)
        {
        }

        public override IEnumerable<object> Items()
        {
            return InternalItems()?.Result.Exchanges;
        }

        public override ITask<ExchangesResponse> GetPartItemsAsync(int skip, int limit)
        {
            return InternalItems(skip, limit);
        }

        public override IEnumerable<string> Headers { get; } = new[] { "Name" };

        public override IEnumerable<string> ItemContent(object item)
        {
            return item is Exchange exchange
                ? new[] { exchange.Name }
                : Enumerable.Empty<string>();
        }

        private ITask<ExchangesResponse> InternalItems(int skip = 0, int limit = 50)
        {
            var task = Manager.Exchanges.Info.ExchangesAsync(CancellationToken.None, skip, limit);
            return task.AsITask();
        }
    }
}