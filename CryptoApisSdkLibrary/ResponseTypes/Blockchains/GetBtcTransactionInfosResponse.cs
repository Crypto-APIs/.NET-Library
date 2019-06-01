using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class GetBtcTransactionInfosResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<BtcTransaction> Transactions { get; protected set; } = new List<BtcTransaction>();

        protected override IEnumerable<object> GetItems => Transactions;
    }
}