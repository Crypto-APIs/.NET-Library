using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class AssetsMetaResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<AssetMeta> Assets { get; protected set; } = new List<AssetMeta>();

        protected override IEnumerable<object> GetItems => Assets;
    }
}