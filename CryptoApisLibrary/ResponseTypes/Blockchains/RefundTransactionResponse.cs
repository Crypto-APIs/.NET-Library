using System.Collections.Generic;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class RefundTransactionResponse : BaseResponse
    {
    }

    public class BtcRefundTransactionResponse : RefundTransactionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<Payload> Transactions { get; protected set; } = new List<Payload>();

        public class Payload
        {
            [DeserializeAs(Name = "txid")]
            public string Txid { get; protected set; }
        }
    }

    public class EthRefundTransactionResponse : RefundTransactionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<Payload> Transactions { get; protected set; } = new List<Payload>();

        public class Payload
        {
            [DeserializeAs(Name = "hex")]
            public string Hex { get; protected set; }
        }
    }
}