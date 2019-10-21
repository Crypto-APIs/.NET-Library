using CryptoApisLibrary.ResponseTypes.Blockchains.Payloads;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class GetHashInfoResponse : BaseResponse
    { }

    public class GetBtcHashInfoResponse : GetHashInfoResponse
    {
        [DeserializeAs(Name = "payload")]
        public GetBtcHashInfoPayload HashInfo { get; protected set; }
    }

    public class GetEthHashInfoResponse : GetHashInfoResponse
    {
        [DeserializeAs(Name = "payload")]
        public GetEthHashInfoPayload HashInfo { get; protected set; }
    }
}