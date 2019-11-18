using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Blockchains.Addresses.GenerateAcount
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var response = Manager.Blockchains.Address.GenerateAccount<GenerateEthAccountResponse>(networkCoin, AccountPassword);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Address),
                $"'{nameof(response.Payload.Address)}' must not be null");
            Assert.AreEqual("keystore saved", response.Payload.Success, "SuccessMessage is wrong");
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void WrongPassword_ErrorMessage(NetworkCoin networkCoin)
        {
            var password = "qw'e";

            var response = Manager.Blockchains.Address.GenerateAccount<GenerateEthAccountResponse>(networkCoin, password);

            AssertErrorMessage(response,
                "Password is too weak! It should be at least 7 characters and should contain at least one letter and one digit");
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A Password of null was inappropriately allowed.")]
        public void NullPassword_Exception(NetworkCoin networkCoin)
        {
            string password = null;

            Manager.Blockchains.Address.GenerateAccount<GenerateEthAccountResponse>(networkCoin, password);
        }
    }
}