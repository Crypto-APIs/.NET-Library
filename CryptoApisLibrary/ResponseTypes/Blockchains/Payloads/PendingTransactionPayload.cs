using RestSharp.Deserializers;

namespace CryptoApisLibrary.ResponseTypes.Blockchains.Payloads
{
    public class PendingTransactionPayload
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