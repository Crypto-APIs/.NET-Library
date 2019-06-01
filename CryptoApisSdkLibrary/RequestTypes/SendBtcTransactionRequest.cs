using Newtonsoft.Json;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal class SendBtcTransactionRequest
    {
        public SendBtcTransactionRequest(string hexEncodedInfo)
        {
            HexEncodedInfo = hexEncodedInfo;
        }

        [JsonProperty(PropertyName = "hex")]
        public string HexEncodedInfo { get; }
    }
}