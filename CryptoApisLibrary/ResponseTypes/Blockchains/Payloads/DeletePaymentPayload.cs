using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains.Payloads
{
    public class DeletePaymentPayload
    {
        [DeserializeAs(Name = "message")]
        public string Message { get; protected set; }
    }
}