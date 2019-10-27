using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class EstimateTransactionGasResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public ResponsePayload Payload { get; protected set; }

        public class ResponsePayload
        {
            [DeserializeAs(Name = "gasLimit")]
            public string GasLimit { get; protected set; }
        }
    }
}