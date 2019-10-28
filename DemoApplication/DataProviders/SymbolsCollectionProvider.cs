using CryptoApisLibrary;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;
using MorseCode.ITask;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WindowsFormsApp1.DataProviders
{
    internal class SymbolsCollectionProvider : BaseCollectionProvider<SymbolsResponse>
    {
        public SymbolsCollectionProvider(ICryptoManager manager)
            : base(manager)
        {
        }

        public override IEnumerable<object> Items()
        {
            return InternalItems()?.Result.Symbols;
        }

        public override ITask<SymbolsResponse> GetPartItemsAsync(int skip, int limit)
        {
            return InternalItems(skip, limit);
        }

        public override IEnumerable<string> Headers { get; } = new[] { "Name" };

        public override IEnumerable<string> ItemContent(object item)
        {
            return item is Symbol symbol
                ? new[] { symbol.Name }
                : Enumerable.Empty<string>();
        }

        private ITask<SymbolsResponse> InternalItems(int skip = 0, int limit = 50)
        {
            var task = Manager.Exchanges.Info.SymbolsAsync(CancellationToken.None, skip, limit);
            return task.AsITask();
        }
    }
}