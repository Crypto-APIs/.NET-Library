using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class ExchangeRateResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public ExchangeRate ExchangeRate { get; protected set; }
    }
}