using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class LocallySignTransactionResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public ResponsePayload Payload { get; protected set; }

        public class ResponsePayload
        {
            [DeserializeAs(Name = "from")]
            public string FromAddress { get; protected set; }

            [DeserializeAs(Name = "to")]
            public string ToAddress { get; protected set; }

            [DeserializeAs(Name = "gas")]
            public string Gas { get; protected set; }

            [DeserializeAs(Name = "gasLimit")]
            public string GasLimit { get; protected set; }

            [DeserializeAs(Name = "gasPrice")]
            public string GasPrice { get; protected set; }

            [DeserializeAs(Name = "nonce")]
            public long Nonce { get; protected set; }

            [DeserializeAs(Name = "value")]
            public string Value { get; protected set; }
        }
    }
}