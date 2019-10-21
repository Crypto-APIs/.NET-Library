using CryptoApisLibrary.ResponseTypes.Blockchains.Payloads;
using RestSharp.Deserializers;
using System.Collections.Generic;
using CryptoApisLibrary.DataTypes;

namespace CryptoApisLibrary.ResponseTypes.Blockchains
{
    public class GetUnconfirmedTransactionsResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<BtcUnconfirmedTransaction> Transactions { get; protected set; } = new List<BtcUnconfirmedTransaction>();

        protected override IEnumerable<object> GetItems => Transactions;
    }
}