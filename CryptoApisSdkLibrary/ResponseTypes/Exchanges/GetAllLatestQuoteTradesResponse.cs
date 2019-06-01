using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetAllLatestQuoteTradesResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<QuoteTrade> QuoteTrades { get; protected set; } = new List<QuoteTrade>();

        protected override IEnumerable<object> GetItems => QuoteTrades;
    }
}