using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class CreateEthTransactionResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateEthTransaction Payload { get; protected set; }
    }

    public class CreateEthTransaction
    {
        [DeserializeAs(Name = "hex")]
        public string Hex { get; protected set; }
    }
}