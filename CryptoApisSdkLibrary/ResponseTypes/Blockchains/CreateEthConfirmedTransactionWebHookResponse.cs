using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class CreateEthConfirmedTransactionWebHookResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateEthConfirmedTransactionWebHook Payload { get; protected set; }
    }

    public class CreateEthConfirmedTransactionWebHook : CreateEthWebHook
    {
        [DeserializeAs(Name = "confirmations")]
        public int ConfirmationCount { get; protected set; }

        [DeserializeAs(Name = "transaction")]
        public string TransactionHash { get; protected set; }
    }
}