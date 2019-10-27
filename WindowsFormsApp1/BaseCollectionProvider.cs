using CryptoApisLibrary;
using CryptoApisLibrary.ResponseTypes;
using System.Collections.Generic;
using System.Threading.Tasks;
using MorseCode.ITask;

namespace WindowsFormsApp1
{
    internal abstract class BaseCollectionProvider<T> : ICollectionProvider<T> where T : ICollectionResponse
    //internal abstract class BaseCollectionProvider : ICollectionProvider<ICollectionResponse>
    {
        protected BaseCollectionProvider(ICryptoManager manager)
        {
            Manager = manager;
        }

        protected ICryptoManager Manager { get; }

        public abstract IEnumerable<object> Items();

        public abstract ITask<T> GetPartItemsAsync(int skip, int limit);
        //public abstract ITask<ICollectionResponse> GetPartItemsAsync(int skip, int limit);

        public abstract IEnumerable<string> Headers { get; }

        public abstract IEnumerable<string> ItemContent(object item);
    }
}