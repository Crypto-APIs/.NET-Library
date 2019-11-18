using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoApisLibrary.Tests.Blockchains.Wallets.ComplexTest
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestDataWithAddedAddresses))]
        public void GeneralTest(NetworkCoin networkCoin, ICollection<string> addresses, ICollection<string> addedAddresses)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}GeneralWallet";
            var response = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(networkCoin, walletName, addresses);
            try
            {
                AssertNullErrorMessage(response);
                Assert.AreEqual(walletName, response.Wallet.Name);

                // GetWallets
                var getWalletsResponse = Manager.Blockchains.Wallet.GetWallets<GetWalletsResponse>(networkCoin);
                AssertNullErrorMessage(getWalletsResponse);
                AssertNotEmptyCollection(nameof(getWalletsResponse.Wallets), getWalletsResponse.Wallets);
                Assert.AreEqual(1, getWalletsResponse.Wallets.Count(w => w == walletName));

                // GetWalletInfo
                var getResponse = Manager.Blockchains.Wallet.GetWalletInfo<WalletInfoResponse>(networkCoin, walletName);
                AssertNullErrorMessage(getResponse);
                Assert.AreEqual(walletName, getResponse.Wallet.Name);
                Assert.AreEqual(addresses.Count, getResponse.Wallet.Addresses.Count);

                // AddAddress
                var addResponse = Manager.Blockchains.Wallet.AddAddress<WalletInfoResponse>(networkCoin, walletName, addedAddresses);
                AssertNullErrorMessage(addResponse);
                Assert.AreEqual(walletName, addResponse.Wallet.Name);
                Assert.AreEqual(addresses.Count + addedAddresses.Count, addResponse.Wallet.Addresses.Count);

                // GenerateAddress
                var generateResponse = Manager.Blockchains.Wallet.GenerateAddress<GenerateWalletAddressResponse>(networkCoin, walletName);
                AssertNullErrorMessage(generateResponse);
                Assert.AreEqual(walletName, generateResponse.Payload.Wallet.Name);
                Assert.AreEqual(addresses.Count + addedAddresses.Count + 1, generateResponse.Payload.Wallet.Addresses.Count);

                // RemoveAddress
                var removingAddress = addresses.First();
                var removeResponse = Manager.Blockchains.Wallet.RemoveAddress<RemoveAddressResponse>(networkCoin, walletName, removingAddress);
                AssertNullErrorMessage(removeResponse);
                Assert.AreEqual($"address {removingAddress} was successfully deleted!", removeResponse.Payload.Message);
            }
            finally
            {
                // DeleteWallet
                var deleteResponse = Manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(networkCoin, walletName);
                AssertNullErrorMessage(deleteResponse);
                Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
            }
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void InvalidAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}InvalidAddressWallet";
            var addresses = new List<string>
            {
                "qwe"
            };

            var response = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(networkCoin, walletName, addresses);
            AssertErrorMessage(response, "'addresses' contains invalid address(es): qwe");
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "An Addresses was inappropriately allowed.")]
        public void EmptyAddresses_Exception(NetworkCoin networkCoin)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}EmptyAddressesWallet";
            var addresses = new List<string>();

            Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(networkCoin, walletName, addresses);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void ExistingWallet_ErrorMessage(NetworkCoin networkCoin, IEnumerable<string> addresses)
        {
            // Create the first wallet
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}ExistingWallet";
            var response = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(networkCoin, walletName, addresses);

            AssertNullErrorMessage(response);
            Assert.AreEqual(walletName, response.Wallet.Name);

            // Create the second wallet
            var response2 = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(networkCoin, walletName, addresses);
            AssertErrorMessage(response2, $"Wallet '{walletName}' already exists");

            // DeleteWallet
            var deleteResponse = Manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(networkCoin, walletName);
            AssertNullErrorMessage(deleteResponse);
            Assert.AreEqual($"Wallet {walletName} was successfully deleted!", deleteResponse.Payload.Message);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void DuplicateAddresses_ErrorMessage(NetworkCoin networkCoin, IEnumerable<string> addresses)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}DuplicateAddressesWallet";
            var duplicateAddresses = new List<string>();
            duplicateAddresses.AddRange(addresses);
            duplicateAddresses.AddRange(addresses);

            var response = Manager.Blockchains.Wallet.CreateWallet<WalletInfoResponse>(networkCoin, walletName, duplicateAddresses);

            Assert.AreEqual("'addresses' contains duplicate address(es)", response.ErrorMessage);
        }

        private static IEnumerable<object[]> GetTestData
        {
            get
            {
                yield return new object[] { NetworkCoin.BchMainNet, new[] { Features.CorrectAddress.BchMainNet, Features.CorrectAddress2.BchMainNet } };
                yield return new object[] { NetworkCoin.BchTestNet, new[] { Features.CorrectAddress.BchTestNet, Features.CorrectAddress2.BchTestNet } };
                yield return new object[] { NetworkCoin.BtcMainNet, new[] { Features.CorrectAddress.BtcMainNet, Features.CorrectAddress2.BtcMainNet } };
                yield return new object[] { NetworkCoin.BtcTestNet, new[] { Features.CorrectAddress.BtcTestNet, Features.CorrectAddress2.BtcTestNet } };
                yield return new object[] { NetworkCoin.DashMainNet, new[] { Features.CorrectAddress.DashMainNet, Features.CorrectAddress2.DashMainNet } };
                yield return new object[] { NetworkCoin.DashTestNet, new[] { Features.CorrectAddress.DashTestNet, Features.CorrectAddress2.DashTestNet } };
                yield return new object[] { NetworkCoin.DogeMainNet, new[] { Features.CorrectAddress.DogeMainNet, Features.CorrectAddress2.DogeMainNet } };
                yield return new object[] { NetworkCoin.DogeTestNet, new[] { Features.CorrectAddress.DogeTestNet, Features.CorrectAddress2.DogeTestNet } };
                yield return new object[] { NetworkCoin.LtcMainNet, new[] { Features.CorrectAddress.LtcMainNet, Features.CorrectAddress2.LtcMainNet } };
                yield return new object[] { NetworkCoin.LtcTestNet, new[] { Features.CorrectAddress.LtcTestNet, Features.CorrectAddress2.LtcTestNet } };
            }
        }

        private static IEnumerable<object[]> GetTestDataWithAddedAddresses
        {
            get
            {
                yield return new object[] { NetworkCoin.BchMainNet, new[] { Features.CorrectAddress.BchMainNet, Features.CorrectAddress2.BchMainNet }, new[] { Features.CorrectAddress3.BchMainNet } };
                yield return new object[] { NetworkCoin.BchTestNet, new[] { Features.CorrectAddress.BchTestNet, Features.CorrectAddress2.BchTestNet }, new[] { Features.CorrectAddress3.BchTestNet } };
                yield return new object[] { NetworkCoin.BtcMainNet, new[] { Features.CorrectAddress.BtcTestNet, Features.CorrectAddress2.BtcTestNet }, new[] { Features.CorrectAddress3.BtcTestNet } };
                yield return new object[] { NetworkCoin.BtcTestNet, new[] { Features.CorrectAddress.BtcTestNet, Features.CorrectAddress2.BtcTestNet }, new[] { Features.CorrectAddress3.BtcTestNet } };
                yield return new object[] { NetworkCoin.DashMainNet, new[] { Features.CorrectAddress.DashMainNet, Features.CorrectAddress2.DashMainNet }, new[] { Features.CorrectAddress3.DashMainNet } };
                yield return new object[] { NetworkCoin.DashTestNet, new[] { Features.CorrectAddress.DashTestNet, Features.CorrectAddress2.DashTestNet }, new[] { Features.CorrectAddress3.DashTestNet } };
                yield return new object[] { NetworkCoin.DogeMainNet, new[] { Features.CorrectAddress.DogeMainNet, Features.CorrectAddress2.DogeMainNet }, new[] { Features.CorrectAddress3.DogeMainNet } };
                yield return new object[] { NetworkCoin.DogeTestNet, new[] { Features.CorrectAddress.DogeTestNet, Features.CorrectAddress2.DogeTestNet }, new[] { Features.CorrectAddress3.DogeTestNet } };
                yield return new object[] { NetworkCoin.LtcMainNet, new[] { Features.CorrectAddress.LtcMainNet, Features.CorrectAddress2.LtcMainNet }, new[] { Features.CorrectAddress3.LtcMainNet } };
                yield return new object[] { NetworkCoin.LtcTestNet, new[] { Features.CorrectAddress.LtcTestNet, Features.CorrectAddress2.LtcTestNet }, new[] { Features.CorrectAddress3.LtcTestNet } };
            }
        }
    }
}