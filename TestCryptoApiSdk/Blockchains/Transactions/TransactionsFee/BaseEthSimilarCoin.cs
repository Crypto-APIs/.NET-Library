using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Transactions.TransactionsFee
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.TransactionsFee<EthTransactionsFeeResponse>(NetworkCoin);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Payload);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Recommended));
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}