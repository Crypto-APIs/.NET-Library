using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class GetNonceResponse : BaseResponse
    { }

    public class EthGetNonceResponse : GetNonceResponse
    {
        [DeserializeAs(Name = "payload")]
        public ResponsePayload Payload { get; protected set; }

        public class ResponsePayload
        {
            [DeserializeAs(Name = "nonce")]
            public int Nonce { get; protected set; }
        }
    }
}