using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class GetEthTransactionsResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<ResponsePayload> Transactions { get; protected set; } = new List<ResponsePayload>();

        protected override IEnumerable<object> GetItems => Transactions;

        public class ResponsePayload
        {
            [DeserializeAs(Name = "txHash")]
            public string TransactionHash { get; protected set; }

            [DeserializeAs(Name = "date")]
            public string Date { get; protected set; }

            [DeserializeAs(Name = "from")]
            public string From { get; protected set; }

            [DeserializeAs(Name = "to")]
            public string To { get; protected set; }

            [DeserializeAs(Name = "value")]
            public string Value { get; protected set; }

            [DeserializeAs(Name = "symbol")]
            public string Symbol { get; protected set; }

            [DeserializeAs(Name = "name")]
            public string Name { get; protected set; }

            [DeserializeAs(Name = "type")]
            public string Type { get; protected set; }
        }
    }
}