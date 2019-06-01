using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class BtcTransactionInfoResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public BtcTransaction Transaction { get; protected set; }
    }
}