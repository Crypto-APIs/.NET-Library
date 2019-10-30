using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class DeleteAllWebhookResponse : BaseResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollectionResultsOnly Meta { get; protected set; }

        [DeserializeAs(Name = "payload")]
        public ResponsePayload Payload { get; protected set; }

        public class ResponsePayload
        {
            [DeserializeAs(Name = "message")]
            public string Message { get; protected set; }
        }
    }
}