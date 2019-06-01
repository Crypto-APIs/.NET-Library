using Newtonsoft.Json;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal class CreateHdWalletRequest
    {
        public CreateHdWalletRequest(string walletName, string password, int addressCount)
        {
            WalletName = walletName;
            Password = password;
            AddressCount = addressCount;
        }

        [JsonProperty(PropertyName = "walletName")]
        public string WalletName { get; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; }

        [JsonProperty(PropertyName = "addressCount")]
        public int AddressCount { get; }
    }
}