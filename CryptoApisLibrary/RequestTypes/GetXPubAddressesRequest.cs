using Newtonsoft.Json;

namespace CryptoApisLibrary.RequestTypes
{
    internal class GetXPubAddressesRequest
    {
        public GetXPubAddressesRequest(string xpub, int startIndex, int finishIndex)
        {
            Xpub = xpub;
            StartIndex = startIndex;
            FinishIndex = finishIndex;
        }

        [JsonProperty(PropertyName = "xpub")]
        public string Xpub { get; }

        [JsonProperty(PropertyName = "from")]
        public int StartIndex { get; }

        [JsonProperty(PropertyName = "to")]
        public int FinishIndex { get; }
    }
}