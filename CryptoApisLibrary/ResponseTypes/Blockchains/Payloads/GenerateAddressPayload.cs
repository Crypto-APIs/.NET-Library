using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains.Payloads
{
    public abstract class GenerateAddressPayload
    {
        [DeserializeAs(Name = "privateKey")]
        public string PrivateKey { get; protected set; }

        [DeserializeAs(Name = "address")]
        public string Address { get; protected set; }

        [DeserializeAs(Name = "publicKey")]
        public string PublicKey { get; protected set; }
    }
}