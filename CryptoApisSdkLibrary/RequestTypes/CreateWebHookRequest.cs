using Newtonsoft.Json;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal class CreateWebHookRequest
    {
        public CreateWebHookRequest(string @event, string url)
        {
            Event = @event;
            Url = url;
        }

        [JsonProperty(PropertyName = "event")]
        public string Event { get; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; }
    }

    internal class CreateConfirmedTransactionRequest : CreateWebHookRequest
    {
        public CreateConfirmedTransactionRequest(string @event, string url, int confirmationCount, string transactionHash)
            : base(@event, url)
        {
            ConfirmationCount = confirmationCount;
            TransactionHash = transactionHash;
        }

        [JsonProperty(PropertyName = "confirmations")]
        public int ConfirmationCount { get; }

        [JsonProperty(PropertyName = "transaction")]
        public string TransactionHash { get; }
    }

    internal class CreateAddressRequest : CreateWebHookRequest
    {
        public CreateAddressRequest(string @event, string url, string address)
            : base(@event, url)
        {
            Address = address;
        }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; }
    }
}