using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Exchanges
{
    public class ExchangeDetailsResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public Exchange Exchange { get; protected set; }
    }
}