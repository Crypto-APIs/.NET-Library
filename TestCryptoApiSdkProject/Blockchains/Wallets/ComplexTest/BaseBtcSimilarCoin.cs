using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCryptoApiSdkProject.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}GeneralWallet";
            var response = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(NetworkCoin, walletName, Addresses);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(walletName, response.Wallet.Name);

            // GetWallets
            var getWalletsResponse = Manager.Blockchains.Wallet.GetWallets<GetWalletsResponse>(NetworkCoin);

            Assert.IsNotNull(getWalletsResponse);
            Assert.IsTrue(string.IsNullOrEmpty(getWalletsResponse.ErrorMessage));
            Assert.IsTrue(getWalletsResponse.Wallets.Any());
            Assert.AreEqual(1, getWalletsResponse.Wallets.Count(w => w == walletName));

            // GetWalletInfo
            var getResponse = Manager.Blockchains.Wallet.GetWalletInfo<WalletInfoResponse>(NetworkCoin, walletName);

            Assert.IsNotNull(getResponse);
            Assert.IsTrue(string.IsNullOrEmpty(getResponse.ErrorMessage));
            Assert.AreEqual(walletName, getResponse.Wallet.Name);
            Assert.AreEqual(Addresses.Count, getResponse.Wallet.Addresses.Count);

            // AddAddress
            var addResponse = Manager.Blockchains.Wallet.AddAddress<WalletInfoResponse>(NetworkCoin, walletName, AddedAddresses);

            Assert.IsNotNull(addResponse);
            Assert.IsTrue(string.IsNullOrEmpty(addResponse.ErrorMessage));
            Assert.AreEqual(walletName, addResponse.Wallet.Name);
            Assert.AreEqual(Addresses.Count + AddedAddresses.Count, addResponse.Wallet.Addresses.Count);

            // GenerateAddress
            var generateResponse = Manager.Blockchains.Wallet.GenerateAddress<GenerateWalletAddressResponse>(NetworkCoin, walletName);

            Assert.IsNotNull(generateResponse);
            Assert.IsTrue(string.IsNullOrEmpty(generateResponse.ErrorMessage));
            Assert.AreEqual(walletName, generateResponse.Payload.Wallet.Name);
            Assert.AreEqual(Addresses.Count + AddedAddresses.Count + 1, generateResponse.Payload.Wallet.Addresses.Count);

            // RemoveAddress
            var removingAddress = Addresses[0];
            var removeResponse = Manager.Blockchains.Wallet.RemoveAddress<RemoveAddressResponse>(NetworkCoin, walletName, removingAddress);

            Assert.IsNotNull(removeResponse);
            Assert.IsTrue(string.IsNullOrEmpty(removeResponse.ErrorMessage));
            Assert.AreEqual($"address {removingAddress} was successfully deleted!", removeResponse.Payload.Message);

            // DeleteWallet
            var deleteResponse = Manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(NetworkCoin, walletName);

            Assert.IsNotNull(deleteResponse);
            Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
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

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("'addresses' contains invalid address(es): qwe", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Addresses was inappropriately allowed.")]
        public void EmptyAddresses()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}EmptyAddressesWallet";
            Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(NetworkCoin, walletName, addresses: new List<string>());
        }

        [TestMethod]
        public void ExistingWallet()
        {
            // Create the first wallet
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}ExistingWallet";
            var response = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(NetworkCoin, walletName, Addresses);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(walletName, response.Wallet.Name);

            // Create the second wallet
            var response2 = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(NetworkCoin, walletName, Addresses);

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
        public void DuplicateAddresses()
        {
            var walletName = $"{NetworkCoin.Coin}{NetworkCoin.Network}DuplicateAddressesWallet";
            var addresses = new List<string>();
            addresses.AddRange(Addresses);
            addresses.AddRange(Addresses);

            var response = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(NetworkCoin, walletName, addresses);

            Assert.IsNotNull(response);
            Assert.AreEqual("'addresses' contains duplicate address(es)", response.ErrorMessage);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract List<string> Addresses { get; }
        protected abstract List<string> AddedAddresses { get; }
    }
}