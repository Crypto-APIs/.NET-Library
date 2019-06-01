using System;
using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.CreateTransactionPasswordWithGas
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, Value, Password, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex));
        }

        [TestMethod]
        public void WrongFromAddress()
        {
            var fromAddress = "qwe";
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, fromAddress, ToAddress, Value, Password, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual($"{fromAddress} is not a valid Ethereum address", response.ErrorMessage);
        }

        [TestMethod]
        public void WrongToAddress()
        {
            var toAddress = "qwe";
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, toAddress, Value, Password, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("", response.ErrorMessage);
        }

        [TestMethod]
        public void WrongPassword()
        {
            var password = "qwe";
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, Value, password, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Value was inappropriately allowed.")]
        public void InvalidValue()
        {
            var value = -1;
            Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, value, Password, GasPrice, GasLimit);
        }

        [TestMethod]
        public void TestValueMoreThanBalance()
        {
            var value = double.MaxValue;
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, value, Password, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("", response.ErrorMessage);
        }

        [TestMethod]
        public void GasPriceTooLow()
        {
            var gasPrice = 0;
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, Value, Password, gasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("", response.ErrorMessage);
        }

        [TestMethod]
        public void GasLimitTooLow()
        {
            var gasLimit = 0;
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, Value, Password, GasPrice, gasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress was inappropriately allowed.")]
        public void NullFromAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, fromAddress, ToAddress, Value, Password, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress was inappropriately allowed.")]
        public void NullToAddress()
        {
            string toAddress = null;
            Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, toAddress, Value, Password, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Password was inappropriately allowed.")]
        public void NullPassword()
        {
            string password = null;
            Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, Value, password, GasPrice, GasLimit);
        }
        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
        protected abstract string FromAddress { get; }
        protected abstract string ToAddress { get; }
        protected abstract double Value { get; }

        private string Password { get; } = "123456";
        private double GasPrice { get; } = 21000000000.0;
        private double GasLimit { get; } = 21000.0;
    }
}