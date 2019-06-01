using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class CreateEthWebHookResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateEthWebHook Payload { get; protected set; }
    }

    public class CreateEthWebHook
    {
        [DeserializeAs(Name = "uuid")]
        public string Id { get; protected set; }

        [DeserializeAs(Name = "event")]
        public string Event { get; protected set; }

        [DeserializeAs(Name = "url")]
        public string Url { get; protected set; }
    }
}