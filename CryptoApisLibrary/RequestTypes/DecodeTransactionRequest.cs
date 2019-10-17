using Newtonsoft.Json;

namespace CryptoApisLibrary.RequestTypes
{
    internal class DecodeTransactionRequest
    {
        public DecodeTransactionRequest(string hexEncodedInfo)
        {
            HexEncodedInfo = hexEncodedInfo;
        }

        [JsonProperty(PropertyName = "hex")]
        public string HexEncodedInfo { get; }
    }
}