using Newtonsoft.Json;

namespace CryptoApisSdkLibrary.RequestTypes
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