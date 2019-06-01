using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetAllExchangesResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<Exchange> Exchanges { get; protected set; } = new List<Exchange>();

        protected override IEnumerable<object> GetItems => Exchanges;
    }
}