using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class DeleteWebhookResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public DeleteWebhook Payload { get; protected set; }
    }

    public class DeleteWebhook
    {
        [DeserializeAs(Name = "message")]
        public string Message { get; protected set; }
    }
}