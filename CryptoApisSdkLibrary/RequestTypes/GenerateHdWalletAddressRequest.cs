using Newtonsoft.Json;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal class GenerateHdWalletAddressRequest
    {
        public GenerateHdWalletAddressRequest(int addressCount, string encryptedPassword)
        {
            AddressCount = addressCount;
            Password = encryptedPassword;
        }

        [JsonProperty(PropertyName = "addressCount")]
        public int AddressCount { get; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; }
    }
}