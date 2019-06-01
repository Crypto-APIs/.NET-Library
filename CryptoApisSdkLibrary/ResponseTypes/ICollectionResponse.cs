using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes
{
    public interface ICollectionResponse
    {
        string ErrorMessage { get; }
        MetaCollection Meta { get; }
        IEnumerable<object> Items { get; }
    }
}