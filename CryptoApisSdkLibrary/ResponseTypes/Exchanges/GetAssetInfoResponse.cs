using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetAssetInfoResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public Asset Asset { get; protected set; }
    }
}