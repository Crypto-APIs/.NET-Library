using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class EstimateTransactionGasResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public EstimateTransactionGas Payload { get; protected set; }
    }

    public class EstimateTransactionGas
    {
        [DeserializeAs(Name = "gas_needed")]
        public string GasNeeded { get; protected set; }
    }
}