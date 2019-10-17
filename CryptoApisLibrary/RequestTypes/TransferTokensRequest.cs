using Newtonsoft.Json;

namespace CryptoApisLibrary.RequestTypes
{
    internal abstract class TransferTokensRequest
    {
        protected TransferTokensRequest(string fromAddress, string toAddress, string contract,
            double gasPrice, double gasLimit, double amount)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
            Contract = contract;
            GasPrice = gasPrice;
            GasLimit = gasLimit;
            Amount = amount;
        }

        [JsonProperty(PropertyName = "fromAddress")]
        public string FromAddress { get; }

        [JsonProperty(PropertyName = "toAddress")]
        public string ToAddress { get; }

        [JsonProperty(PropertyName = "contract")]
        public string Contract { get; }

        [JsonProperty(PropertyName = "gasPrice")]
        public double GasPrice { get; }

        [JsonProperty(PropertyName = "gasLimit")]
        public double GasLimit { get; }

        [JsonProperty(PropertyName = "token")]
        public double Amount { get; }
    }

    internal class TransferTokensWithPasswordRequest : TransferTokensRequest
    {
        public TransferTokensWithPasswordRequest(string fromAddress, string toAddress, string contract,
            double gasPrice, double gasLimit, double amount, string password)
            : base(fromAddress, toAddress, contract, gasPrice, gasLimit, amount)
        {
            Password = password;
        }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; }
    }

    internal class TransferTokensWithPrivateKeyRequest : TransferTokensRequest
    {
        public TransferTokensWithPrivateKeyRequest(string fromAddress, string toAddress, string contract,
            double gasPrice, double gasLimit, double amount, string privateKey)
            : base(fromAddress, toAddress, contract, gasPrice, gasLimit, amount)
        {
            PrivateKey = privateKey;
        }

        [JsonProperty(PropertyName = "privateKey")]
        public string PrivateKey { get; }
    }
}