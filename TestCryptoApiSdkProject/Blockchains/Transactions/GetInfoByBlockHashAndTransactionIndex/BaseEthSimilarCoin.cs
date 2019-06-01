using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfoByBlockHashAndTransactionIndex
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.GetInfo(Coin, Network, BlockHash, TransactionIndex);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.TransactionHash));
        }

        [TestMethod]
        public void InvalidBlockHash()
        {
            var blockHash = "qwe";
            var response = Manager.Blockchains.Transaction.GetInfo(Coin, Network, blockHash, TransactionIndex);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Transaction not found", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Url of null was inappropriately allowed.")]
        public void NullBlockHash()
        {
            string blockHash = null;
            Manager.Blockchains.Transaction.GetInfo(Coin, Network, blockHash, TransactionIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Url of null was inappropriately allowed.")]
        public void InvalidTransactionIndex()
        {
            var transactionIndex = -5;
            Manager.Blockchains.Transaction.GetInfo(Coin, Network, BlockHash, transactionIndex);
        }

        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
        protected abstract string BlockHash { get; }
        protected abstract int TransactionIndex { get; }
    }
}