using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.GetInfoByTransactionId
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.GetInfoByBlockHash<EthTransactionInfoResponse>(
                NetworkCoin, TransactionHash);

            AssertNullErrorMessage(response);
            Assert.AreEqual(TransactionHash, response.Payload.TransactionHash, "'TransactionHash' is wrong");
        }

        [TestMethod]
        public void InvalidBlockHash()
        {
            var blockHash = "q'we";
            var response = Manager.Blockchains.Transaction.GetInfoByBlockHash<EthTransactionInfoResponse>(
                NetworkCoin, blockHash);

            AssertErrorMessage(response, "Transaction not found");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A TransactionHash of null was inappropriately allowed.")]
        public void NullBlockHash()
        {
            string blockHash = null;
            Manager.Blockchains.Transaction.GetInfoByBlockHash<EthTransactionInfoResponse>(NetworkCoin, blockHash);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string TransactionHash { get; }
    }
}