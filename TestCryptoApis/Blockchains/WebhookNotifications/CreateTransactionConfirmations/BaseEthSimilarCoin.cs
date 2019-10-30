using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.WebhookNotifications.CreateTransactionConfirmations
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.WebhookNotification.CreateTransactionConfirmations<CreateTransactionConfirmationsResponse>(
                NetworkCoin, Url, Address, ConfirmationCount);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Id),
                    $"'{nameof(response.Payload.Id)}' must not be null");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Url of null was inappropriately allowed.")]
        public void NullUrl()
        {
            string nullUrl = null;
            Manager.Blockchains.WebhookNotification.CreateTransactionConfirmations<CreateTransactionConfirmationsResponse>(
                NetworkCoin, nullUrl, Address, ConfirmationCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string address = null;
            Manager.Blockchains.WebhookNotification.CreateTransactionConfirmations<CreateTransactionConfirmationsResponse>(
                NetworkCoin, Url, address, ConfirmationCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A ConfirmationCount was inappropriately allowed.")]
        public void InvalidConfirmationCount()
        {
            var confirmationCount = -15;
            Manager.Blockchains.WebhookNotification.CreateTransactionConfirmations<CreateTransactionConfirmationsResponse>(
                NetworkCoin, Url, Address, confirmationCount);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string Address { get; }
        private string Url { get; } = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
        private int ConfirmationCount { get; } = 15;
    }
}