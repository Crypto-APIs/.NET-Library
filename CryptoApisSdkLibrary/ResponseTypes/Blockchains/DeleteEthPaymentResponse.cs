using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class DeleteEthPaymentResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public DeleteEthPayment Payload { get; protected set; }
    }

    public class DeleteEthPayment
    {
        [DeserializeAs(Name = "message")]
        public string Message { get; protected set; }
    }
}