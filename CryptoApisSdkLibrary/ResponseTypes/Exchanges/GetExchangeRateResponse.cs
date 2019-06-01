using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetExchangeRateResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public ExchangeRate ExchangeRate { get; protected set; }
    }
}