using Newtonsoft.Json;

namespace CryptoApisLibrary.RequestTypes
{
    internal class RefundTransactionRequest
    {
        public RefundTransactionRequest(string transactionId, string wif, double? fee)
        {
            TransactionId = transactionId;
            Wif = wif;
            Fee = fee;
        }

        [JsonProperty(PropertyName = "txid")]
        public string TransactionId { get; }

        [JsonProperty(PropertyName = "wif")]
        public string Wif { get; }

        [JsonProperty(PropertyName = "fee")]
        public double? Fee { get; }
    }

    internal abstract class RefundTransactionUsingRequest
    {
        protected RefundTransactionUsingRequest(string transactionHash, double? gasPrice)
        {
            TransactionHash = transactionHash;
            GasPrice = gasPrice;
        }

        [JsonProperty(PropertyName = "txHash")]
        public string TransactionHash { get; }

        [JsonProperty(PropertyName = "gasPrice")]
        public double? GasPrice { get; }
    }

    internal class RefundTransactionUsingPrivateKeyRequest : RefundTransactionUsingRequest
    {
        public RefundTransactionUsingPrivateKeyRequest(string transactionHash, string privateKey, double? gasPrice)
            : base(transactionHash, gasPrice)
        {
            PrivateKey = privateKey;
        }

        [JsonProperty(PropertyName = "privateKey")]
        public string PrivateKey { get; }
    }

    internal class RefundTransactionUsingPasswordRequest : RefundTransactionUsingRequest
    {
        public RefundTransactionUsingPasswordRequest(string transactionHash, string password, double? gasPrice)
            : base(transactionHash, gasPrice)
        {
            Password = password;
        }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; }
    }
}