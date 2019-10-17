using System;
using System.Collections.Generic;
using System.Linq;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}GeneralWallet";
            var response = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(NetworkCoin, walletName, Addresses);

            AssertNullErrorMessage(response);
            Assert.AreEqual(walletName, response.Wallet.Name);

            // GetWallets
            var getWalletsResponse = Manager.Blockchains.Wallet.GetWallets<GetWalletsResponse>(NetworkCoin);
            AssertNullErrorMessage(getWalletsResponse);
            AssertNotEmptyCollection(nameof(getWalletsResponse.Wallets), getWalletsResponse.Wallets);
            Assert.AreEqual(1, getWalletsResponse.Wallets.Count(w => w == walletName));

            // GetWalletInfo
            var getResponse = Manager.Blockchains.Wallet.GetWalletInfo<WalletInfoResponse>(NetworkCoin, walletName);
            AssertNullErrorMessage(getResponse);
            Assert.AreEqual(walletName, getResponse.Wallet.Name);
            Assert.AreEqual(Addresses.Count, getResponse.Wallet.Addresses.Count);

            // AddAddress
            var addResponse = Manager.Blockchains.Wallet.AddAddress<WalletInfoResponse>(NetworkCoin, walletName, AddedAddresses);
            AssertNullErrorMessage(addResponse);
            Assert.AreEqual(walletName, addResponse.Wallet.Name);
            Assert.AreEqual(Addresses.Count + AddedAddresses.Count, addResponse.Wallet.Addresses.Count);

            // GenerateAddress
            var generateResponse = Manager.Blockchains.Wallet.GenerateAddress<GenerateWalletAddressResponse>(NetworkCoin, walletName);
            AssertNullErrorMessage(generateResponse);
            Assert.AreEqual(walletName, generateResponse.Payload.Wallet.Name);
            Assert.AreEqual(Addresses.Count + AddedAddresses.Count + 1, generateResponse.Payload.Wallet.Addresses.Count);

            // RemoveAddress
            var removingAddress = Addresses[0];
            var removeResponse = Manager.Blockchains.Wallet.RemoveAddress<RemoveAddressResponse>(NetworkCoin, walletName, removingAddress);
            AssertNullErrorMessage(removeResponse);
            Assert.AreEqual($"address {removingAddress} was successfully deleted!", removeResponse.Payload.Message);

            // DeleteWallet
            var deleteResponse = Manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(NetworkCoin, walletName);
            AssertNullErrorMessage(deleteResponse);
            Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
        }

        [TestMethod]
        public void InvalidAddress()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}InvalidAddressWallet";
            var addresses = new List<string>
            {
                "qwe"
            };
            var response = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(NetworkCoin, walletName, addresses);
            AssertErrorMessage(response, "'addresses' contains invalid address(es): qwe");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Addresses was inappropriately allowed.")]
        public void EmptyAddresses()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}EmptyAddressesWallet";
            var addresses = new List<string>();
            Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(NetworkCoin, walletName, addresses);
        }

        [TestMethod]
        public void ExistingWallet()
        {
            // Create the first wallet
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}ExistingWallet";
            var response = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(NetworkCoin, walletName, Addresses);

            AssertNullErrorMessage(response);
            Assert.AreEqual(walletName, response.Wallet.Name);

            // Create the second wallet
            var response2 = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(NetworkCoin, walletName, Addresses);
            AssertErrorMessage(response2, $"Wallet '{walletName}' already exists");

            // DeleteWallet
            var deleteResponse = Manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(NetworkCoin, walletName);
            AssertNullErrorMessage(deleteResponse);
            Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
        }

        [TestMethod]
        public void DuplicateAddresses()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}DuplicateAddressesWallet";
            var addresses = new List<string>();
            addresses.AddRange(Addresses);
            addresses.AddRange(Addresses);

            var response = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(NetworkCoin, walletName, addresses);

            Assert.AreEqual("'addresses' contains duplicate address(es)", response.ErrorMessage);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract List<string> Addresses { get; }
        protected abstract List<string> AddedAddresses { get; }
    }
}