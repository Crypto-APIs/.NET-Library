using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class CreateXPubResponse : BaseResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollectionResultsOnly Meta { get; protected set; }

        [DeserializeAs(Name = "payload")]
        public ResponsePayload Payload { get; protected set; }

        public class ResponsePayload
        {
            [DeserializeAs(Name = "xpriv")]
            public string Xpriv { get; protected set; }

            [DeserializeAs(Name = "xpub")]
            public string Xpub { get; protected set; }

            [DeserializeAs(Name = "wif")]
            public string Wif { get; protected set; }
        }
    }
}