using Newtonsoft.Json;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal abstract class CreateEthTransactionRequest
    {
        protected CreateEthTransactionRequest(string fromAddress, string toAddress)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
        }

        [JsonProperty(PropertyName = "fromAddress")]
        public string FromAddress { get; }

        [JsonProperty(PropertyName = "toAddress")]
        public string ToAddress { get; }
    }

    internal class CreateEthTransactionAllAmountUsingPasswordRequest : CreateEthTransactionRequest
    {
        public CreateEthTransactionAllAmountUsingPasswordRequest(string fromAddress, string toAddress, string password)
            : base(fromAddress, toAddress)
        {
            Password = password;
        }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; }
    }

    internal class CreateEthTransactionAllAmountUsingPrivateKeyRequest : CreateEthTransactionRequest
    {
        public CreateEthTransactionAllAmountUsingPrivateKeyRequest(string fromAddress, string toAddress, string privateKey)
            : base(fromAddress, toAddress)
        {
            PrivateKey = privateKey;
        }

        [JsonProperty(PropertyName = "privateKey")]
        public string PrivateKey { get; }
    }

    internal class CreateEthTransactionUsingPasswordRequest : CreateEthTransactionRequest
    {
        public CreateEthTransactionUsingPasswordRequest(string fromAddress, string toAddress, double value, string password)
            : base(fromAddress, toAddress)
        {
            Value = value;
            Password = password;
        }

        [JsonProperty(PropertyName = "value")]
        public double Value { get; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; }
    }

    internal class CreateEthTransactionUsingPasswordAndGasRequest : CreateEthTransactionUsingPasswordRequest
    {
        public CreateEthTransactionUsingPasswordAndGasRequest(
            string fromAddress, string toAddress, double value, string password, double gasPrice, double gasLimit)
            : base(fromAddress, toAddress, value, password)
        {
            GasPrice = gasPrice;
            GasLimit = gasLimit;
        }

        [JsonProperty(PropertyName = "gasPrice")]
        public double GasPrice { get; }

        [JsonProperty(PropertyName = "gasLimit")]
        public double GasLimit { get; }
    }

    internal class CreateEthTransactionUsingPrivateKeyRequest : CreateEthTransactionRequest
    {
        public CreateEthTransactionUsingPrivateKeyRequest(string fromAddress, string toAddress, double value, string privateKey)
            : base(fromAddress, toAddress)
        {
            Value = value;
            PrivateKey = privateKey;
        }

        [JsonProperty(PropertyName = "value")]
        public double Value { get; }

        [JsonProperty(PropertyName = "privateKey")]
        public string PrivateKey { get; }
    }

    internal class CreateEthTransactionUsingPrivateKeyAndGasRequest : CreateEthTransactionUsingPrivateKeyRequest
    {
        public CreateEthTransactionUsingPrivateKeyAndGasRequest(
            string fromAddress, string toAddress, double value, string privateKey, double gasPrice, double gasLimit)
            : base(fromAddress, toAddress, value, privateKey)
        {
            GasPrice = gasPrice;
            GasLimit = gasLimit;
        }

        [JsonProperty(PropertyName = "gasPrice")]
        public double GasPrice { get; }

        [JsonProperty(PropertyName = "gasLimit")]
        public double GasLimit { get; }
    }
}