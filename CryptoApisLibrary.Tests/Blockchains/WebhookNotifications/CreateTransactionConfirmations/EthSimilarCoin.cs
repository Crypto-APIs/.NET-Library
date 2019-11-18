using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.WebhookNotifications.CreateTransactionConfirmations
{
    [TestClass]
    public class EthSimilarCoin : WebhookNotifications.EthSimilarCoin
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin, string address)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            var confirmationCount = 15;

            var response = Manager.Blockchains.WebhookNotification.CreateTransactionConfirmations<CreateTransactionConfirmationsResponse>(
                networkCoin, url, address, confirmationCount);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Id),
                    $"'{nameof(response.Payload.Id)}' must not be null");
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentNullException), "An Url of null was inappropriately allowed.")]
        public void NullUrl_Exception(NetworkCoin networkCoin, string address)
        {
            string nullUrl = null;
            var confirmationCount = 15;

            Manager.Blockchains.WebhookNotification.CreateTransactionConfirmations<CreateTransactionConfirmationsResponse>(
                networkCoin, nullUrl, address, confirmationCount);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress_Exception(NetworkCoin networkCoin)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            string address = null;
            var confirmationCount = 15;

            Manager.Blockchains.WebhookNotification.CreateTransactionConfirmations<CreateTransactionConfirmationsResponse>(
                networkCoin, url, address, confirmationCount);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A ConfirmationCount was inappropriately allowed.")]
        public void InvalidConfirmationCount_Exception(NetworkCoin networkCoin, string address)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            var confirmationCount = -15;

            Manager.Blockchains.WebhookNotification.CreateTransactionConfirmations<CreateTransactionConfirmationsResponse>(
                networkCoin, url, address, confirmationCount);
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