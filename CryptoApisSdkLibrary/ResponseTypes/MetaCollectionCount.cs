using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes
{
    public class MetaCollectionCount
    {
        [DeserializeAs(Name = "totalCount")]
        public int Count { get; protected set; }
    }
}