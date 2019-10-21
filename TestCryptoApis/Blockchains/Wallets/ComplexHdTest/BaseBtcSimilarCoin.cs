using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApis.Blockchains.Wallets.ComplexHdTest
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
            var response = Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(
                NetworkCoin, walletName, addressCount, password);
            try
            {
                AssertNullErrorMessage(response);
                Assert.AreEqual(walletName, response.Wallet.Name);
                Assert.AreEqual(addressCount, response.Wallet.Addresses.Count);

                // GetWallets
                var getWalletsResponse = Manager.Blockchains.Wallet.GetHdWallets<GetHdWalletsResponse>(NetworkCoin);

                AssertNullErrorMessage(getWalletsResponse);
                AssertNotEmptyCollection(nameof(getWalletsResponse.Wallets), getWalletsResponse.Wallets);
                Assert.AreEqual(1, getWalletsResponse.Wallets.Count(w => w == walletName));

                // GetWalletInfo
                var getResponse = Manager.Blockchains.Wallet.GetHdWalletInfo<BtcHdWalletInfoResponse>(NetworkCoin, walletName);

                AssertNullErrorMessage(getResponse);
                Assert.AreEqual(walletName, getResponse.Wallet.Name);
                Assert.AreEqual(addressCount, getResponse.Wallet.Addresses.Count);

                // GenerateAddress
                var newAddressCount = 4;
                var generateResponse = Manager.Blockchains.Wallet.GenerateHdAddress<BtcHdWalletInfoResponse>(
                    NetworkCoin, walletName, newAddressCount, password);

                AssertNullErrorMessage(generateResponse);
                Assert.AreEqual(walletName, generateResponse.Wallet.Name);
                Assert.AreEqual(newAddressCount, generateResponse.Wallet.Addresses.Count);

                // GetWalletInfo2
                var getResponse2 = Manager.Blockchains.Wallet.GetHdWalletInfo<BtcHdWalletInfoResponse>(NetworkCoin, walletName);

                AssertNullErrorMessage(getResponse2);
                Assert.AreEqual(walletName, getResponse2.Wallet.Name);
                Assert.AreEqual(addressCount + newAddressCount, getResponse2.Wallet.Addresses.Count);
            }
            finally
            {
                // DeleteHdWallet
                var deleteResponse = Manager.Blockchains.Wallet.DeleteHdWallet<DeleteWalletResponse>(NetworkCoin, walletName);

                AssertNullErrorMessage(deleteResponse);
                Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
            }
        }

        [TestMethod]
        public void WeakPassword()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}WeakPasswordWallet";
            var addressCount = 3;
            var password = "123456";
            var response = Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(
                NetworkCoin, walletName, addressCount, password);

            AssertErrorMessage(response, "'password' is too weak. Min size is 10 characters, actual is 6");
        }

        [TestMethod]
        public void ExistingWallet()
        {
            var addressCount = 3;
            var password = "0123456789";
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}ExistingWallet";

            // Create the first wallet
            var response = Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(NetworkCoin, walletName, addressCount, password);
            try
            {
                AssertNullErrorMessage(response);
                Assert.AreEqual(walletName, response.Wallet.Name);

                // Create the second wallet
                var response2 = Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(NetworkCoin, walletName, addressCount, password);
                AssertErrorMessage(response2, $"Wallet '{walletName}' already exists");
            }
            finally
            {
                // DeleteWallet
                var deleteResponse = Manager.Blockchains.Wallet.DeleteHdWallet<DeleteWalletResponse>(NetworkCoin, walletName);
                AssertNullErrorMessage(deleteResponse);
                Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An address count was inappropriately allowed.")]
        public void EmptyAddresses()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}EmptyAddressesWallet";
            var password = "0123456789";
            var addressCount = -1;
            Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(NetworkCoin, walletName, addressCount, password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A password count was inappropriately allowed.")]
        public void NullPassword()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}NullPasswordWallet";
            string password = null;
            var addressCount = 3;
            Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(NetworkCoin, walletName, addressCount, password);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}