using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.TransactionsFee
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.TransactionsFee<BtcTransactionsFeeResponse>(NetworkCoin);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Fee, $"'{nameof(response.Fee)}' must not be null");
            Assert.IsFalse(string.IsNullOrEmpty(response.Fee.Recommended), 
                $"'{nameof(response.Fee.Recommended)}' must not be null");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}