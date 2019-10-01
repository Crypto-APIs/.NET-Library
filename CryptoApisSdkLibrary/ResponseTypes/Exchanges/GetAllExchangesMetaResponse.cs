using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetAllExchangesMetaResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<ExchangeMeta> Exchanges { get; protected set; } = new List<ExchangeMeta>();

        protected override IEnumerable<object> GetItems => Exchanges;
    }
}