using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class ExchangesResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<Exchange> Exchanges { get; protected set; } = new List<Exchange>();

        protected override IEnumerable<object> GetItems => Exchanges;
    }
}