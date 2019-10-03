using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class CurrentRateInExchangeResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public ExchangeRateInSpecificExchange Rate { get; protected set; }
    }
}