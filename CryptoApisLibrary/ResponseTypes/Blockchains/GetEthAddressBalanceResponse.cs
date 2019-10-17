using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class GetAddressBalanceResponse : BaseResponse
    { }

    public class GetEthAddressBalanceResponse : GetAddressBalanceResponse
    {
        [DeserializeAs(Name = "payload")]
        public GetEthAddressPayload Payload { get; protected set; }
    }
}