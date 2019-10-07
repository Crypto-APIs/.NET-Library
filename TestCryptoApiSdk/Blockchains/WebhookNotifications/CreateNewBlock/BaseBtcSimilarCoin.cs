using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdk.Blockchains.WebhookNotifications.CreateNewBlock
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.WebhookNotification.CreateNewBlock<BtcWebHookResponse>(NetworkCoin, Url);

            AssertNotNullResponse(response);
            if (IsAdditionalPackagePlan)
            {
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Id));
            }
            else
            {
                AssertErrorMessage(response, "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Url of null was inappropriately allowed.")]
        public void NullUrl()
        {
            string url = null;
            Manager.Blockchains.WebhookNotification.CreateNewBlock<BtcWebHookResponse>(NetworkCoin, url);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        private string Url { get; } = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
    }
}