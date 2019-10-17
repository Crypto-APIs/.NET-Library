using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.GetInfoByTransactionId
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.GetInfo<BtcTransactionInfoResponse>(NetworkCoin, TransactionId);

            AssertNullErrorMessage(response);
            Assert.AreEqual(TransactionId, response.Transaction.Id, "'TransactionId' is wrong");
        }

        [TestMethod]
        public void InvalidBlockHash()
        {
            var response = Manager.Blockchains.Transaction.GetInfo<BtcTransactionInfoResponse>(NetworkCoin, transactionId: "qwe");

            AssertErrorMessage(response, "Transaction not found");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A TransactionId of null was inappropriately allowed.")]
        public void NullTransactionId()
        {
            Manager.Blockchains.Transaction.GetInfo<BtcTransactionInfoResponse>(NetworkCoin, transactionId: null);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string TransactionId { get; }
    }
}