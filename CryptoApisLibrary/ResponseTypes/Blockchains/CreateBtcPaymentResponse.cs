using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class CreatePaymentResponse : BaseResponse
    { }

    public class CreateBtcPaymentResponse : CreatePaymentResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateBtcPayment Payload { get; protected set; }
    }

    public class CreateEthPaymentResponse : CreatePaymentResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateEthPayment Payload { get; protected set; }
    }

    public class CreateBtcPayment
    {
        [DeserializeAs(Name = "wallet")]
        public string Wallet { get; protected set; }

        [DeserializeAs(Name = "callback")]
        public string Callback { get; protected set; }

        [DeserializeAs(Name = "from")]
        public string FromAddress { get; protected set; }

        [DeserializeAs(Name = "to")]
        public string ToAddress { get; protected set; }

        [DeserializeAs(Name = "uuid")]
        public string Id { get; protected set; }

        [DeserializeAs(Name = "confirmations")]
        public int Confirmations { get; protected set; }

        [DeserializeAs(Name = "fee")]
        public string Fee { get; protected set; }
    }

    public class CreateEthPayment
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