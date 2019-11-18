using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.WebhookNotifications.CreateTransactionConfirmations
{
    [TestClass]
    public class BtcSimilarCoin : WebhookNotifications.BtcSimilarCoin
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin, string address)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            var confirmationCount = 6;

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
            var confirmationCount = 6;

            Manager.Blockchains.WebhookNotification.CreateTransactionConfirmations<CreateTransactionConfirmationsResponse>(
                networkCoin, nullUrl, address, confirmationCount);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress_Exception(NetworkCoin networkCoin)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            string address = null;
            var confirmationCount = 6;

            Manager.Blockchains.WebhookNotification.CreateTransactionConfirmations<CreateTransactionConfirmationsResponse>(
                networkCoin, url, address, confirmationCount);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A ConfirmationCount was inappropriately allowed.")]
        public void InvalidConfirmationCount_Exception(NetworkCoin networkCoin, string address)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            var confirmationCount = -6;

            Manager.Blockchains.WebhookNotification.CreateTransactionConfirmations<CreateTransactionConfirmationsResponse>(
                networkCoin, url, address, confirmationCount);
        }

        private static IEnumerable<object[]> GetTestData
        {
            get
            {
                yield return new object[] { NetworkCoin.BchMainNet, Features.CorrectAddress.BchMainNet };
                yield return new object[] { NetworkCoin.BchTestNet, Features.CorrectAddress.BchTestNet };
                yield return new object[] { NetworkCoin.BtcMainNet, Features.CorrectAddress.BtcMainNet };
                yield return new object[] { NetworkCoin.BtcTestNet, Features.CorrectAddress.BtcTestNet };
                yield return new object[] { NetworkCoin.DashMainNet, Features.CorrectAddress.DashMainNet };
                yield return new object[] { NetworkCoin.DashTestNet, Features.CorrectAddress.DashTestNet };
                yield return new object[] { NetworkCoin.DogeMainNet, Features.CorrectAddress.DogeMainNet };
                yield return new object[] { NetworkCoin.DogeTestNet, Features.CorrectAddress.DogeTestNet };
                yield return new object[] { NetworkCoin.LtcMainNet, Features.CorrectAddress.LtcMainNet };
                yield return new object[] { NetworkCoin.LtcTestNet, Features.CorrectAddress.LtcTestNet };
            }
        }
    }
}