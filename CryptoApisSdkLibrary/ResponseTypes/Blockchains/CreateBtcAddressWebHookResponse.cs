using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class CreateBtcAddressWebHookResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateBtcAddressWebHook Payload { get; protected set; }
    }

    public class CreateBtcAddressWebHook : CreateBtcNewBlockWebHook
    {
        [DeserializeAs(Name = "address")]
        public string Address { get; protected set; }

        [DeserializeAs(Name = "confirmations")]
        public int Confirmations { get; protected set; }
    }
}