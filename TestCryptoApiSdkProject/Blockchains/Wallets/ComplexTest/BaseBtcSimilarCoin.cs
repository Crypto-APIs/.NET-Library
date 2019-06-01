using System;
using System.Collections.Generic;
using System.Linq;
using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var walletName = $"{Coin}{Network}GeneralWallet";
            var response = Manager.Blockchains.Wallet.CreateWallet(Coin, Network, walletName, Addresses);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(walletName, response.Wallet.Name);

            // GetWallets
            var getWalletsResponse = Manager.Blockchains.Wallet.GetWallets(Coin, Network);

            Assert.IsNotNull(getWalletsResponse);
            Assert.IsTrue(string.IsNullOrEmpty(getWalletsResponse.ErrorMessage));
            Assert.IsTrue(getWalletsResponse.Wallets.Any());
            Assert.AreEqual(1, getWalletsResponse.Wallets.Count(w => w == walletName));

            // GetWalletInfo
            var getResponse = Manager.Blockchains.Wallet.GetWalletInfo(Coin, Network, walletName);

            Assert.IsNotNull(getResponse);
            Assert.IsTrue(string.IsNullOrEmpty(getResponse.ErrorMessage));
            Assert.AreEqual(walletName, getResponse.Wallet.Name);
            Assert.AreEqual(Addresses.Count, getResponse.Wallet.Addresses.Count);

            // AddAddress
            var addResponse = Manager.Blockchains.Wallet.AddAddress(Coin, Network, walletName, AddedAddresses);

            Assert.IsNotNull(addResponse);
            Assert.IsTrue(string.IsNullOrEmpty(addResponse.ErrorMessage));
            Assert.AreEqual(walletName, addResponse.Wallet.Name);
            Assert.AreEqual(Addresses.Count + AddedAddresses.Count, addResponse.Wallet.Addresses.Count);

            // GenerateAddress
            var generateResponse = Manager.Blockchains.Wallet.GenerateAddress(Coin, Network, walletName);

            Assert.IsNotNull(generateResponse);
            Assert.IsTrue(string.IsNullOrEmpty(generateResponse.ErrorMessage));
            Assert.AreEqual(walletName, generateResponse.Payload.Wallet.Name);
            Assert.AreEqual(Addresses.Count + AddedAddresses.Count + 1, generateResponse.Payload.Wallet.Addresses.Count);

            // RemoveAddress
            var removingAddress = Addresses[0];
            var removeResponse = Manager.Blockchains.Wallet.RemoveAddress(Coin, Network, walletName, removingAddress);

            Assert.IsNotNull(removeResponse);
            Assert.IsTrue(string.IsNullOrEmpty(removeResponse.ErrorMessage));
            Assert.AreEqual($"address {removingAddress} was successfully deleted!", removeResponse.Payload.Message);

            // DeleteWallet
            var deleteResponse = Manager.Blockchains.Wallet.DeleteWallet(Coin, Network, walletName);

            Assert.IsNotNull(deleteResponse);
            Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
            Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
        }

        [TestMethod]
        public void InvalidAddress()
        {
            var walletName = $"{Coin}{Network}InvalidAddressWallet";
            var addresses = new List<string>
            {
                "qwe"
            };
            var response = Manager.Blockchains.Wallet.CreateWallet(Coin, Network, walletName, addresses);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("'addresses' contains invalid address(es): qwe", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "An Addresses was inappropriately allowed.")]
        public void EmptyAddresses()
        {
            var walletName = $"{Coin}{Network}EmptyAddressesWallet";
            Manager.Blockchains.Wallet.CreateWallet(Coin, Network, walletName, addresses: new List<string>());
        }

        [TestMethod]
        public void ExistingWallet()
        {
            // Create the first wallet
            var walletName = $"{Coin}{Network}ExistingWallet";
            var response = Manager.Blockchains.Wallet.CreateWallet(Coin, Network, walletName, Addresses);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(walletName, response.Wallet.Name);

            // Create the second wallet
            var response2 = Manager.Blockchains.Wallet.CreateWallet(Coin, Network, walletName, Addresses);

            Assert.IsNotNull(response2);
            Assert.IsFalse(string.IsNullOrEmpty(response2.ErrorMessage));
            Assert.AreEqual($"Wallet '{walletName}' already exists", response2.ErrorMessage);

            // DeleteWallet
            var deleteResponse = Manager.Blockchains.Wallet.DeleteWallet(Coin, Network, walletName);

            Assert.IsNotNull(deleteResponse);
            Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
            Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
        }

        [TestMethod]
        public void DuplicateAddresses()
        {
            var walletName = $"{Coin}{Network}DuplicateAddressesWallet";
            var addresses = new List<string>();
            addresses.AddRange(Addresses);
            addresses.AddRange(Addresses);

            var response = Manager.Blockchains.Wallet.CreateWallet(Coin, Network, walletName, addresses);

            Assert.IsNotNull(response);
            Assert.AreEqual("'addresses' contains duplicate address(es)", response.ErrorMessage);
        }

        protected abstract BtcSimilarCoin Coin { get; }
        protected abstract BtcSimilarNetwork Network { get; }
        protected abstract List<string> Addresses { get; }
        protected abstract List<string> AddedAddresses { get; }
    }
}