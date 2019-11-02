using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.QueuedTransactions
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.QueuedTransactions<QueuedTransactionsResponse>(NetworkCoin);

            AssertNullErrorMessage(response);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}