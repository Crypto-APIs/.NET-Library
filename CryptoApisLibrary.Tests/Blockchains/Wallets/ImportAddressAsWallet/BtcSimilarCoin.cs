using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CryptoApisLibrary.Tests.Blockchains.Wallets.ImportAddressAsWallet
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        [Ignore] // todo: need corrected private key and password
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin, string address)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}GeneralTest";
            var correctPassword = "pass4wd##434#%^^word";
            var correctPrivateKey = "qwe";

            var response = Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                networkCoin, walletName, correctPassword, correctPrivateKey, address);
            AssertNullErrorMessage(response);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentNullException), "A WalletName of null was inappropriately allowed.")]
        public void NullWalletName_Exception(NetworkCoin networkCoin, string address)
        {
            string walletName = null;
            var password = "Any password (does not affect the test result)";
            var privateKey = "Any privateKey (does not affect the test result)";

            Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                networkCoin, walletName, password, privateKey, address);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentNullException), "A Password of null was inappropriately allowed.")]
        public void NullPassword_Exception(NetworkCoin networkCoin, string address)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}NullPassword";
            string password = null;
            var privateKey = "Any privateKey (does not affect the test result)";

            Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                networkCoin, walletName, password, privateKey, address);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        [ExpectedException(typeof(ArgumentNullException), "A PrivateKey of null was inappropriately allowed.")]
        public void NullPrivateKey_Exception(NetworkCoin networkCoin, string address)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}NullPrivateKey";
            var password = "Any password (does not affect the test result)";
            string privateKey = null;

            Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                networkCoin, walletName, password, privateKey, address);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "An Address of null was inappropriately allowed.")]
        public void NullAddress_Exception(NetworkCoin networkCoin)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}NullAddress";
            var password = "Any password (does not affect the test result)";
            var privateKey = "Any privateKey (does not affect the test result)";
            string address = null;

            Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                networkCoin, walletName, password, privateKey, address);
        }

        [Ignore] // todo: need corrected password
        [DataTestMethod]
        [DynamicData(nameof(GetTestData))]
        public void IncorrectPrivateKey_ErrorMessage(NetworkCoin networkCoin, string address)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}IncorrectPrivateKey";
            var correctPassword = "pass4wd##434#%^^word";
            var privateKey = "incorrect privatekey";

            var response = Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                networkCoin, walletName, correctPassword, privateKey, address);

            AssertErrorMessage(response, "Invalid private key");
            Assert.IsNull(response.Payload, $"'{nameof(response.Payload)}' must be null");
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void IncorrectAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var walletName = $"{networkCoin.Coin}{networkCoin.Network}IncorrectAddress";
            var correctPassword = "pass4wd##434#%^^word";
            var correctPrivateKey = "qwe";
            var address = "Any address";

            var response = Manager.Blockchains.Wallet.ImportAddressAsWallet<ImportAddressAsWalletResponse>(
                networkCoin, walletName, correctPassword, correctPrivateKey, address);

            AssertErrorMessage(response, "Address is not valid");
            Assert.IsNull(response.Payload, $"'{nameof(response.Payload)}' must be null");
        }

        private static IEnumerable<object[]> GetTestData
        {
            get
            {
                yield return new object[] { NetworkCoin.BchMainNet, Features.CorrectAddress.BchMainNet };
                yield return new object[] { NetworkCoin.BchTestNet, Features.CorrectAddress.BchTestNet };
                yield return new object[] { NetworkCoin.BtcMainNet, Features.CorrectAddress.BtcMainNet };
                yield return new object[] { NetworkCoin.BtcTestNet, Features.CorrectAddress.BtcTestNet };
                yield return new object[] { NetworkCoin.DashMainNet, Features.CorrectAddress.DashMainNet };
                yield return new object[] { NetworkCoin.DashTestNet, Features.CorrectAddress.DashTestNet };
                yield return new object[] { NetworkCoin.DogeMainNet, Features.CorrectAddress.DogeMainNet };
                yield return new object[] { NetworkCoin.DogeTestNet, Features.CorrectAddress.DogeTestNet };
                yield return new object[] { NetworkCoin.LtcMainNet, Features.CorrectAddress.LtcMainNet };
                yield return new object[] { NetworkCoin.LtcTestNet, Features.CorrectAddress.LtcTestNet };
            }
        }
    }
}