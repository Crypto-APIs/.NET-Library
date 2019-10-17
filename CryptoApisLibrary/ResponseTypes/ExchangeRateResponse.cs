using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes
{
    public class ExchangeRateResponse
    {
        [DeserializeAs(Name = "payload")]
        public ExchangeRate ExchangeRate { get; set; }
    }
}