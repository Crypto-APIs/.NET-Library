using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.WebhookNotifications.CreateConfirmedTransaction
{
    [TestClass]
    public class BtcSimilarCoin : WebhookNotifications.BtcSimilarCoin
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin, string transactionHash)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            var confirmationCount = 6;

            var response = Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction<CreateBtcConfirmedTransactionWebHookResponse>(
                networkCoin, url, transactionHash, confirmationCount);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(response.Hook.Id),
                    $"'{nameof(response.Hook.Id)}' must not be null");
                AssertHook(networkCoin, response.Hook.Id);
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentNullException), "An Url of null was inappropriately allowed.")]
        public void NullUrl_Exception(NetworkCoin networkCoin, string transactionHash)
        {
            string nullUrl = null;
            var confirmationCount = 6;

            Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction<CreateBtcConfirmedTransactionWebHookResponse>(
                networkCoin, nullUrl, transactionHash, confirmationCount);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A TransactionHash of null was inappropriately allowed.")]
        public void NullTransactionHash_Exception(NetworkCoin networkCoin)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            string transactionHash = null;
            var confirmationCount = 6;

            Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction<CreateBtcConfirmedTransactionWebHookResponse>(
                networkCoin, url, transactionHash, confirmationCount);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A ConfirmationCount was inappropriately allowed.")]
        public void InvalidConfirmationCount_Exception(NetworkCoin networkCoin, string transactionHash)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            var confirmationCount = -6;

            Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction<CreateBtcConfirmedTransactionWebHookResponse>(
                networkCoin, url, transactionHash, confirmationCount);
        }

        private static IEnumerable<object[]> GetTestData
        {
            get
            {
                yield return new object[] { NetworkCoin.BchMainNet, Features.CorrectTransactionHash.BchMainNet };
                yield return new object[] { NetworkCoin.BchTestNet, Features.CorrectTransactionHash.BchTestNet };
                yield return new object[] { NetworkCoin.BtcMainNet, Features.CorrectTransactionHash.BtcMainNet };
                yield return new object[] { NetworkCoin.BtcTestNet, Features.CorrectTransactionHash.BtcTestNet };
                yield return new object[] { NetworkCoin.DashMainNet, Features.CorrectTransactionHash.DashMainNet };
                yield return new object[] { NetworkCoin.DashTestNet, Features.CorrectTransactionHash.DashTestNet };
                yield return new object[] { NetworkCoin.DogeMainNet, Features.CorrectTransactionHash.DogeMainNet };
                yield return new object[] { NetworkCoin.DogeTestNet, Features.CorrectTransactionHash.DogeTestNet };
                yield return new object[] { NetworkCoin.LtcMainNet, Features.CorrectTransactionHash.LtcMainNet };
                yield return new object[] { NetworkCoin.LtcTestNet, Features.CorrectTransactionHash.LtcTestNet };
            }
        }
    }
}