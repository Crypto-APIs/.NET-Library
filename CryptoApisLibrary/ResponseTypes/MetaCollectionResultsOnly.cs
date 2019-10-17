using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes
{
    public class MetaCollectionResultsOnly : MetaCollectionCount
    {
        [DeserializeAs(Name = "results")]
        public int Results { get; protected set; }
    }
}