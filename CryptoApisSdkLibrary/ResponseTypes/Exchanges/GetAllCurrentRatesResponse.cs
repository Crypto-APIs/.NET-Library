using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetAllCurrentRatesResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<ExchangeRate> Rates { get; protected set; } = new List<ExchangeRate>();

        protected override IEnumerable<object> GetItems => Rates;
    }
}