using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class OrderBookResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<OrderBook> OrderBook { get; protected set; } = new List<OrderBook>();
    }
}