using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class PushTransactionResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public PushTransaction Payload { get; protected set; }
    }

    public class PushTransaction
    {
        [DeserializeAs(Name = "hex")]
        public string Hex { get; protected set; }
    }
}