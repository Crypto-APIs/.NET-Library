using Newtonsoft.Json;

namespace CryptoApisLibrary.RequestTypes
{
    internal class CreateXPubRequest
    {
        public CreateXPubRequest(string password)
        {
            Password = password;
        }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; }
    }
}