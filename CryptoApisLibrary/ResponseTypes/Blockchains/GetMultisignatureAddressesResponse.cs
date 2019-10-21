using CryptoApisLibrary.ResponseTypes.Blockchains.Payloads;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class GetMultisignatureAddressesResponse : BaseCollectionResponse
    { }

    public class GetBtcMultisignatureAddressesResponse : GetMultisignatureAddressesResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<GetBtcAddressPayload> Addresses { get; protected set; } = new List<GetBtcAddressPayload>();

        protected override IEnumerable<object> GetItems => Addresses;
    }
}