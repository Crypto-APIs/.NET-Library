using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.WebhookNotifications.CreateConfirmedTransaction
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction<CreateEthConfirmedTransactionWebHookResponse>(
                NetworkCoin, Url, TransactionHash, ConfirmationCount);

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
            Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction<CreateEthConfirmedTransactionWebHookResponse>(
                NetworkCoin, nullUrl, TransactionHash, ConfirmationCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A TransactionHash of null was inappropriately allowed.")]
        public void NullTransactionHash()
        {
            string transactionHash = null;
            Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction<CreateEthConfirmedTransactionWebHookResponse>(
                NetworkCoin, Url, transactionHash, ConfirmationCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A ConfirmationCount was inappropriately allowed.")]
        public void InvalidConfirmationCount()
        {
            var confirmationCount = -15;
            Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction<CreateEthConfirmedTransactionWebHookResponse>(
                NetworkCoin, Url, TransactionHash, confirmationCount);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string TransactionHash { get; }
        private string Url { get; } = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
        private int ConfirmationCount { get; } = 15;
    }
}