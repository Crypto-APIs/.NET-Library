using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains.Payloads
{
    public class CreateConfirmedTransactionWebHookPayload : WebHook
    {
        [DeserializeAs(Name = "confirmations")]
        public int ConfirmationCount { get; protected set; }

        [DeserializeAs(Name = "transaction")]
        public string TransactionHash { get; protected set; }
    }
}