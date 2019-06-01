using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public class GetEthTransactionInfosResponse : BaseCollectionResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<EthTransactionInfo> Transactions { get; protected set; } = new List<EthTransactionInfo>();

        protected override IEnumerable<object> GetItems => Transactions;
    }
}