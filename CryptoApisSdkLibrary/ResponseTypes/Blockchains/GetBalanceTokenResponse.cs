using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class GetBalanceTokenResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public GetBalanceToken Payload { get; protected set; }
    }

    public class GetBalanceToken : BaseResponse
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; protected set; }

        [DeserializeAs(Name = "token")]
        public string Balance { get; protected set; }

        [DeserializeAs(Name = "symbol")]
        public string Symbol { get; protected set; }
    }
}