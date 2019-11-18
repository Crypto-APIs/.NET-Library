using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.PendingTransactions
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.PendingTransactions<PendingTransactionsResponse>(NetworkCoin);
            AssertNullErrorMessage(response);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}