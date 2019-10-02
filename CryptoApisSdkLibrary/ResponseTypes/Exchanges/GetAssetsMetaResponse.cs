using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetAssetsMetaResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<AssetMeta> Assets { get; protected set; } = new List<AssetMeta>();

        protected override IEnumerable<object> GetItems => Assets;
    }
}