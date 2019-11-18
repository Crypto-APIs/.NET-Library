using Newtonsoft.Json;

namespace CryptoApisLibrary.RequestTypes
{
    internal class CreateAccountRequest
    {
        public CreateAccountRequest(string exchangeId, string apiKey, string secret, string password, string uid)
        {
            ExchangeId = exchangeId;
            ApiKey = apiKey;
            Secret = secret;
            Password = password;
            Uid = uid;
        }

        [JsonProperty(PropertyName = "exchangeId")]
        public string ExchangeId { get; }

        [JsonProperty(PropertyName = "exchangeApiKey")]
        public string ApiKey { get; }

        [JsonProperty(PropertyName = "exchangeSecret")]
        public string Secret { get; }

        [JsonProperty(PropertyName = "exchangePassword")]
        public string Password { get; }

        [JsonProperty(PropertyName = "exchangeUid")]
        public string Uid { get; }

    }
}