using CryptoApisLibrary.ResponseTypes.Blockchains.Payloads;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class CreatePaymentResponse : BaseResponse
    { }

    public class CreateBtcPaymentResponse : CreatePaymentResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateBtcPaymentPayload Payload { get; protected set; }
    }

    public class CreateEthPaymentResponse : CreatePaymentResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateEthPaymentPayload Payload { get; protected set; }
    }
}