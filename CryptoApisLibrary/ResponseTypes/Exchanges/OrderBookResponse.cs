using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class OrderBookResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public OrderBook OrderBook { get; protected set; }
    }
}