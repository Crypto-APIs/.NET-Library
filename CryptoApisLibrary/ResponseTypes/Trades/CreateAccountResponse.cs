using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Trades
{
    public class CreateAccountResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public Account Account { get; protected set; }
    }
}