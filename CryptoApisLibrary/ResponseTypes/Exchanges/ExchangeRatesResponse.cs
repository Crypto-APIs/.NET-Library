using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class ExchangeRatesResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<ExchangeRate> Rates { get; protected set; } = new List<ExchangeRate>();

        protected override IEnumerable<object> GetItems => Rates;
    }
}