using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApis.Blockchains.Wallets.ImportAddressAsWallet
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [Ignore] // todo: need corrected private key
        [TestMethod]
        public void GeneralTest()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}GeneralTest";
            var privateKey = GetCorrectedPrivateKey();
            var response = Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                NetworkCoin, walletName, Password, privateKey, Address);
            AssertNullErrorMessage(response);
        }

        private string GetCorrectedPrivateKey()
        {
            /* it is an another private key, I don't know what.
            var response = Manager.Blockchains.Wallet.CreateXPub<CreateXPubResponse>(NetworkCoin, Password);
            AssertNullErrorMessage(response);
            Assert.IsNotNull(response.Payload);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Xpriv));
            return response.Payload.Xpriv;
            */

            return "qwe";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A WalletName of null was inappropriately allowed.")]
        public void NullWalletName()
        {
            string walletName = null;
            Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                NetworkCoin, walletName, Password, PrivateKey, Address);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Password of null was inappropriately allowed.")]
        public void NullPassword()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}NullPassword";
            string password = null;
            Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                NetworkCoin, walletName, password, PrivateKey, Address);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A PrivateKey of null was inappropriately allowed.")]
        public void NullPrivateKey()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}NullPrivateKey";
            string privateKey = null;
            Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                NetworkCoin, walletName, Password, privateKey, Address);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}NullAddress";
            string address = null;
            Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                NetworkCoin, walletName, Password, PrivateKey, address);
        }

        [TestMethod]
        public void IncorrectPrivateKey()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}IncorrectPrivateKey";
            var privateKey = "incorrect privateKey";
            var response = Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                NetworkCoin, walletName, Password, privateKey, Address);
            AssertErrorMessage(response, "Invalid private key");
            Assert.IsNull(response.Payload, $"'{nameof(response.Payload)}' must be null");
        }

        [TestMethod]
        public void IncorrectAddress()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}IncorrectAddress";
            var address = "Any address";
            var response = Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                NetworkCoin, walletName, Password, PrivateKey, address);
            AssertErrorMessage(response, "Address is not valid");
            Assert.IsNull(response.Payload, $"'{nameof(response.Payload)}' must be null");
        }

        private string Password { get; } = "pass4wd##434#%^^word";

        private string PrivateKey { get; } = "Any private key";

        protected abstract string Address { get; }
        protected abstract NetworkCoin NetworkCoin { get; }
    }
}