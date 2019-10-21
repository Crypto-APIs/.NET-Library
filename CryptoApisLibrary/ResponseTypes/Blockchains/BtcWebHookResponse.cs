using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class WebHookResponse : BaseResponse
    { }

    public class BtcWebHookResponse : WebHookResponse
    {
        [DeserializeAs(Name = "payload")]
        public WebHook Payload { get; protected set; }
    }

    public class EthWebHookResponse : WebHookResponse
    {
        [DeserializeAs(Name = "payload")]
        public WebHook Payload { get; protected set; }
    }
}