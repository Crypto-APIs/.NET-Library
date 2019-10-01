using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class GenerateAccountResponse : BaseResponse
    { }

    public class GenerateEthAccountResponse : GenerateAccountResponse
    {
        [DeserializeAs(Name = "payload")]
        public GenerateEthAccountPayload Payload { get; protected set; }
    }

    public class GenerateEthAccountPayload
    {
        [DeserializeAs(Name = "success")]
        public string Success { get; protected set; }

        [DeserializeAs(Name = "address")]
        public string Address { get; protected set; }
    }
}