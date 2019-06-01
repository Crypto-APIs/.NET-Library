using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class GenerateBtcAddressResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public GenerateBtcAddressPayload Payload { get; protected set; }
    }

    public class GenerateEthAddressResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public GenerateEthAddressPayload Payload { get; protected set; }
    }

    public abstract class GenerateAddressPayload
    {
        [DeserializeAs(Name = "privateKey")]
        public string PrivateKey { get; protected set; }

        [DeserializeAs(Name = "address")]
        public string Address { get; protected set; }

        [DeserializeAs(Name = "publicKey")]
        public string PublicKey { get; protected set; }
    }

    public class GenerateBtcAddressPayload : GenerateAddressPayload
    {
        [DeserializeAs(Name = "wif")]
        public string Wif { get; protected set; }

        /// <summary>
        /// Applied only for BCH
        /// </summary>
        [DeserializeAs(Name = "bch")]
        public string Bch { get; protected set; }
    }

    public class GenerateEthAddressPayload : GenerateAddressPayload
    {
    }
}