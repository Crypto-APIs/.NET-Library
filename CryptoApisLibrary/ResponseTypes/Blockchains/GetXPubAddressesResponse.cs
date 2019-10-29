using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class GetXPubAddressesResponse : BaseResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollectionResultsOnly Meta { get; protected set; }

        [DeserializeAs(Name = "payload")]
        public List<string> Addresses { get; } = new List<string>();
    }
}