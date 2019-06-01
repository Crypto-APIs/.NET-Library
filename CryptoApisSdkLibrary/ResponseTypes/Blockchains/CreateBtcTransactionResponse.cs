using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class CreateBtcTransactionResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public CreateBtcTransaction Payload { get; protected set; }
    }

    public class CreateBtcTransaction
    {
        [DeserializeAs(Name = "hex")]
        public string Hex { get; protected set; }
    }
}