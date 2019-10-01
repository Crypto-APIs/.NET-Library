using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetExchangeInfoResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public Exchange Exchange { get; protected set; }
    }
}