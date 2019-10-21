using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class SendBtcTransactionResponse : BaseResponse
    {
        [DeserializeAs(Name = "Payload")]
        public ResponsePayload Payload { get; protected set; }

        public class ResponsePayload
        {
            [DeserializeAs(Name = "txid")]
            public string Txid { get; protected set; }
        }
    }
}