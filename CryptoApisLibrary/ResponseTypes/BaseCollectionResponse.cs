using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes
{
    public abstract class BaseCollectionResponse : BaseMetaCollectionResponse, ICollectionResponse
    {
        IEnumerable<object> ICollectionResponse.Items => GetItems;

        protected abstract IEnumerable<object> GetItems { get; }
    }
}