using CryptoApisLibrary.ResponseTypes.Blockchains.Payloads;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class CreateConfirmedTransactionWebHookResponse : BaseResponse
    { }

    public class CreateBtcConfirmedTransactionWebHookResponse : CreateConfirmedTransactionWebHookResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateConfirmedTransactionWebHookPayload Hook { get; protected set; }
    }

    public class CreateEthConfirmedTransactionWebHookResponse : CreateConfirmedTransactionWebHookResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateConfirmedTransactionWebHookPayload Hook { get; protected set; }
    }
}