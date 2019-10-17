using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class SendBtcTransactionResponse : BaseResponse
    {
        [DeserializeAs(Name = "Payload")]
        public SendBtcTransaction Payload { get; protected set; }
    }

    public class SendBtcTransaction
    {
        [DeserializeAs(Name = "txid")]
        public string Txid { get; protected set; }
    }
}