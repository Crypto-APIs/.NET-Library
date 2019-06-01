using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class CreateBtcNewBlockWebHookResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateBtcNewBlockWebHook Payload { get; protected set; }
    }

    public class CreateBtcNewBlockWebHook
    {
        [DeserializeAs(Name = "uuid")]
        public string Id { get; protected set; }

        [DeserializeAs(Name = "event")]
        public string Event { get; protected set; }

        [DeserializeAs(Name = "url")]
        public string Url { get; protected set; }
    }
}