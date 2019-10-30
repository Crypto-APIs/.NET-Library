using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.WebhookNotifications.DeleteAllHooks
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var response = Manager.Blockchains.WebhookNotification.CreateNewBlock<BtcWebHookResponse>(NetworkCoin, Url);
            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Id), $"'{nameof(response.Payload.Id)}' must not be null");

            var deleteResponse = Manager.Blockchains.WebhookNotification.DeleteAll<DeleteAllWebhookResponse>(NetworkCoin);
            AssertNullErrorMessage(deleteResponse);
            Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message),
                $"'{nameof(deleteResponse.Payload.Message)}' must not be null");
            Assert.AreEqual("All Webhooks were successfully deleted!", deleteResponse.Payload.Message);

            var secondResponse = Manager.Blockchains.WebhookNotification.GetHooks<GetBtcHooksResponse>(NetworkCoin);
            AssertNullErrorMessage(secondResponse);
            AssertEmptyCollection(nameof(secondResponse.Hooks), secondResponse.Hooks);

            var secondDeleteResponse = Manager.Blockchains.WebhookNotification.DeleteAll<DeleteAllWebhookResponse>(NetworkCoin);
            AssertNullErrorMessage(secondDeleteResponse);
            Assert.IsFalse(string.IsNullOrEmpty(secondDeleteResponse.Payload.Message),
                $"'{nameof(secondDeleteResponse.Payload.Message)}' must not be null");
            Assert.AreEqual("No existing Webhook subscription found!", secondDeleteResponse.Payload.Message);
        }

        private string Url { get; } = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
        protected abstract NetworkCoin NetworkCoin { get; }
    }
}