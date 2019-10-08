using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestCryptoApiSdk.Blockchains.Transactions.PendingTransactions
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.PendingTransactions<PendingTransactionsResponse>(NetworkCoin);

            Assert.IsTrue(response.Transactions.Any(), "Collection must not be empty");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}