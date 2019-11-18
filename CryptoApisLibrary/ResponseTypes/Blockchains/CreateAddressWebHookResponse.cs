using CryptoApisLibrary.ResponseTypes.Blockchains.Payloads;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class CreateAddressWebHookResponse : BaseResponse
    { }

    public class CreateBtcAddressWebHookResponse : CreateAddressWebHookResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateAddressWebHookPayload Hook { get; protected set; }
    }

    public class CreateEthAddressWebHookResponse : CreateAddressWebHookResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateAddressWebHookPayload Hook { get; protected set; }
    }
}