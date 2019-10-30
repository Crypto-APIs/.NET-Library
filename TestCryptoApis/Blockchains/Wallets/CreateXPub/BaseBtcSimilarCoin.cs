using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApis.Blockchains.Wallets.CreateXPub
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(NetworkCoin, Password);
            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Payload);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Xpub));
            var xpub = response.Payload.Xpub;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Password of null was inappropriately allowed.")]
        public void NullPassword()
        {
            string password = null;
            Manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(NetworkCoin, password);
        }

        [TestMethod]
        public void IncorrectPassword()
        {
            var password = "incorrect password";
            var response = Manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(NetworkCoin, password);
            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Payload);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Xpub));
        }

        [TestMethod]
        public void WeakPassword()
        {
            var password = "123";
            var response = Manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(NetworkCoin, password);
            AssertErrorMessage(response, "'password' is too weak. Min size is 10 characters, actual is 3");
            Assert.IsNull(response.Payload);
        }

        private string Password { get; } = "pass4wd##434#%^^word";
        protected abstract NetworkCoin NetworkCoin { get; }
    }
}