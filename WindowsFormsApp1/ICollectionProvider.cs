using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoApisLibrary.ResponseTypes;
using MorseCode.ITask;

namespace WindowsFormsApp1
{
    interface ICollectionProvider<out T> where T: ICollectionResponse
    {
        IEnumerable<object> Items();
        ITask<T> GetPartItemsAsync(int skip, int limit);
        IEnumerable<string> Headers { get; }
        IEnumerable<string> ItemContent(object item);
    }
}