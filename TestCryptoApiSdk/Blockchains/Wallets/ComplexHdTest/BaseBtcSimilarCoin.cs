using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdk.Blockchains.Wallets.ComplexHdTest
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}GeneralWallet";
            var addressCount = 3;
            var password = "0123456789";
            var response = Manager.Blockchains.Wallet.CreateHdWallet<HdWalletInfoResponse>(NetworkCoin, walletName, addressCount, password);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.AreEqual(walletName, response.Wallet.Name);
            Assert.AreEqual(addressCount, response.Wallet.Addresses.Count);

            // GetWallets
            var getWalletsResponse = Manager.Blockchains.Wallet.GetHdWallets<GetHdWalletsResponse>(NetworkCoin);

            Assert.IsNotNull(getWalletsResponse);
            Assert.IsTrue(string.IsNullOrEmpty(getWalletsResponse.ErrorMessage));
            Assert.IsTrue(getWalletsResponse.Wallets.Any(), "Collection must not be empty");
            Assert.AreEqual(1, getWalletsResponse.Wallets.Count(w => w == walletName));

            // GetWalletInfo
            var getResponse = Manager.Blockchains.Wallet.GetHdWalletInfo<HdWalletInfoResponse>(NetworkCoin, walletName);

            Assert.IsNotNull(getResponse);
            Assert.IsTrue(string.IsNullOrEmpty(getResponse.ErrorMessage));
            Assert.AreEqual(walletName, getResponse.Wallet.Name);
            Assert.AreEqual(addressCount, getResponse.Wallet.Addresses.Count);

            // GenerateAddress
            var newAddressCount = 4;
            var generateResponse = Manager.Blockchains.Wallet.GenerateHdAddress<HdWalletInfoResponse>(
                NetworkCoin, walletName, newAddressCount, password);

            Assert.IsNotNull(generateResponse);
            Assert.IsTrue(string.IsNullOrEmpty(generateResponse.ErrorMessage));
            Assert.AreEqual(walletName, generateResponse.Wallet.Name);
            Assert.AreEqual(addressCount + newAddressCount, generateResponse.Wallet.Addresses.Count);

            // DeleteHdWallet
            var deleteResponse = Manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(NetworkCoin, walletName);

            Assert.IsNotNull(deleteResponse);
            Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
            Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
        }

        [TestMethod]
        public void WeakPassword()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}WeakPasswordWallet";
            var addressCount = 3;
            var password = "123456";
            var response = Manager.Blockchains.Wallet.CreateHdWallet<HdWalletInfoResponse>(NetworkCoin, walletName, addressCount, password);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "'password' is too weak. Min size is 10 characters, actual is 6");
        }

        [TestMethod]
        public void ExistingWallet()
        {
            var addressCount = 3;
            var password = "0123456789";
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}ExistingWallet";

            // Create the first wallet
            var response = Manager.Blockchains.Wallet.CreateHdWallet<HdWalletInfoResponse>(NetworkCoin, walletName, addressCount, password);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.AreEqual(walletName, response.Wallet.Name);

            // Create the second wallet
            var response2 = Manager.Blockchains.Wallet.CreateHdWallet<HdWalletInfoResponse>(NetworkCoin, walletName, addressCount, password);

            Assert.IsNotNull(response2);
            Assert.IsFalse(string.IsNullOrEmpty(response2.ErrorMessage));
            Assert.AreEqual($"Wallet '{walletName}' already exists", response2.ErrorMessage);

            // DeleteWallet
            var deleteResponse = Manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(NetworkCoin, walletName);

            Assert.IsNotNull(deleteResponse);
            Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
            Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An address count was inappropriately allowed.")]
        public void EmptyAddresses()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}EmptyAddressesWallet";
            var password = "0123456789";
            Manager.Blockchains.Wallet.CreateHdWallet<HdWalletInfoResponse>(NetworkCoin, walletName, -1, password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A password count was inappropriately allowed.")]
        public void NullPassword()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}NullPasswordWallet";
            Manager.Blockchains.Wallet.CreateHdWallet<HdWalletInfoResponse>(NetworkCoin, walletName, 3, password: null);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}