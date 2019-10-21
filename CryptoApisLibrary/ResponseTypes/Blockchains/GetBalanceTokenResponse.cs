using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class GetBalanceTokenResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public ResponsePayload Payload { get; protected set; }

        public class ResponsePayload
        {
            [DeserializeAs(Name = "name")]
            public string Name { get; protected set; }

            [DeserializeAs(Name = "token")]
            public string Balance { get; protected set; }

            [DeserializeAs(Name = "symbol")]
            public string Symbol { get; protected set; }
        }
    }
}