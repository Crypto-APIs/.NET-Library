using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class DeleteBtcPaymentResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public DeleteBtcPayment Payload { get; protected set; }
    }

    public class DeleteBtcPayment
    {
        [DeserializeAs(Name = "message")]
        public string Message { get; protected set; }
    }
}