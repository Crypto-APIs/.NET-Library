using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CryptoApisLibrary.Tests.Blockchains.Wallets.ComplexHdTest
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void GeneralTestNetworkCoin(NetworkCoin networkCoin)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}GeneralWallet";
            var addressCount = 3;
            var password = "0123456789";
            var response = Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(
                networkCoin, walletName, addressCount, password);
            try
            {
                AssertNullErrorMessage(response);
                Assert.AreEqual(walletName, response.Wallet.Name);
                Assert.AreEqual(addressCount, response.Wallet.Addresses.Count);

                // GetWallets
                var getWalletsResponse = Manager.Blockchains.Wallet.GetHdWallets<GetHdWalletsResponse>(networkCoin);

                AssertNullErrorMessage(getWalletsResponse);
                AssertNotEmptyCollection(nameof(getWalletsResponse.Wallets), getWalletsResponse.Wallets);
                Assert.AreEqual(1, getWalletsResponse.Wallets.Count(w => w == walletName));

                // GetWalletInfo
                var getResponse = Manager.Blockchains.Wallet.GetHdWalletInfo<BtcHdWalletInfoResponse>(networkCoin, walletName);

                AssertNullErrorMessage(getResponse);
                Assert.AreEqual(walletName, getResponse.Wallet.Name);
                Assert.AreEqual(addressCount, getResponse.Wallet.Addresses.Count);

                // GenerateAddress
                var newAddressCount = 4;
                var generateResponse = Manager.Blockchains.Wallet.GenerateHdAddress<BtcHdWalletInfoResponse>(
                    networkCoin, walletName, newAddressCount, password);

                AssertNullErrorMessage(generateResponse);
                Assert.AreEqual(walletName, generateResponse.Wallet.Name);
                Assert.AreEqual(newAddressCount, generateResponse.Wallet.Addresses.Count);

                // GetWalletInfo2
                var getResponse2 = Manager.Blockchains.Wallet.GetHdWalletInfo<BtcHdWalletInfoResponse>(networkCoin, walletName);

                AssertNullErrorMessage(getResponse2);
                Assert.AreEqual(walletName, getResponse2.Wallet.Name);
                Assert.AreEqual(addressCount + newAddressCount, getResponse2.Wallet.Addresses.Count);
            }
            finally
            {
                // DeleteHdWallet
                var deleteResponse = Manager.Blockchains.Wallet.DeleteHdWallet<DeleteWalletResponse>(networkCoin, walletName);

                AssertNullErrorMessage(deleteResponse);
                Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
            }
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void WeakPassword_ErrorMessage(NetworkCoin networkCoin)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}WeakPasswordWallet";
            var addressCount = 3;
            var password = "123456";

            var response = Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(
                networkCoin, walletName, addressCount, password);

            AssertErrorMessage(response, "'password' is too weak. Min size is 10 characters, actual is 6");
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void ExistingWallet_ErrorMessage(NetworkCoin networkCoin)
        {
            var addressCount = 3;
            var password = "0123456789";
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}ExistingWallet";

            // Create the first wallet
            var response = Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(networkCoin, walletName, addressCount, password);
            try
            {
                AssertNullErrorMessage(response);
                Assert.AreEqual(walletName, response.Wallet.Name);

                // Create the second wallet
                var response2 = Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(networkCoin, walletName, addressCount, password);
                AssertErrorMessage(response2, $"Wallet '{walletName}' already exists");
            }
            finally
            {
                // DeleteWallet
                var deleteResponse = Manager.Blockchains.Wallet.DeleteHdWallet<DeleteWalletResponse>(networkCoin, walletName);
                AssertNullErrorMessage(deleteResponse);
                Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
            }
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "An address count was inappropriately allowed.")]
        public void EmptyAddresses_Exception(NetworkCoin networkCoin)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}EmptyAddressesWallet";
            var password = "0123456789";
            var addressCount = -1;

            Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(networkCoin, walletName, addressCount, password);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A password count was inappropriately allowed.")]
        public void NullPassword_Exception(NetworkCoin networkCoin)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}NullPasswordWallet";
            string password = null;
            var addressCount = 3;

            Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(networkCoin, walletName, addressCount, password);
        }
    }
}