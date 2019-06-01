using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.GetInfoByBlockHeightAndTransactionIndex
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.GetInfo(Coin, Network, BlockHeight, TransactionIndex);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.TransactionHash));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A BlockHeight of null was inappropriately allowed.")]
        public void InvalidBlockHash()
        {
            var blockHeight = -6530876;
            Manager.Blockchains.Transaction.GetInfo(Coin, Network, blockHeight, TransactionIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A TransactionIndex of null was inappropriately allowed.")]
        public void InvalidTransactionIndex()
        {
            var transactionIndex = -79;
            Manager.Blockchains.Transaction.GetInfo(Coin, Network, BlockHeight, transactionIndex);
        }

        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
        protected abstract int BlockHeight { get; }
        protected abstract int TransactionIndex { get; }
    }
}