using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class GetTokensResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<TokenItem> Tokens { get; protected set; } = new List<TokenItem>();

        protected override IEnumerable<object> GetItems => Tokens;
    }

    public class TokenItem
    {
        [DeserializeAs(Name = "contract")]
        public string Contract { get; protected set; }

        [DeserializeAs(Name = "symbol")]
        public string Symbol { get; protected set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; protected set; }

        [DeserializeAs(Name = "type")]
        public string Type { get; protected set; }
    }
}