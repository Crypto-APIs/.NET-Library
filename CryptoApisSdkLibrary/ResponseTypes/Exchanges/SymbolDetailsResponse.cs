using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Exchanges
{
    public class SymbolDetailsResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public Symbol Symbol { get; protected set; }
    }
}