using Newtonsoft.Json;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal class DeployContractRequest
    {
        public DeployContractRequest(string privateKey, string fromAddress, double gasPrice, double gasLimit, string byteCode)
        {
            PrivateKey = privateKey;
            FromAddress = fromAddress;
            GasPrice = gasPrice;
            GasLimit = gasLimit;
            ByteCode = byteCode;
        }

        [JsonProperty(PropertyName = "fromAddress")]
        public string FromAddress { get; }

        [JsonProperty(PropertyName = "privateKey")]
        public string PrivateKey { get; }

        [JsonProperty(PropertyName = "gasPrice")]
        public double GasPrice { get; }

        [JsonProperty(PropertyName = "gasLimit")]
        public double GasLimit { get; }

        [JsonProperty(PropertyName = "byteCode")]
        public string ByteCode { get; }
    }
}