using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class SymbolDetailsResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public Symbol Symbol { get; protected set; }
    }
}