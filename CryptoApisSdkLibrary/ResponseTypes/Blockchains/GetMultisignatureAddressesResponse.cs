using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class GetMultisignatureAddressesResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<GetBtcAddressPayload> Addresses { get; protected set; } = new List<GetBtcAddressPayload>();

        protected override IEnumerable<object> GetItems => Addresses;
    }
}