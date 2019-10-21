using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class GetEthTokensResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<ResponsePayload> Tokens { get; protected set; } = new List<ResponsePayload>();

        protected override IEnumerable<object> GetItems => Tokens;

        public class ResponsePayload
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
}