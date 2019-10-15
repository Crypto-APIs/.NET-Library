using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Blockchains.Transactions.GetInfoByTransactionId
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.GetInfoByBlockHash<EthTransactionInfoResponse>(NetworkCoin, TransactionHash);

            AssertNullErrorMessage(response);
            Assert.AreEqual(TransactionHash, response.Payload.TransactionHash, "'TransactionHash' is wrong");
        }

        [TestMethod]
        public void InvalidBlockHash()
        {
            var response = Manager.Blockchains.Transaction.GetInfoByBlockHash<EthTransactionInfoResponse>(NetworkCoin, blockHash: "qwe");

            AssertErrorMessage(response, "Transaction not found");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A TransactionHash of null was inappropriately allowed.")]
        public void NullBlockHash()
        {
            Manager.Blockchains.Transaction.GetInfoByBlockHash<EthTransactionInfoResponse>(NetworkCoin, blockHash: null);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string TransactionHash { get; }
    }
}