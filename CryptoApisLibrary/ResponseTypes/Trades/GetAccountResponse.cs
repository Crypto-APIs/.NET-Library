using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Trades
{
    public class GetAccountResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public Account Account { get; protected set; }
    }
}