using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdkProject.Blockchains.WebhookNotifications.CreateAddressGetDelete
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var address = Manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(NetworkCoin).Payload.Address;
            Assert.IsNotNull(address);
            var response = Manager.Blockchains.WebhookNotification.CreateAddress<CreateBtcAddressWebHookResponse>(NetworkCoin, Url, address);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Id));
            var hookId = response.Payload.Id;

            try
            {
                var getHookResponse = Manager.Blockchains.WebhookNotification.GetHooks<GetBtcHooksResponse>(NetworkCoin);
                Assert.IsTrue(string.IsNullOrEmpty(getHookResponse.ErrorMessage));
                Assert.IsTrue(getHookResponse.Hooks.Any());
                Assert.IsNotNull(getHookResponse.Hooks.FirstOrDefault(h => h.Id.Equals(hookId, StringComparison.OrdinalIgnoreCase)));
            }
            finally
            {
                var deleteResponse = Manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(NetworkCoin, hookId);
                Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message));
                Assert.AreEqual($"Webhook with id: {hookId} was successfully deleted!", deleteResponse.Payload.Message);
            }
        }

        [TestMethod]
        public void InvalidAddress()
        {
            var address = "qwe";
            var response = Manager.Blockchains.WebhookNotification.CreateAddress<CreateBtcAddressWebHookResponse>(NetworkCoin, Url, address);

            Assert.IsNotNull(response);
            if (IsAdditionalPackagePlan)
            {
                Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
                Assert.AreEqual("Field 'address' is not valid", response.ErrorMessage);
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
            var address = "some address";
            Manager.Blockchains.WebhookNotification.CreateAddress<CreateBtcAddressWebHookResponse>(NetworkCoin, nullUrl, address);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string address = null;
            Manager.Blockchains.WebhookNotification.CreateAddress<CreateBtcAddressWebHookResponse>(NetworkCoin, Url, address);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        private string Url { get; } = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
    }
}