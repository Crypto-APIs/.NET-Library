using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class MetaCollection : MetaCollectionCount
    {
        [DeserializeAs(Name = "index")]
        public int Index { get; private set ; }

        [DeserializeAs(Name = "limit")]
        public int Limit { get; private set; }

        [DeserializeAs(Name = "results")]
        public int Results { get; private set; }
    }
}