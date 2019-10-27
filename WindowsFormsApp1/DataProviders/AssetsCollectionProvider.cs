using CryptoApisLibrary;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;
using MorseCode.ITask;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace WindowsFormsApp1.DataProviders
{
    internal class AssetsCollectionProvider : BaseCollectionProvider<AssetsResponse>
    {
        public AssetsCollectionProvider(ICryptoManager manager)
            : base(manager)
        {
        }

        public override IEnumerable<object> Items()
        {
            return InternalItems()?.Result.Assets;
        }

        public override ITask<AssetsResponse> GetPartItemsAsync(int skip, int limit)
        {
            return InternalItems(skip, limit);
        }

        public override IEnumerable<string> Headers { get; } = new[] { "Name" };

        public override IEnumerable<string> ItemContent(object item)
        {
            return item is Asset asset
                ? new[] { asset.Name }
                : Enumerable.Empty<string>();
        }

        private ITask<AssetsResponse> InternalItems(int skip = 0, int limit = 50)
        {
            var task = Manager.Exchanges.Info.AssetsAsync(CancellationToken.None, skip, limit);
            return task.AsITask();
        }
    }
}