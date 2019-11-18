using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.WebhookNotifications.DeleteAllHooks
{
    [TestClass]
    public abstract class EthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void AllCorrect_ShouldPass()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            CreateWebNotification(url);

            var response = Manager.Blockchains.WebhookNotification.DeleteAll<DeleteAllWebhookResponse>(NetworkCoin);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Message),
                $"'{nameof(response.Payload.Message)}' must not be null");
            Assert.AreEqual("All Webhooks were successfully deleted!", response.Payload.Message);
            CheckEmptyWebhookNotificationCollection();
        }

        [TestMethod]
        public void ReDeletingHooks_ErrorMessage()
        {
            if (!IsAdditionalPackagePlan)
                return;

            // First delete
            Manager.Blockchains.WebhookNotification.DeleteAll<DeleteAllWebhookResponse>(NetworkCoin);

            // Second delete
            var response = Manager.Blockchains.WebhookNotification.DeleteAll<DeleteAllWebhookResponse>(NetworkCoin);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Message),
                $"'{nameof(response.Payload.Message)}' must not be null");
            Assert.AreEqual("No existing Webhook subscription found!", response.Payload.Message);
        }

        private void CreateWebNotification(string url)
        {
            var response = Manager.Blockchains.WebhookNotification.CreateNewBlock<EthWebHookResponse>(NetworkCoin, url);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Hook.Id),
                $"'{nameof(response.Hook.Id)}' must not be null");
        }

        private void CheckEmptyWebhookNotificationCollection()
        {
            var response = Manager.Blockchains.WebhookNotification.GetHooks<GetEthHooksResponse>(NetworkCoin);
            AssertNullErrorMessage(response);
            AssertEmptyCollection(nameof(response.Hooks), response.Hooks);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}