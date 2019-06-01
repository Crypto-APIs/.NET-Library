using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetLatestTradesResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<Trade> Trades { get; protected set; } = new List<Trade>();

        protected override IEnumerable<object> GetItems => Trades;
    }
}