using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Blockchains.WebhookNotifications.DeleteHook
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
            var hook = Manager.Blockchains.WebhookNotification.CreateNewBlock<BtcWebHookResponse>(networkCoin, url)?.Hook;
            if (hook == null)
                return;

            var deleteResponse = Manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(networkCoin, hook.Id);

            AssertNullErrorMessage(deleteResponse);
            Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message),
                $"'{nameof(deleteResponse.Payload.Message)}' must not be null");
            Assert.AreEqual($"Webhook with id: {hook.Id} was successfully deleted!", deleteResponse.Payload.Message);
            CheckDeletedHook(networkCoin, hook);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A HookId of null was inappropriately allowed.")]
        public void NullHookId_Exception(NetworkCoin networkCoin)
        {
            string hookId = null;

            Manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(networkCoin, hookId);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void UnexistingHookId_ErrorMessage(NetworkCoin networkCoin)
        {
            var hookId = "qw'e";

            var response = Manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(networkCoin, hookId);

            AssertErrorMessage(response, IsAdditionalPackagePlan
                ? $"Could not delete webhook with id: {hookId}"
                : "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
        }

        private void CheckDeletedHook(NetworkCoin networkCoin, WebHook hook)
        {
            var response = Manager.Blockchains.WebhookNotification.GetHooks<GetBtcHooksResponse>(networkCoin);

            AssertNullErrorMessage(response);
            CollectionAssert.DoesNotContain(response.Hooks, hook);
        }
    }
}