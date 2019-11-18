using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.WebhookNotifications.CreateConfirmedTransaction
{
    [TestClass]
    public class EthSimilarCoin : WebhookNotifications.EthSimilarCoin
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin, string transactionHash)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            var confirmationCount = 15;

            var response = Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction<CreateEthConfirmedTransactionWebHookResponse>(
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
            var confirmationCount = 15;

            Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction<CreateEthConfirmedTransactionWebHookResponse>(
                networkCoin, nullUrl, transactionHash, confirmationCount);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A TransactionHash of null was inappropriately allowed.")]
        public void NullTransactionHash_Exception(NetworkCoin networkCoin)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            string transactionHash = null;
            var confirmationCount = 15;

            Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction<CreateEthConfirmedTransactionWebHookResponse>(
                networkCoin, url, transactionHash, confirmationCount);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A ConfirmationCount was inappropriately allowed.")]
        public void InvalidConfirmationCount_Exception(NetworkCoin networkCoin, string transactionHash)
        {
            var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";
            var confirmationCount = -15;

            Manager.Blockchains.WebhookNotification.CreateConfirmedTransaction<CreateEthConfirmedTransactionWebHookResponse>(
                networkCoin, url, transactionHash, confirmationCount);
        }

        private static IEnumerable<object[]> GetTestData
        {
            get
            {
                yield return new object[] { NetworkCoin.EthMainNet, Features.CorrectTransactionHash.EthMainNet };
                yield return new object[] { NetworkCoin.EthRinkeby, Features.CorrectTransactionHash.EthRinkenby };
                yield return new object[] { NetworkCoin.EthRopsten, Features.CorrectTransactionHash.EthRopsten };
                yield return new object[] { NetworkCoin.EtcMainNet, Features.CorrectTransactionHash.EtcMainNet };
                yield return new object[] { NetworkCoin.EtcMorden, Features.CorrectTransactionHash.EtcMorden };
            }
        }
    }
}