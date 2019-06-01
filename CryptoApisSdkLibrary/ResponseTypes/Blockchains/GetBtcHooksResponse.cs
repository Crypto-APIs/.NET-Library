using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class GetBtcHooksResponse : BaseResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollectionResultsOnly Meta { get; protected set; }

        [DeserializeAs(Name = "payload")]
        public List<BtcHook> Hooks { get; protected set; } = new List<BtcHook>();
    }

    public class BtcHook
    {
        [DeserializeAs(Name = "uuid")]
        public string Id { get; protected set; }

        [DeserializeAs(Name = "address")]
        public string Address { get; protected set; }

        [DeserializeAs(Name = "url")]
        public string Url { get; protected set; }

        [DeserializeAs(Name = "confirmations")]
        public int Confirmations { get; protected set; }

        [DeserializeAs(Name = "transaction")]
        public string Transaction { get; protected set; }

        [DeserializeAs(Name = "event")]
        public string Event { get; protected set; }
    }
}