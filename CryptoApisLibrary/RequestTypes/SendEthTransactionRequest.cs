using Newtonsoft.Json;

namespace CryptoApisLibrary.RequestTypes
{
    internal class SendEthTransactionRequest
    {
        public SendEthTransactionRequest(string fromAddress, string toAddress, double value)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
            Value = value;
        }

        [JsonProperty(PropertyName = "fromAddress")]
        public string FromAddress { get; }

        [JsonProperty(PropertyName = "toAddress")]
        public string ToAddress { get; }

        [JsonProperty(PropertyName = "value")]
        public double Value { get; }
    }
}