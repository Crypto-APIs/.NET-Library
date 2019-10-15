using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Transactions.QueuedTransactions
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.QueuedTransactions<QueuedTransactionsResponse>(NetworkCoin);

            AssertNullErrorMessage(response);
            AssertNotEmptyCollection(nameof(response.Transactions), response.Transactions);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}