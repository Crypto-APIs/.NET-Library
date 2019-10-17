using Newtonsoft.Json;

namespace CryptoApisLibrary.RequestTypes
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