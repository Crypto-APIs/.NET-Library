using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public abstract class CreateConfirmedTransactionWebHookResponse : BaseResponse
    { }

    public class CreateBtcConfirmedTransactionWebHookResponse : CreateConfirmedTransactionWebHookResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateConfirmedTransactionWebHook Payload { get; protected set; }
    }

    public class CreateEthConfirmedTransactionWebHookResponse : CreateConfirmedTransactionWebHookResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateConfirmedTransactionWebHook Payload { get; protected set; }
    }

    public class CreateConfirmedTransactionWebHook : WebHookPayload
    {
        [DeserializeAs(Name = "confirmations")]
        public int ConfirmationCount { get; protected set; }

        [DeserializeAs(Name = "transaction")]
        public string TransactionHash { get; protected set; }
    }
}