using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Blockchains.WebhookNotifications.CreateAddressGetDelete
{
    [TestClass]
    public class BtcSimilarCoin : WebhookNotifications.BtcSimilarCoin
    {
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var address = Manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(networkCoin)?.Payload?.Address;
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";

            var response = Manager.Blockchains.WebhookNotification.CreateAddress<CreateBtcAddressWebHookResponse>(networkCoin, url, address);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(response.Hook.Id), $"'{nameof(response.Hook.Id)}' must not be null");
                AssertHook(networkCoin, response.Hook.Id);
            }
        }
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "An Url of null was inappropriately allowed.")]
        public void NullUrl_Exception(NetworkCoin networkCoin)
        {
            string nullUrl = null;
            var address = "some address";

            Manager.Blockchains.WebhookNotification.CreateAddress<CreateBtcAddressWebHookResponse>(networkCoin, nullUrl, address);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress_Exception(NetworkCoin networkCoin)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            string address = null;

            Manager.Blockchains.WebhookNotification.CreateAddress<CreateBtcAddressWebHookResponse>(networkCoin, url, address);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void InvalidAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            var address = "qw'e";

            var response = Manager.Blockchains.WebhookNotification.CreateAddress<CreateBtcAddressWebHookResponse>(
                networkCoin, url, address);

            AssertErrorMessage(response, IsAdditionalPackagePlan
                ? "Field 'address' is not valid"
                : "This endpoint has not been enabled for your package plan. Please contact us if you need this or upgrade your plan.");
        }
    }
}