using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains.Payloads
{
    public class CreateTransactionConfirmationsWebHookPayload : WebHook
    {
        [DeserializeAs(Name = "confirmations")]
        public int ConfirmationCount { get; protected set; }

        [DeserializeAs(Name = "address")]
        public string Address { get; protected set; }
    }
}