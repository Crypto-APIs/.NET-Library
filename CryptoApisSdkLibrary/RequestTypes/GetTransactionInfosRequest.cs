﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal class GetTransactionInfosRequest
    {
        public GetTransactionInfosRequest(IEnumerable<string> transactionHashes)
        {
            TransactionHashes.AddRange(transactionHashes);
        }

        [JsonProperty(PropertyName = "txs")]
        public List<string> TransactionHashes { get; } = new List<string>();
    }
}