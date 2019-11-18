using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Blockchains.Wallets.CreateXPub
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var correctPassword = "pass4wd##434#%^^word";

            var response = Manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(networkCoin, correctPassword);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Payload);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Xpub));
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A Password of null was inappropriately allowed.")]
        public void NullPassword_Exception(NetworkCoin networkCoin)
        {
            string password = null;

            Manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(networkCoin, password);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void IncorrectPassword_ErrorMessage(NetworkCoin networkCoin)
        {
            var password = "incorrect password";

            var response = Manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(networkCoin, password);

            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Payload);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Xpub));
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void WeakPassword_ErrorMessage(NetworkCoin networkCoin)
        {
            var password = "123";

            var response = Manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(networkCoin, password);

            AssertErrorMessage(response, "'password' is too weak. Min size is 10 characters, actual is 3");
            Assert.IsNull(response.Payload);
        }
    }
}