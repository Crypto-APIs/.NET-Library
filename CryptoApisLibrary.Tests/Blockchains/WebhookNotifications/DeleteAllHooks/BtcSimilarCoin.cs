using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.WebhookNotifications.DeleteAllHooks
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            if (!IsAdditionalPackagePlan)
                return;

            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            CreateWebNotification(networkCoin, url);

            var response = Manager.Blockchains.WebhookNotification.DeleteAll<DeleteAllWebhookResponse>(networkCoin);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Message),
                $"'{nameof(response.Payload.Message)}' must not be null");
            Assert.AreEqual("All Webhooks were successfully deleted!", response.Payload.Message);
            CheckEmptyWebhookNotificationCollection(networkCoin);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void ReDeletingHooks_ErrorMessage(NetworkCoin networkCoin)
        {
            if (!IsAdditionalPackagePlan)
                return;

            // First delete
            Manager.Blockchains.WebhookNotification.DeleteAll<DeleteAllWebhookResponse>(networkCoin);

            // Second delete
            var response = Manager.Blockchains.WebhookNotification.DeleteAll<DeleteAllWebhookResponse>(networkCoin);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Message),
                $"'{nameof(response.Payload.Message)}' must not be null");
            Assert.AreEqual("No existing Webhook subscription found!", response.Payload.Message);
        }

        private void CheckEmptyWebhookNotificationCollection(NetworkCoin networkCoin)
        {
            var response = Manager.Blockchains.WebhookNotification.GetHooks<GetBtcHooksResponse>(networkCoin);

            AssertNullErrorMessage(response);
            AssertEmptyCollection(nameof(response.Hooks), response.Hooks);
        }

        private void CreateWebNotification(NetworkCoin networkCoin, string url)
        {
            var response = Manager.Blockchains.WebhookNotification.CreateNewBlock<BtcWebHookResponse>(networkCoin, url);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Hook.Id), $"'{nameof(response.Hook.Id)}' must not be null");
        }
    }
}