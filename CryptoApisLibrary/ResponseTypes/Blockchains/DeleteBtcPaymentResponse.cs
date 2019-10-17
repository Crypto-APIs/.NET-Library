using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class DeletePaymentResponse : BaseResponse
    { }

    public class DeleteBtcPaymentResponse : DeletePaymentResponse
    {
        [DeserializeAs(Name = "payload")]
        public DeletePayment Payload { get; protected set; }
    }

    public class DeleteEthPaymentResponse : DeletePaymentResponse
    {
        [DeserializeAs(Name = "payload")]
        public DeletePayment Payload { get; protected set; }
    }

    public class DeletePayment
    {
        [DeserializeAs(Name = "message")]
        public string Message { get; protected set; }
    }
}