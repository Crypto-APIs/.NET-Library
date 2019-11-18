using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.GetInfoByBlockHashAndTransactionIndex
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.GetInfo<EthTransactionInfoResponse>(
                NetworkCoin, BlockHash, TransactionIndex);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.TransactionHash),
                $"'{nameof(response.Payload.TransactionHash)}' must not be null");
        }

        [TestMethod]
        public void InvalidBlockHash()
        {
            var blockHash = "qw'e";
            var response = Manager.Blockchains.Transaction.GetInfo<EthTransactionInfoResponse>(
                NetworkCoin, blockHash, TransactionIndex);

            AssertErrorMessage(response, "Transaction not found");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Url of null was inappropriately allowed.")]
        public void NullBlockHash()
        {
            string blockHash = null;
            Manager.Blockchains.Transaction.GetInfo<EthTransactionInfoResponse>(NetworkCoin, blockHash, TransactionIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Url of null was inappropriately allowed.")]
        public void InvalidTransactionIndex()
        {
            var transactionIndex = -5;
            Manager.Blockchains.Transaction.GetInfo<EthTransactionInfoResponse>(NetworkCoin, BlockHash, transactionIndex);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string BlockHash { get; }
        protected abstract int TransactionIndex { get; }
    }
}