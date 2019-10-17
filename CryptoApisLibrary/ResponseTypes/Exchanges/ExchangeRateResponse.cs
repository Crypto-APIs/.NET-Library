using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class ExchangeRateResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public ExchangeRate ExchangeRate { get; protected set; }
    }
}