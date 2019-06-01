using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.SendAllAmountUsingPassword
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [Ignore] // todo: no funds for full testing
        [TestMethod]
        public void TestSimple()
        {
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPassword(
                Coin, Network, FromAddress, ToAddress, Password);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex));
        }

        [TestMethod]
        public void WrongFromAddress()
        {
            var fromAddress = "qwe";
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPassword(
                Coin, Network, fromAddress, ToAddress, Password);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual($"{fromAddress} is not a valid Ethereum address", response.ErrorMessage);
        }

        [TestMethod]
        public void WrongToAddress()
        {
            var toAddress = "qwe";
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPassword(
                Coin, Network, FromAddress, toAddress, Password);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual($"There is no registry for address: {FromAddress}", response.ErrorMessage);
        }

        [TestMethod]
        public void WrongPassword()
        {
            var password = "qwe";
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPassword(
                Coin, Network, FromAddress, ToAddress, password);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual($"There is no registry for address: { FromAddress }", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress was inappropriately allowed.")]
        public void NullFromAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.Transaction.SendAllAmountUsingPassword(
                Coin, Network, fromAddress, ToAddress, Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress was inappropriately allowed.")]
        public void NullToAddress()
        {
            string toAddress = null;
            Manager.Blockchains.Transaction.SendAllAmountUsingPassword(
                Coin, Network, FromAddress, toAddress, Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Password was inappropriately allowed.")]
        public void NullPassword()
        {
            string password = null;
            Manager.Blockchains.Transaction.SendAllAmountUsingPassword(
                Coin, Network, FromAddress, ToAddress, password);
        }

        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
        protected abstract string FromAddress { get; }
        protected abstract string ToAddress { get; }

        private string Password { get; } = "123";
    }
}