using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class HistoricalOhlcvResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<Ohlcv> Ohlcv { get; protected set; } = new List<Ohlcv>();

        protected override IEnumerable<object> GetItems => Ohlcv;
    }
}