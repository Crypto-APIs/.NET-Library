using Newtonsoft.Json;

namespace CryptoApisLibrary.RequestTypes
{
    internal class PushTransactionRequest
    {
        public PushTransactionRequest(string hexEncodedInfo)
        {
            HexEncodedInfo = hexEncodedInfo;
        }

        [JsonProperty(PropertyName = "hex")]
        public string HexEncodedInfo { get; }
    }
}