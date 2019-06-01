using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetHistoricalDataResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<OHLCV> Ohlcv { get; protected set; } = new List<OHLCV>();

        protected override IEnumerable<object> GetItems => Ohlcv;
    }
}