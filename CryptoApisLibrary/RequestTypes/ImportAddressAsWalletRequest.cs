using Newtonsoft.Json;

namespace CryptoApisLibrary.RequestTypes
{
    internal class ImportAddressAsWalletRequest
    {
        public ImportAddressAsWalletRequest(string walletName, string password, string privateKey, string address)
        {
            WalletName = walletName;
            Password = password;
            PrivateKey = privateKey;
            Address = address;
        }

        [JsonProperty(PropertyName = "walletName")]
        public string WalletName { get; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; }

        [JsonProperty(PropertyName = "privateKey")]
        public string PrivateKey { get; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; }
    }
}