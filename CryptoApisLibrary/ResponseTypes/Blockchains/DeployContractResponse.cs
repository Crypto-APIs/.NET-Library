using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class DeployContractResponse : BaseResponse
    { }

    public class EthDeployContractResponse : DeployContractResponse
    {
        [DeserializeAs(Name = "payload")]
        public ResponsePayload Payload { get; protected set; }

        public class ResponsePayload : BaseResponse
        {
            [DeserializeAs(Name = "hex")]
            public string Hex { get; protected set; }
        }
    }
}