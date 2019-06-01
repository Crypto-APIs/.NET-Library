using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class CreateBtcConfirmedTransactionWebHookResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateBtcConfirmedTransactionWebHook Payload { get; protected set; }
    }

    public class CreateBtcConfirmedTransactionWebHook : CreateBtcNewBlockWebHook
    {
        [DeserializeAs(Name = "confirmations")]
        public int ConfirmationCount { get; protected set; }

        [DeserializeAs(Name = "transaction")]
        public string TransactionHash { get; protected set; }
    }
}