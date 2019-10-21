using CryptoApisLibrary.ResponseTypes.Blockchains.Payloads;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class GenerateAddressResponse : BaseResponse
    {
    }

    public class GenerateBtcAddressResponse : GenerateAddressResponse
    {
        [DeserializeAs(Name = "payload")]
        public GenerateBtcAddressPayload Payload { get; protected set; }

        public class GenerateBtcAddressPayload : GenerateAddressPayload
        {
            [DeserializeAs(Name = "wif")]
            public string Wif { get; protected set; }
        }
    }

    public class GenerateBchAddressResponse : GenerateAddressResponse
    {
        [DeserializeAs(Name = "payload")]
        public GenerateBchAddressPayload Payload { get; protected set; }

        public class GenerateBchAddressPayload : GenerateBtcAddressResponse.GenerateBtcAddressPayload
        {
            [DeserializeAs(Name = "bch")]
            public string Bch { get; protected set; }
        }
    }

    public class GenerateEthAddressResponse : GenerateAddressResponse
    {
        [DeserializeAs(Name = "payload")]
        public GenerateEthAddressPayload Payload { get; protected set; }

        public class GenerateEthAddressPayload : GenerateAddressPayload
        {
        }
    }
}