using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class TransferTokensResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public TransferTokens Payload { get; protected set; }
    }

    public class TransferTokens : BaseResponse
    {
        [DeserializeAs(Name = "hex")]
        public string Hex { get; protected set; }
    }
}