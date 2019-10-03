using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class AssetDetailsResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public Asset Asset { get; protected set; }
    }
}