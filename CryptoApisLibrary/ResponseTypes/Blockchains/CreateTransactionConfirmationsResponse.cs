using CryptoApisLibrary.ResponseTypes.Blockchains.Payloads;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class CreateTransactionConfirmationsResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateTransactionConfirmationsWebHookPayload Payload { get; protected set; }
    }
}