using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class CreateAddressWebHookResponse : BaseResponse
    { }

    public class CreateBtcAddressWebHookResponse : CreateAddressWebHookResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateAddressWebHook Payload { get; protected set; }
    }

    public class CreateEthAddressWebHookResponse : CreateAddressWebHookResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateAddressWebHook Payload { get; protected set; }
    }

    public class CreateAddressWebHook : WebHookPayload
    {
        [DeserializeAs(Name = "address")]
        public string Address { get; protected set; }

        [DeserializeAs(Name = "confirmations")]
        public string Confirmations { get; protected set; }
    }
}