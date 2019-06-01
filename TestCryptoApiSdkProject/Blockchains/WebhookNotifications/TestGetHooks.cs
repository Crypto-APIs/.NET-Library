using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestCryptoApiSdkProject.Blockchains.WebhookNotifications
{
    [TestClass]
    public class TestGetHooks : BaseTest
    {
        [TestMethod]
        public void TestBtcMain()
        {
            var response = Manager.Blockchains.WebhookNotification.GetHooks(BtcSimilarCoin.Btc, BtcSimilarNetwork.Mainnet);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsTrue(response.Items.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestBtcTest()
        {
            var response = Manager.Blockchains.WebhookNotification.GetHooks(BtcSimilarCoin.Btc, BtcSimilarNetwork.Testnet);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsTrue(response.Items.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestBchMain()
        {
            var response = Manager.Blockchains.WebhookNotification.GetHooks(BtcSimilarCoin.Bch, BtcSimilarNetwork.Mainnet);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsTrue(response.Items.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestBchTest()
        {
            var response = Manager.Blockchains.WebhookNotification.GetHooks(BtcSimilarCoin.Bch, BtcSimilarNetwork.Testnet);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsTrue(response.Items.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestLtcMain()
        {
            var response = Manager.Blockchains.WebhookNotification.GetHooks(BtcSimilarCoin.Ltc, BtcSimilarNetwork.Mainnet);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsTrue(response.Items.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestLtcTest()
        {
            var response = Manager.Blockchains.WebhookNotification.GetHooks(BtcSimilarCoin.Ltc, BtcSimilarNetwork.Testnet);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsTrue(response.Items.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestEthMain()
        {
            var response = Manager.Blockchains.WebhookNotification.GetHooks(EthSimilarCoin.Eth, EthSimilarNetwork.Mainnet);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsTrue(response.Items.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestEthRopsten()
        {
            var response = Manager.Blockchains.WebhookNotification.GetHooks(EthSimilarCoin.Eth, EthSimilarNetwork.Ropsten);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsTrue(response.Items.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        [TestMethod]
        public void TestEthRinkeby()
        {
            var response = Manager.Blockchains.WebhookNotification.GetHooks(EthSimilarCoin.Eth, EthSimilarNetwork.Rinkeby);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsTrue(response.Items.Any());
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }
    }
}