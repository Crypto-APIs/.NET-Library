using System.Collections.Generic;
using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public abstract class GetInternalTransactionsResponse : BaseResponse
    {
        [DeserializeAs(Name = "meta")]
        public MetaCollection Meta { get; protected set; }
    }

    public class EthGetInternalTransactionsResponse : GetInternalTransactionsResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<Payload> Transactions { get; protected set; } = new List<Payload>();

        public class Payload
        {
            [DeserializeAs(Name = "fromAddress")]
            public string FromAddress { get; protected set; }

            [DeserializeAs(Name = "toAddress")]
            public string ToAddress { get; protected set; }

            [DeserializeAs(Name = "gas")]
            public string Gas { get; protected set; }

            [DeserializeAs(Name = "opcode")]
            public string OperationCode { get; protected set; }

            [DeserializeAs(Name = "value")]
            public string Value { get; protected set; }

            [DeserializeAs(Name = "failed")]
            public bool Failed { get; protected set; }

            [DeserializeAs(Name = "depth")]
            public int Depth { get; protected set; }
        }
    }
}