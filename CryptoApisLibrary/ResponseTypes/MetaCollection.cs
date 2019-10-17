using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes
{
    public class MetaCollection : MetaCollectionCount
    {
        [DeserializeAs(Name = "index")]
        public int Index { get; protected set; }

        [DeserializeAs(Name = "limit")]
        public int Limit { get; protected set; }

        [DeserializeAs(Name = "results")]
        public int Results { get; protected set; }
    }
}