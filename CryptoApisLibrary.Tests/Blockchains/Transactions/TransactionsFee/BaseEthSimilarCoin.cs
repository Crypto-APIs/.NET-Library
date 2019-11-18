using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.TransactionsFee
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.TransactionsFee<EthTransactionsFeeResponse>(NetworkCoin);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Fee);
            Assert.IsFalse(string.IsNullOrEmpty(response.Fee.Recommended));
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}