using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes
{
    public abstract class BaseCollectionResponse : BaseMetaCollectionResponse, ICollectionResponse
    {
        IEnumerable<object> ICollectionResponse.Items => GetItems;

        protected abstract IEnumerable<object> GetItems { get; }
    }
}