using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Blockchains.Addresses.GenerateAcount
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Address.GenerateAccount<GenerateEthAccountResponse>(
                NetworkCoin, AccountPassword);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Address), 
                $"'{nameof(response.Payload.Address)}' must not be null");
            Assert.AreEqual("keystore saved", response.Payload.Success);
        }

        [TestMethod]
        public void WrongPassword()
        {
            var response = Manager.Blockchains.Address.GenerateAccount<GenerateEthAccountResponse>(
                NetworkCoin, password: "qwe");

            AssertErrorMessage(response, "Password is too weak! It should be at least 7 characters and should contain at least one letter and one digit");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Password of null was inappropriately allowed.")]
        public void NullPassword()
        {
            Manager.Blockchains.Address.GenerateAccount<GenerateEthAccountResponse>(NetworkCoin, password: null);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
    }
}