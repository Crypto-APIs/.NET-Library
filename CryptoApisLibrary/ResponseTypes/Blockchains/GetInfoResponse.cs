using CryptoApisLibrary.ResponseTypes.Blockchains.Payloads;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class GetInfoResponse : BaseResponse
    { }

    public class GetBtcInfoResponse : GetInfoResponse
    {
        [DeserializeAs(Name = "payload")]
        public GetBtcInfoPayload Info { get; protected set; }
    }

    public class GetEthInfoResponse : GetInfoResponse
    {
        [DeserializeAs(Name = "payload")]
        public GetEthInfoPayload Info { get; protected set; }
    }
}