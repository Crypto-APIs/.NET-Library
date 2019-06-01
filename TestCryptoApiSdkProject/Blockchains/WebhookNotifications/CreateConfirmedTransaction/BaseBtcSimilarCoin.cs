using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.WebhookNotifications.CreateConfirmedTransaction
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction(
                Coin, Network, Url, TransactionHash, ConfirmationCount);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Id));
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
        [ExpectedException(typeof(ArgumentNullException), "A Url of null was inappropriately allowed.")]
        public void NullUrl()
        {
            string nullUrl = null;
            Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction(
                Coin, Network, nullUrl, TransactionHash, ConfirmationCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A TransactionHash of null was inappropriately allowed.")]
        public void NullTransactionHash()
        {
            string transactionHash = null;
            Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction(
                Coin, Network, Url, transactionHash, ConfirmationCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A ConfirmationCount was inappropriately allowed.")]
        public void InvalidConfirmationCount()
        {
            var confirmationCount = -6;
            Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction(
                Coin, Network, Url, TransactionHash, confirmationCount);
        }

        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }
        protected abstract string TransactionHash { get; }
        private string Url { get; } = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
        private int ConfirmationCount { get; } = 6;
    }
}