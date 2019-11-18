using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Blockchains.WebhookNotifications.CreateToken
{
    [TestClass]
    public class EthSimilarCoin : WebhookNotifications.EthSimilarCoin
    {
        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var address = Manager.Blockchains.Address.GenerateAddress<GenerateEthAddressResponse>(networkCoin)?.Payload?.Address;
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";

            var response = Manager.Blockchains.WebhookNotification.CreateToken<CreateEthAddressWebHookResponse>(networkCoin, url, address);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(response.Hook.Id),
                    $"'{nameof(response.Hook.Id)}' must not be null");
                AssertHook(networkCoin, response.Hook.Id);
            }
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A Url of null was inappropriately allowed.")]
        public void NullUrl(NetworkCoin networkCoin)
        {
            string url = null;
            var address = "some add'ress";

            Manager.Blockchains.WebhookNotification.CreateToken<CreateEthAddressWebHookResponse>(networkCoin, url, address);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A Url of null was inappropriately allowed.")]
        public void NullAddress(NetworkCoin networkCoin)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            string address = null;

            Manager.Blockchains.WebhookNotification.CreateToken<CreateEthAddressWebHookResponse>(networkCoin, url, address);
        }
    }
}