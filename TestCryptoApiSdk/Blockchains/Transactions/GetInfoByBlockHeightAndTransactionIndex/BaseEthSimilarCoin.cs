using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdk.Blockchains.Transactions.GetInfoByBlockHeightAndTransactionIndex
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.GetInfo<EthTransactionInfoResponse>(NetworkCoin, BlockHeight, TransactionIndex);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.TransactionHash));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A BlockHeight of null was inappropriately allowed.")]
        public void InvalidBlockHash()
        {
            var blockHeight = -6530876;
            Manager.Blockchains.Transaction.GetInfo<EthTransactionInfoResponse>(NetworkCoin, blockHeight, TransactionIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A TransactionIndex of null was inappropriately allowed.")]
        public void InvalidTransactionIndex()
        {
            var transactionIndex = -79;
            Manager.Blockchains.Transaction.GetInfo<EthTransactionInfoResponse>(NetworkCoin, BlockHeight, transactionIndex);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract int BlockHeight { get; }
        protected abstract int TransactionIndex { get; }
    }
}