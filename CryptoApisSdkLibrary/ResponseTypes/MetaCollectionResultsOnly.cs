using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes
{
    public class MetaCollectionResultsOnly : MetaCollectionCount
    {
        [DeserializeAs(Name = "results")]
        public int Results { get; protected set; }
    }
}