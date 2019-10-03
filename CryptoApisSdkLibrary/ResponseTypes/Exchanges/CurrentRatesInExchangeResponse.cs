using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class CurrentRatesInExchangeResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<ExchangeRateInSpecificExchange> Rates { get; protected set; } = new List<ExchangeRateInSpecificExchange>();

        protected override IEnumerable<object> GetItems => Rates;
    }
}