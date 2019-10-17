using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class WebHookResponse : BaseResponse
    { }

    public class BtcWebHookResponse : WebHookResponse
    {
        [DeserializeAs(Name = "payload")]
        public WebHookPayload Payload { get; protected set; }
    }

    public class EthWebHookResponse : WebHookResponse
    {
        [DeserializeAs(Name = "payload")]
        public WebHookPayload Payload { get; protected set; }
    }

    public class WebHookPayload
    {
        [DeserializeAs(Name = "uuid")]
        public string Id { get; protected set; }

        [DeserializeAs(Name = "event")]
        public string Event { get; protected set; }

        [DeserializeAs(Name = "url")]
        public string Url { get; protected set; }
    }
}