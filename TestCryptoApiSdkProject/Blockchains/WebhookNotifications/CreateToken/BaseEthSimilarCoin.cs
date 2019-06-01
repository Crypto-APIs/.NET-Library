using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.WebhookNotifications.CreateToken
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var address = Manager.Blockchains.Address.GenerateAddress(Coin, Network).Payload.Address;
            Assert.IsNotNull(address);

            var response = Manager.Blockchains.WebhookNotification.CreateToken(Coin, Network, Url, address);

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
            string url = null;
            var address = "some address";
            Manager.Blockchains.WebhookNotification.CreateToken(Coin, Network, url, address);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Url of null was inappropriately allowed.")]
        public void NullAddress()
        {
            string address = null;
            Manager.Blockchains.WebhookNotification.CreateToken(Coin, Network, Url, address);
        }

        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
        private string Url { get; } = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
    }
}