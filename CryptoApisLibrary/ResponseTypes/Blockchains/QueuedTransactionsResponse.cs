using CryptoApisLibrary.ResponseTypes.Blockchains.Payloads;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class QueuedTransactionsResponse : BaseMetaCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<PendingTransactionPayload> Transactions { get; protected set; } = new List<PendingTransactionPayload>();
    }
}