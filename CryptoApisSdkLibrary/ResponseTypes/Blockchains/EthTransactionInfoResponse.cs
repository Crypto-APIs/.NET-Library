using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class EthTransactionInfoResponse : BaseResponse
    {
        [DeserializeAs(Name = "payload")]
        public EthTransactionInfo Payload { get; protected set; }
    }
}