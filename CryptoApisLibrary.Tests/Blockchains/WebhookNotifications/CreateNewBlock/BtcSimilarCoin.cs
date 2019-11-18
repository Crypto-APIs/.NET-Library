using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Blockchains.WebhookNotifications.CreateNewBlock
{
    [TestClass]
    public class BtcSimilarCoin : WebhookNotifications.BtcSimilarCoin
    {
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";

            var response = Manager.Blockchains.WebhookNotification.CreateNewBlock<BtcWebHookResponse>(networkCoin, url);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(response.Hook.Id),
                    $"'{nameof(response.Hook.Id)}' must not be null");
                AssertHook(networkCoin, response.Hook.Id);
            }
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A Url of null was inappropriately allowed.")]
        public void NullUrl_Exception(NetworkCoin networkCoin)
        {
            string url = null;

            Manager.Blockchains.WebhookNotification.CreateNewBlock<BtcWebHookResponse>(networkCoin, url);
        }
    }
}