using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class ExchangeDetailsResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public Exchange Exchange { get; protected set; }
    }
}