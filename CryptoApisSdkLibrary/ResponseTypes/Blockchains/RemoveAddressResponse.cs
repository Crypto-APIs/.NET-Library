using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class RemoveAddressResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public RemoveAddressPayload Payload { get; protected set; }

    }
    public class RemoveAddressPayload
    {
        [DeserializeAs(Name = "Message")]
        public string Message  { get; protected set; }
    }
}