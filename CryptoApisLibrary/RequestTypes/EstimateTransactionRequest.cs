using Newtonsoft.Json;

namespace CryptoApisLibrary.RequestTypes
{
    internal class EstimateTransactionRequest
    {
        public EstimateTransactionRequest(string fromAddress, string toAddress, double value, string data)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
            Value = value;
            Data = data;
        }

        [JsonProperty(PropertyName = "fromAddress")]
        public string FromAddress { get; }

        [JsonProperty(PropertyName = "toAddress")]
        public string ToAddress { get; }

        [JsonProperty(PropertyName = "value")]
        public double Value { get; }

        [JsonProperty(PropertyName = "data")]
        public string Data { get; }
    }
}