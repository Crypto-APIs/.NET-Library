using Newtonsoft.Json;

namespace CryptoApisLibrary.RequestTypes
{
    internal class CreateBtcPaymentRequest
    {
        public CreateBtcPaymentRequest(string fromAddress, string toAddress, string callbackUrl, string wallet,
            string password, int confirmations, double? fee = null)
        {
            From = fromAddress;
            To = toAddress;
            Callback = callbackUrl;
            Wallet = wallet;
            Password = password;
            Confirmations = confirmations;
            Fee = fee;
        }

        [JsonProperty(PropertyName = "from")]
        public string From { get; }

        [JsonProperty(PropertyName = "to")]
        public string To { get; }

        [JsonProperty(PropertyName = "callback")]
        public string Callback { get; }

        [JsonProperty(PropertyName = "wallet")]
        public string Wallet { get; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; }

        [JsonProperty(PropertyName = "confirmations")]
        public int Confirmations { get; }

        [JsonProperty(PropertyName = "fee")]
        public double? Fee { get; }
    }
}