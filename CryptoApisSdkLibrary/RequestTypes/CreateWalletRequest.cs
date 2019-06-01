using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal class CreateWalletRequest
    {
        public CreateWalletRequest(string walletName, IEnumerable<string> addresses)
        {
            WalletName1 = walletName;
            Addresses.AddRange(addresses);
        }

        [JsonProperty(PropertyName = "walletName")]
        public string WalletName1 { get; }

        [JsonProperty(PropertyName = "addresses")]
        public List<string> Addresses { get; } = new List<string>();
    }
}