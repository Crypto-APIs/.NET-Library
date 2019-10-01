using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdkProject.Blockchains.WebhookNotifications.DeleteHook
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var response = Manager.Blockchains.WebhookNotification.GetHooks<GetEthHooksResponse>(NetworkCoin);
            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));

            foreach (var hook in response.Hooks)
            {
                var deleteResponse = Manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(NetworkCoin, hook.Id);
                Assert.IsNotNull(deleteResponse);
                Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message));
                Assert.AreEqual($"Webhook with id: {hook.Id} was successfully deleted!", deleteResponse.Payload.Message);
            }

            var secondResponse = Manager.Blockchains.WebhookNotification.GetHooks<GetEthHooksResponse>(NetworkCoin);
            Assert.IsNotNull(secondResponse);
            Assert.IsTrue(string.IsNullOrEmpty(secondResponse.ErrorMessage));
            Assert.IsFalse(secondResponse.Hooks.Any());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A HookId of null was inappropriately allowed.")]
        public void DeleteNullHookId()
        {
            string hookId = null;
            Manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(NetworkCoin, hookId);
        }

        [TestMethod]
        public void DeleteInvalidHookId()
        {
            var hookId = "qwe";
            var response = Manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(NetworkCoin, hookId);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual($"Could not delete webhook with id: {hookId}", response.ErrorMessage);
            }
            else
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual(
                    "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.",
                    response.ErrorMessage);
            }
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}