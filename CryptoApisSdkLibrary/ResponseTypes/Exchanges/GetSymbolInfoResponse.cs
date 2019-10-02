using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class GetSymbolInfoResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public Symbol Symbol { get; protected set; }
    }
}