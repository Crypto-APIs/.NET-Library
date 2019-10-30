using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApis.Blockchains.Wallets.GetXPubReceiveAddresses
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var xpub = GetXPub();
            var startIndex = 0;
            var finishIndex = 10;
            var getResponse = Manager.Blockchains.Wallet.GetXPubReceiveAddresses<GetXPubAddressesResponse>(
                NetworkCoin, xpub, startIndex, finishIndex);
            AssertNullErrorMessage(getResponse);
            Assert.IsNotNull(getResponse.Addresses);
            Assert.AreEqual(finishIndex - startIndex, getResponse.Addresses.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A XPub of null was inappropriately allowed.")]
        public void NullXPub()
        {
            string xpub = null;
            Manager.Blockchains.Wallet.GetXPubReceiveAddresses<GetXPubAddressesResponse>(NetworkCoin, xpub, StartIndex, FinishIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A StartIndex was inappropriately allowed.")]
        public void NegativeStartIndex()
        {
            var startIndex = -1;
            Manager.Blockchains.Wallet.GetXPubReceiveAddresses<GetXPubAddressesResponse>(NetworkCoin, XPub, startIndex, FinishIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A FinishIndex was inappropriately allowed.")]
        public void NegativeFinishIndex()
        {
            var finishIndex = 0;
            Manager.Blockchains.Wallet.GetXPubReceiveAddresses<GetXPubAddressesResponse>(NetworkCoin, XPub, StartIndex, finishIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A StartIndex must not be equal FinishIndex.")]
        public void IndexesEquals()
        {
            var startIndex = 10;
            var finishIndex = 10;
            Manager.Blockchains.Wallet.GetXPubReceiveAddresses<GetXPubAddressesResponse>(NetworkCoin, XPub, startIndex, finishIndex);
        }

        [TestMethod]
        public void IncorrectXPub()
        {
            var xpub = "incorrect xpub";
            var response = Manager.Blockchains.Wallet.GetXPubReceiveAddresses<GetXPubAddressesResponse>(
                NetworkCoin, xpub, StartIndex, FinishIndex);
            AssertErrorMessage(response, "Invalid XPUB");
            Assert.IsNotNull(response.Addresses, $"'{nameof(response.Addresses)}' must be null");
            Assert.AreEqual(0, response.Addresses.Count, $"'{nameof(response.ErrorMessage)}.Count' must be 0, but is was '{response.Addresses.Count}'");
        }

        private string GetXPub()
        {
            var response = Manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(NetworkCoin, Password);
            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Payload);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Xpub));
            return response.Payload.Xpub;
        }

        private string Password { get; } = "pass4wd##434#%^^word";
        private string XPub = "Any xpub";
        private int StartIndex = 0;
        private int FinishIndex = 10;
        protected abstract NetworkCoin NetworkCoin { get; }
    }
}