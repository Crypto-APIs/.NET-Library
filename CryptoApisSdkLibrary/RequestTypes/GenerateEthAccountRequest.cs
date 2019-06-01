using Newtonsoft.Json;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal class GenerateEthAccountRequest
    {
        public GenerateEthAccountRequest(string password)
        {
            Password = password;
        }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; }
    }
}