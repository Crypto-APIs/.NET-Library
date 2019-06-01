using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TestCryptoApiSdkProject.Blockchains.Transactions
{
    [TestClass]
    public class TestGetUnconfirmedTransactions : BaseTest
    {
        [TestMethod]
        public void TestBtcMain()
        {
            var infos = AssertBtcMain();
            AssertBtcMainSkip(infos);
            AssertBtcMainLimit(infos);
            AssertBtcMainSkipAndLimit(infos);
        }

        private List<BtcUnconfirmedTransaction> AssertBtcMain()
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Mainnet);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));

            Assert.IsNotNull(response.Transactions);
            Assert.IsTrue(response.Transactions.Any());

            return response.Transactions;
        }

        private void AssertBtcMainSkip(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var skip = 2;
            if (allInfos.Count < skip)
                return;

            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Mainnet, skip);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            TestSkip(allInfos, response.Transactions, skip);
        }

        private void AssertBtcMainLimit(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Mainnet, limit: 2);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            Assert.AreEqual(2, response.Transactions.Count);

            Assert.AreEqual(allInfos[0], response.Transactions[0]);
            Assert.AreEqual(allInfos[1], response.Transactions[1]);
        }

        private void AssertBtcMainSkipAndLimit(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Mainnet, skip: 2, limit: 3);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            Assert.AreEqual(3, response.Transactions.Count);

            Assert.AreEqual(allInfos[2], response.Transactions[0]);
            Assert.AreEqual(allInfos[3], response.Transactions[1]);
            Assert.AreEqual(allInfos[4], response.Transactions[2]);
        }

        [TestMethod]
        public void TestBtcMainInvalidSkip()
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Mainnet, skip: 20000000);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(response.Transactions.Any());
        }

        [TestMethod]
        public void TestBtcTest()
        {
            var infos = AssertBtcTest();
            AssertBtcTestSkip(infos);
            AssertBtcTestLimit(infos);
            AssertBtcTestSkipAndLimit(infos);
        }

        private IReadOnlyList<BtcUnconfirmedTransaction> AssertBtcTest()
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Testnet);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));

            Assert.IsNotNull(response.Transactions);
            Assert.IsTrue(response.Transactions.Any());

            return response.Transactions;
        }

        private void AssertBtcTestSkip(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var skip = 2;
            if (allInfos.Count < skip)
                return;

            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Testnet, skip);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            TestSkip(allInfos, response.Transactions, skip);
        }

        private void AssertBtcTestLimit(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Testnet, limit: 2);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            Assert.AreEqual(2, response.Transactions.Count);

            Assert.AreEqual(allInfos[0], response.Transactions[0]);
            Assert.AreEqual(allInfos[1], response.Transactions[1]);
        }

        private void AssertBtcTestSkipAndLimit(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Testnet, skip: 2, limit: 3);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            Assert.AreEqual(3, response.Transactions.Count);

            Assert.AreEqual(allInfos[2], response.Transactions[0]);
            Assert.AreEqual(allInfos[3], response.Transactions[1]);
            Assert.AreEqual(allInfos[4], response.Transactions[2]);
        }

        [TestMethod]
        public void TestBtcTestInvalidSkip()
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Btc, BtcSimilarNetwork.Testnet, skip: 20000000);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(response.Transactions.Any());
        }

        [TestMethod]
        public void TestBchMain()
        {
            var infos = AssertBchMain();
            AssertBchMainSkip(infos);
            AssertBchMainLimit(infos);
            AssertBchMainSkipAndLimit(infos);
        }

        private IReadOnlyList<BtcUnconfirmedTransaction> AssertBchMain()
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Bch, BtcSimilarNetwork.Mainnet);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));

            Assert.IsNotNull(response.Transactions);
            Assert.IsTrue(response.Transactions.Any());

            return response.Transactions;
        }

        private void AssertBchMainSkip(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var skip = 2;
            if (allInfos.Count < skip)
                return;

            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Bch, BtcSimilarNetwork.Mainnet, skip);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            TestSkip(allInfos, response.Transactions, skip);
        }

        private void AssertBchMainLimit(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Bch, BtcSimilarNetwork.Mainnet, limit: 2);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            Assert.AreEqual(2, response.Transactions.Count);

            Assert.AreEqual(allInfos[0], response.Transactions[0]);
            Assert.AreEqual(allInfos[1], response.Transactions[1]);
        }

        private void AssertBchMainSkipAndLimit(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Bch, BtcSimilarNetwork.Mainnet, skip: 2, limit: 3);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            Assert.AreEqual(3, response.Transactions.Count);

            Assert.AreEqual(allInfos[2], response.Transactions[0]);
            Assert.AreEqual(allInfos[3], response.Transactions[1]);
            Assert.AreEqual(allInfos[4], response.Transactions[2]);
        }

        [TestMethod]
        public void TestBchMainInvalidSkip()
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Bch, BtcSimilarNetwork.Mainnet, skip: 20000000);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(response.Transactions.Any());
        }

        [TestMethod]
        public void TestBchTest()
        {
            var infos = AssertBchTest();
            AssertBchTestSkip(infos);
            AssertBchTestLimit(infos);
            AssertBchTestSkipAndLimit(infos);
        }

        private IReadOnlyList<BtcUnconfirmedTransaction> AssertBchTest()
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Bch, BtcSimilarNetwork.Testnet);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));

            Assert.IsNotNull(response.Transactions);
            Assert.IsTrue(response.Transactions.Any());

            return response.Transactions;
        }

        private void AssertBchTestSkip(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var skip = 2;
            if (allInfos.Count < skip)
                return;

            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Bch, BtcSimilarNetwork.Testnet, skip);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            TestSkip(allInfos, response.Transactions, skip);
        }

        private void AssertBchTestLimit(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Bch, BtcSimilarNetwork.Testnet, limit: 2);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            Assert.AreEqual(2, response.Transactions.Count);

            Assert.AreEqual(allInfos[0], response.Transactions[0]);
            Assert.AreEqual(allInfos[1], response.Transactions[1]);
        }

        private void AssertBchTestSkipAndLimit(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Bch, BtcSimilarNetwork.Testnet, skip: 2, limit: 3);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            Assert.AreEqual(3, response.Transactions.Count);

            Assert.AreEqual(allInfos[2], response.Transactions[0]);
            Assert.AreEqual(allInfos[3], response.Transactions[1]);
            Assert.AreEqual(allInfos[4], response.Transactions[2]);
        }

        [TestMethod]
        public void TestBchTestInvalidSkip()
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Bch, BtcSimilarNetwork.Testnet, skip: 20000000);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(response.Transactions.Any());
        }

        [TestMethod]
        public void TestLtcMain()
        {
            var infos = AssertLtcMain();
            AssertLtcMainSkip(infos);
            AssertLtcMainLimit(infos);
            AssertLtcMainSkipAndLimit(infos);
        }

        private IReadOnlyList<BtcUnconfirmedTransaction> AssertLtcMain()
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Mainnet);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));

            Assert.IsNotNull(response.Transactions);
            Assert.IsTrue(response.Transactions.Any());

            return response.Transactions;
        }

        private void AssertLtcMainSkip(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var skip = 2;
            if (allInfos.Count < skip)
                return;

            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Mainnet, skip);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            TestSkip(allInfos, response.Transactions, skip);
        }

        private void AssertLtcMainLimit(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Mainnet, limit: 2);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            Assert.AreEqual(2, response.Transactions.Count);

            Assert.AreEqual(allInfos[0], response.Transactions[0]);
            Assert.AreEqual(allInfos[1], response.Transactions[1]);
        }

        private void AssertLtcMainSkipAndLimit(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Mainnet, skip: 2, limit: 3);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            Assert.AreEqual(3, response.Transactions.Count);

            Assert.AreEqual(allInfos[2], response.Transactions[0]);
            Assert.AreEqual(allInfos[3], response.Transactions[1]);
            Assert.AreEqual(allInfos[4], response.Transactions[2]);
        }

        [TestMethod]
        public void TestLtcMainInvalidSkip()
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Mainnet, skip: 20000000);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(response.Transactions.Any());
        }

        [TestMethod]
        public void TestLtcTest()
        {
            var infos = AssertLtcTest();
            AssertLtcTestSkip(infos);
            AssertLtcTestLimit(infos);
            AssertLtcTestSkipAndLimit(infos);
        }

        private IReadOnlyList<BtcUnconfirmedTransaction> AssertLtcTest()
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));

            Assert.IsNotNull(response.Transactions);

            return response.Transactions;
        }

        private void AssertLtcTestSkip(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var skip = 2;
            if (allInfos.Count < skip)
                return;

            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, skip);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            TestSkip(allInfos, response.Transactions, skip);
        }

        private void AssertLtcTestLimit(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, limit: 2);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            Assert.AreEqual(2, response.Transactions.Count);

            Assert.AreEqual(allInfos[0], response.Transactions[0]);
            Assert.AreEqual(allInfos[1], response.Transactions[1]);
        }

        private void AssertLtcTestSkipAndLimit(IReadOnlyList<BtcUnconfirmedTransaction> allInfos)
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, skip: 2, limit: 3);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsNotNull(response.Transactions);
            Assert.AreEqual(3, response.Transactions.Count);

            Assert.AreEqual(allInfos[2], response.Transactions[0]);
            Assert.AreEqual(allInfos[3], response.Transactions[1]);
            Assert.AreEqual(allInfos[4], response.Transactions[2]);
        }

        [TestMethod]
        public void TestLtcTestInvalidSkip()
        {
            var response = Manager.Blockchains.Transaction.GetUnconfirmedTransactions(
                BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet, skip: 20000000);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(response.Transactions.Any());
        }
    }
}