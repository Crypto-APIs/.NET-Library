using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class QueuedTransactionsResponse : BaseMetaCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<PendingTransactions> Transactions { get; protected set; } = new List<PendingTransactions>();
    }
}