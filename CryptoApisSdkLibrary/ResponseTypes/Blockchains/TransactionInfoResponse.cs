using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public abstract class TransactionInfoResponse : BaseResponse
    { }

    public class BtcTransactionInfoResponse : TransactionInfoResponse
    {
        [DeserializeAs(Name = "payload")]
        public BtcTransaction Transaction { get; protected set; }
    }

    public class EthTransactionInfoResponse : TransactionInfoResponse
    {
        [DeserializeAs(Name = "payload")]
        public EthTransactionInfo Payload { get; protected set; }
    }
}