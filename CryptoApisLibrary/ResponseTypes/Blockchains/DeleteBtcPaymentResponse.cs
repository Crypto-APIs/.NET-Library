using CryptoApisLibrary.ResponseTypes.Blockchains.Payloads;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class DeletePaymentResponse : BaseResponse
    { }

    public class DeleteBtcPaymentResponse : DeletePaymentResponse
    {
        [DeserializeAs(Name = "payload")]
        public DeletePaymentPayload Payload { get; protected set; }
    }

    public class DeleteEthPaymentResponse : DeletePaymentResponse
    {
        [DeserializeAs(Name = "payload")]
        public DeletePaymentPayload Payload { get; protected set; }
    }
}