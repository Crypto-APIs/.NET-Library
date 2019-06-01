using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetArbitrageInfoResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<ArbitrageInfo> Trades { get; protected set; } = new List<ArbitrageInfo>();

        protected override IEnumerable<object> GetItems => Trades;
    }
}