using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class GetEthAddressBalanceResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public GetEthAddressPayload Payload { get; protected set; }
    }
}