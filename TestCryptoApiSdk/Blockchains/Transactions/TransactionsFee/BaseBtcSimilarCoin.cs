using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Transactions.TransactionsFee
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.TransactionsFee<BtcTransactionsFeeResponse>(NetworkCoin);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Payload, $"'{nameof(response.Payload)}' must not be null");
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Recommended), 
                $"'{nameof(response.Payload.Recommended)}' must not be null");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}