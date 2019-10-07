using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdk.Blockchains.WebhookNotifications.CreateToken
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var address = Manager.Blockchains.Address.GenerateAddress<GenerateEthAddressResponse>(NetworkCoin).Payload.Address;
            Assert.IsNotNull(address);

            var response = Manager.Blockchains.WebhookNotification.CreateToken<CreateEthAddressWebHookResponse>(NetworkCoin, Url, address);

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
            var address = "some address";
            Manager.Blockchains.WebhookNotification.CreateToken<CreateEthAddressWebHookResponse>(NetworkCoin, url, address);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Url of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string address = null;
            Manager.Blockchains.WebhookNotification.CreateToken<CreateEthAddressWebHookResponse>(NetworkCoin, Url, address);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        private string Url { get; } = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
    }
}