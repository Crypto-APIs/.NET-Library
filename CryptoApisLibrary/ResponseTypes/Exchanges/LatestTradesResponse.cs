using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class LatestTradesResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<Trade> Trades { get; protected set; } = new List<Trade>();

        protected override IEnumerable<object> GetItems => Trades;
    }
}