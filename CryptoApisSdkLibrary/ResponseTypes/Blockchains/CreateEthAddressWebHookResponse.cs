using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class CreateEthAddressWebHookResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateEthAddressWebHook Payload { get; protected set; }
    }

    public class CreateEthAddressWebHook : CreateEthWebHook
    {
        [DeserializeAs(Name = "address")]
        public string Address { get; protected set; }

        [DeserializeAs(Name = "confirmations")]
        public string Confirmations { get; protected set; }
    }
}