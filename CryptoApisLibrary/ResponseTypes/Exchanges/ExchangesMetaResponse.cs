using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class ExchangesMetaResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<ExchangeMeta> Exchanges { get; protected set; } = new List<ExchangeMeta>();

        protected override IEnumerable<object> GetItems => Exchanges;
    }
}