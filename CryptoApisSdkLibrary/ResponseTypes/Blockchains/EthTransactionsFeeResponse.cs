using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class EthTransactionsFeeResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public EthTransactionsFee Payload { get; protected set; }
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