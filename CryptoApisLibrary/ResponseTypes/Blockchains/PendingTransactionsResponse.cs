using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class PendingTransactionsResponse : BaseMetaCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<PendingTransactions> Transactions { get; protected set; } = new List<PendingTransactions>();
    }

    public class PendingTransactions
    {
        [DeserializeAs(Name = "hash")]
        public string Hash { get; protected set; }

        [DeserializeAs(Name = "nonce")]
        public long Nonce { get; protected set; }

        [DeserializeAs(Name = "blockHash")]
        public string BlockHash { get; protected set; }

        [DeserializeAs(Name = "blockNumber")]
        public long BlockNumber { get; protected set; }

        [DeserializeAs(Name = "transactionIndex")]
        public string TransactionIndex { get; protected set; }

        [DeserializeAs(Name = "from")]
        public string From { get; protected set; }

        [DeserializeAs(Name = "to")]
        public string To { get; protected set; }

        [DeserializeAs(Name = "value")]
        public string Value { get; protected set; }

        [DeserializeAs(Name = "gasPrice")]
        public string GasPrice { get; protected set; }

        [DeserializeAs(Name = "gas")]
        public string Gas { get; protected set; }

        [DeserializeAs(Name = "input")]
        public string Input { get; protected set; }
    }
}