using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains.Payloads
{
    public class CreateAddressWebHookPayload : WebHook
    {
        [DeserializeAs(Name = "address")]
        public string Address { get; protected set; }

        [DeserializeAs(Name = "confirmations")]
        public string Confirmations { get; protected set; }
    }
}