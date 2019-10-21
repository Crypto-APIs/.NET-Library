using CryptoApisLibrary.ResponseTypes.Blockchains.Payloads;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class GetAddressResponse : BaseResponse
    { }

    public class GetBtcAddressResponse : GetAddressResponse
    {
        [DeserializeAs(Name = "payload")]
        public GetBtcAddressPayload Payload { get; protected set; }
    }

    public class GetEthAddressResponse : GetAddressResponse
    {
        [DeserializeAs(Name = "payload")]
        public GetEthAddressPayload Payload { get; protected set; }
    }
}