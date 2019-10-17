using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes
{
    public class MetaCollectionCount
    {
        [DeserializeAs(Name = "totalCount")]
        public int Count { get; protected set; }
    }
}