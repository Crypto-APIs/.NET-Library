using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class OrderBookResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public OrderBook OrderBook { get; protected set; }
    }
}