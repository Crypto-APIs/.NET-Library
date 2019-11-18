using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Blockchains.Wallets.GetXPubChangeAddresses
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var xpub = GetXPub(networkCoin);
            var startIndex = 0;
            var finishIndex = 10;

            var getResponse = Manager.Blockchains.Wallet.GetXPubChangeAddresses<GetXPubAddressesResponse>(
                networkCoin, xpub, startIndex, finishIndex);

            AssertNullErrorMessage(getResponse);
            Assert.IsNotNull(getResponse.Addresses);
            Assert.AreEqual(finishIndex - startIndex, getResponse.Addresses.Count);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A XPub of null was inappropriately allowed.")]
        public void NullXPub_Exception(NetworkCoin networkCoin)
        {
            string xpub = null;
            var startIndex = 0;
            var finishIndex = 10;

            Manager.Blockchains.Wallet.GetXPubChangeAddresses<GetXPubAddressesResponse>(networkCoin, xpub, startIndex, finishIndex);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A StartIndex was inappropriately allowed.")]
        public void NegativeStartIndex_Exception(NetworkCoin networkCoin)
        {
            var xPub = "Any xpub (does not affect the test result)";
            var startIndex = -1;
            var finishIndex = 10;

            Manager.Blockchains.Wallet.GetXPubChangeAddresses<GetXPubAddressesResponse>(networkCoin, xPub, startIndex, finishIndex);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A FinishIndex was inappropriately allowed.")]
        public void NegativeFinishIndex_Exception(NetworkCoin networkCoin)
        {
            var xPub = "Any xpub (does not affect the test result)";
            var startIndex = 0;
            var finishIndex = 0;

            Manager.Blockchains.Wallet.GetXPubChangeAddresses<GetXPubAddressesResponse>(networkCoin, xPub, startIndex, finishIndex);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A StartIndex must not be equal FinishIndex.")]
        public void IndexesEquals_Exception(NetworkCoin networkCoin)
        {
            var xPub = "Any xpub (does not affect the test result)";
            var startIndex = 10;
            var finishIndex = 10;

            Manager.Blockchains.Wallet.GetXPubChangeAddresses<GetXPubAddressesResponse>(networkCoin, xPub, startIndex, finishIndex);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void IncorrectXPub_ErrorMessage(NetworkCoin networkCoin)
        {
            var xpub = "incorrect xpub";
            var startIndex = 0;
            var finishIndex = 10;

            var response = Manager.Blockchains.Wallet.GetXPubChangeAddresses<GetXPubAddressesResponse>(
                networkCoin, xpub, startIndex, finishIndex);

            AssertErrorMessage(response, "Invalid XPUB");
            Assert.IsNotNull(response.Addresses, $"'{nameof(response.Addresses)}' must be null");
            Assert.AreEqual(0, response.Addresses.Count, $"'{nameof(response.ErrorMessage)}.Count' must be 0, but is was '{response.Addresses.Count}'");
        }

        private string GetXPub(NetworkCoin networkCoin)
        {
            var password = "pass4wd##434#%^^word";

            var response = Manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(networkCoin, password);

            Assert.IsNotNull(response.Payload);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Xpub));
            return response.Payload.Xpub;
        }
    }
}