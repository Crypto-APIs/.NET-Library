using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains.Payloads
{
    public class CreateEthPaymentPayload
    {
        [DeserializeAs(Name = "confirmations")]
        public int Confirmations { get; protected set; }

        [DeserializeAs(Name = "callback")]
        public string Callback { get; protected set; }

        [DeserializeAs(Name = "from")]
        public string FromAddress { get; protected set; }

        [DeserializeAs(Name = "to")]
        public string ToAddress { get; protected set; }

        [DeserializeAs(Name = "uuid")]
        public string Id { get; protected set; }

        [DeserializeAs(Name = "gasPrice")]
        public string GasPrice { get; protected set; }

        [DeserializeAs(Name = "gasLimit")]
        public string GasLimit { get; protected set; }
    }
}