using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class EstimateGasContractResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public EstimateGasContract Payload { get; protected set; }
    }

    public class EstimateGasContract : BaseResponse
    {
        [DeserializeAs(Name = "gas_price")]
        public double GasPrice { get; protected set; }

        [DeserializeAs(Name = "gas_limit")]
        public double GasLimit { get; protected set; }
    }
}