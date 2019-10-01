using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetExchangesSupportingPairsResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<ExchangeSupportingPairs> Infos { get; protected set; } = new List<ExchangeSupportingPairs>();

        protected override IEnumerable<object> GetItems => Infos;
    }
}