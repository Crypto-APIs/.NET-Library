using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Tokens.GetTransactions
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseCollectionTestWithoutSkip
    {
        protected override ICollectionResponse GetAllList()
        {
            return Manager.Blockchains.Token.GetTransactions<GetEthTransactionsResponse>(NetworkCoin, Address);
        }

        protected override ICollectionResponse GetLimitList(int limit)
        {
            return Manager.Blockchains.Token.GetTransactions<GetEthTransactionsResponse>(NetworkCoin, Address, limit: limit);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string Address { get; }
    }
}