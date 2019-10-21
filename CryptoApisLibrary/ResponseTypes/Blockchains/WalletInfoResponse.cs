using CryptoApisLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class WalletInfoResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public Wallet Wallet { get; protected set; }
    }
}