using Newtonsoft.Json;

namespace CryptoApisLibrary.RequestTypes
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