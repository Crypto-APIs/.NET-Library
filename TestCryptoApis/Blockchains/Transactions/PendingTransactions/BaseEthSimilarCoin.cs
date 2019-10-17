using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.PendingTransactions
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.PendingTransactions<PendingTransactionsResponse>(NetworkCoin);

            AssertNotEmptyCollection(nameof(response.Transactions), response.Transactions);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}