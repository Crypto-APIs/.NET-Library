using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class AssetsResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<Asset> Assets { get; protected set; } = new List<Asset>();

        protected override IEnumerable<object> GetItems => Assets;
    }
}