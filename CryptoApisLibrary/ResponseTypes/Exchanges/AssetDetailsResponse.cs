using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class AssetDetailsResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public Asset Asset { get; protected set; }
    }
}