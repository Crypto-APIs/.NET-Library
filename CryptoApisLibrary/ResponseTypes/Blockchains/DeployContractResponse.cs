using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class DeployContractResponse : BaseResponse
    { }

    public class EthDeployContractResponse : DeployContractResponse
    {
        [DeserializeAs(Name = "payload")]
        public DeployContract Payload { get; protected set; }
    }

    public class DeployContract : BaseResponse
    {
        [DeserializeAs(Name = "hex")]
        public string Hex { get; protected set; }
    }
}