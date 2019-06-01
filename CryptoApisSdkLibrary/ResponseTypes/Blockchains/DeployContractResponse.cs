using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class DeployContractResponse : BaseResponse
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