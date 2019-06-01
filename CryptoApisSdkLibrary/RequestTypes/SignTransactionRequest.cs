using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal class SignTransactionRequest
    {
        public SignTransactionRequest(string hexEncodedInfo, IEnumerable<string> wifs)
        {
            Hex = hexEncodedInfo;
            Wifs.AddRange(wifs);
        }

        [JsonProperty(PropertyName = "hex")]
        public string Hex { get; }

        [JsonProperty(PropertyName = "wifs")]
        public List<string> Wifs { get; } = new List<string>();
    }
}