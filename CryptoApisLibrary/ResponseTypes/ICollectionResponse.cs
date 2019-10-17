using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes
{
    public interface ICollectionResponse : IResponse
    {
        MetaCollection Meta { get; }
        IEnumerable<object> Items { get; }
    }
}