using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes
{
    public class ExchangeRateResponse
    {
        [DeserializeAs(Name = "payload")]
        public ExchangeRate ExchangeRate { get; set; }
    }
}