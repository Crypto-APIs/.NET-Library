using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class GenerateAccountResponse : BaseResponse
    { }

    public class GenerateEthAccountResponse : GenerateAccountResponse
    {
        [DeserializeAs(Name = "payload")]
        public ResponsePayload Payload { get; protected set; }

        public class ResponsePayload
        {
            [DeserializeAs(Name = "success")]
            public string Success { get; protected set; }

            [DeserializeAs(Name = "address")]
            public string Address { get; protected set; }
        }
    }
}