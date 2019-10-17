using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class SignBtcTransactionResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public SignBtcTransaction Payload { get; protected set; }
    }

    public class SignBtcTransaction
    {
        [DeserializeAs(Name = "hex")]
        public string Hex { get; protected set; }

        public bool Complete { get; protected set; }
    }
}