using CryptoApisSdkLibrary.DataTypes;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.ResponseTypes.Blockchains
{
    public abstract class GetAddressTransactionsResponse : BaseCollectionResponse
    { }

    public class GetBtcAddressTransactionsResponse : GetAddressTransactionsResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<BtcTransaction> Transactions { get; protected set; } = new List<BtcTransaction>();

        protected override IEnumerable<object> GetItems => Transactions;
    }

    public class GetEthAddressTransactionsResponse : GetAddressTransactionsResponse
    {
        [DeserializeAs(Name = "payload")]
        public List<EthTransaction> Transactions { get; protected set; } = new List<EthTransaction>();

        protected override IEnumerable<object> GetItems => Transactions;
    }
}