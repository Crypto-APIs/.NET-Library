using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class CurrentRateInExchangeResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public ExchangeRateInSpecificExchange Rate { get; protected set; }
    }
}