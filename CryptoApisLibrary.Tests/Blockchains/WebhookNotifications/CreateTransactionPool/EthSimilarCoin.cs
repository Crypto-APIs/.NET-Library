using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.WebhookNotifications.CreateTransactionPool
{
    [TestClass]
    public class EthSimilarCoin : WebhookNotifications.EthSimilarCoin
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin, string address)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";

            var response = Manager.Blockchains.WebhookNotification.CreateTransactionPool<EthWebHookResponse>(
                networkCoin, url, address);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(response.Hook.Id),
                    $"'{nameof(response.Hook.Id)}' must not be null");
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentNullException), "An Url of null was inappropriately allowed.")]
        public void NullUrl_Exception(NetworkCoin networkCoin, string address)
        {
            string url = null;

            Manager.Blockchains.WebhookNotification.CreateTransactionPool<EthWebHookResponse>(networkCoin, url, address);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress_Exception(NetworkCoin networkCoin)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            string address = null;

            Manager.Blockchains.WebhookNotification.CreateTransactionPool<EthWebHookResponse>(networkCoin, url, address);
        }

        private static IEnumerable<object[]> GetTestData
        {
            get
            {
                yield return new object[] { NetworkCoin.EthMainNet, Features.CorrectAddress.EthMainNet };
                yield return new object[] { NetworkCoin.EthRinkeby, Features.CorrectAddress.EthRinkenby };
                yield return new object[] { NetworkCoin.EthRopsten, Features.CorrectAddress.EthRopsten };
                yield return new object[] { NetworkCoin.EtcMainNet, Features.CorrectAddress.EtcMainNet };
                yield return new object[] { NetworkCoin.EtcMorden, Features.CorrectAddress.EtcMorden };
            }
        }
    }
}