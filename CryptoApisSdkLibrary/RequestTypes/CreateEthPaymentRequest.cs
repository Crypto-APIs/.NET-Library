using Newtonsoft.Json;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal abstract class CreateEthPaymentRequest
    {
        protected CreateEthPaymentRequest(string fromAddress, string toAddress, string callbackUrl,
            int confirmations, double? gasPrice = null, double? gasLimit = null)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
            Callback = callbackUrl;
            Confirmations = confirmations;
            GasPrice = gasPrice;
            GasLimit = gasLimit;
        }

        [JsonProperty(PropertyName = "from")]
        public string FromAddress { get; }

        [JsonProperty(PropertyName = "to")]
        public string ToAddress { get; }

        [JsonProperty(PropertyName = "callback")]
        public string Callback { get; }

        [JsonProperty(PropertyName = "confirmations")]
        public int Confirmations { get; }

        [JsonProperty(PropertyName = "gasPrice")]
        public double? GasPrice { get; }

        [JsonProperty(PropertyName = "gasLimit")]
        public double? GasLimit { get; }
    }

    internal class CreateEthPaymentPasswordRequest : CreateEthPaymentRequest
    {
        public CreateEthPaymentPasswordRequest(string fromAddress, string toAddress, string callbackUrl, string password,
            int confirmations, double? gasPrice = null, double? gasLimit = null)
            : base(fromAddress, toAddress, callbackUrl, confirmations, gasPrice, gasLimit)
        {
            Password = password;
        }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; }
    }

    internal class CreateEthPaymentPrivateKeyRequest : CreateEthPaymentRequest
    {
        public CreateEthPaymentPrivateKeyRequest(string fromAddress, string toAddress, string callbackUrl, string privateKey,
            int confirmations, double? gasPrice = null, double? gasLimit = null)
            : base(fromAddress, toAddress, callbackUrl, confirmations, gasPrice, gasLimit)
        {
            PrivateKey = privateKey;
        }

        [JsonProperty(PropertyName = "privateKey")]
        public string PrivateKey { get; }
    }
}