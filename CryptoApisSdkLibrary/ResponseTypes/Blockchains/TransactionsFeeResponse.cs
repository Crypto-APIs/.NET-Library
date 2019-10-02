using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public abstract class TransactionsFeeResponse : BaseResponse
    { }

    public class BtcTransactionsFeeResponse : TransactionsFeeResponse
    {
        [DeserializeAs(Name = "payload")]
        public BtcTransactionsFee Payload { get; protected set; }
    }

    public class EthTransactionsFeeResponse : TransactionsFeeResponse
    {
        [DeserializeAs(Name = "payload")]
        public EthTransactionsFee Payload { get; protected set; }
    }

    public class BtcTransactionsFee
    {
        [DeserializeAs(Name = "min")]
        public string Min { get; protected set; }

        [DeserializeAs(Name = "max")]
        public string Max { get; protected set; }

        [DeserializeAs(Name = "average")]
        public string Average { get; protected set; }

        [DeserializeAs(Name = "average_bytes")]
        public string AverageBytes { get; protected set; }

        [DeserializeAs(Name = "recommended")]
        public string Recommended { get; protected set; }

        [DeserializeAs(Name = "unit")]
        public string Unit { get; protected set; }
    }

    public class EthTransactionsFee
    {
        [DeserializeAs(Name = "min")]
        public string Min { get; protected set; }

        [DeserializeAs(Name = "max")]
        public string Max { get; protected set; }

        [DeserializeAs(Name = "average")]
        public string Average { get; protected set; }

        [DeserializeAs(Name = "recommended")]
        public string Recommended { get; protected set; }

        [DeserializeAs(Name = "unit")]
        public string Unit { get; protected set; }
    }
}