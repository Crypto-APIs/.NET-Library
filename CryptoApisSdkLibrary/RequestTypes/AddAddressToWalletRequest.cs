using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal class AddAddressToWalletRequest
    {
        public AddAddressToWalletRequest(IEnumerable<string> addresses)
        {
            Addresses.AddRange(addresses);
        }

        [JsonProperty(PropertyName = "addresses")]
        public List<string> Addresses { get; } = new List<string>();
    }
}