using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.CreateTransactionPrivateKeyWithGas
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [Ignore]
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, PrivateKey, Value, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex));
        }

        [TestMethod]
        public void WrongFromAddress()
        {
            var fromAddress = "qwe";
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, fromAddress, ToAddress, PrivateKey, Value, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual($"{fromAddress} is not a valid Ethereum address", response.ErrorMessage);
        }

        [TestMethod]
        public void WrongToAddress()
        {
            var toAddress = "qwe";
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, toAddress, PrivateKey, Value, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual($"{toAddress} is not a valid Ethereum address", response.ErrorMessage);
        }

        [TestMethod]
        public void WrongPrivateKey()
        {
            var privateKey = "qwe";
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, privateKey, Value, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Bad Request", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Value was inappropriately allowed.")]
        public void InvalidValue()
        {
            var value = -1;
            Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, PrivateKey, value, GasPrice, GasLimit);
        }

        [Ignore]
        [TestMethod]
        public void ValueMoreThanBalance()
        {
            var value = double.MaxValue;
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, PrivateKey, value, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("insufficient funds for gas * price + value", response.ErrorMessage);
        }

        [Ignore]
        [TestMethod]
        public void GasPriceTooLow()
        {
            var gasPrice = 0;
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, PrivateKey, Value, gasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("insufficient funds for gas * price + value", response.ErrorMessage);
        }

        [Ignore]
        [TestMethod]
        public void GasLimitTooLow()
        {
            var gasLimit = 0;
            var response = Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, PrivateKey, Value, GasPrice, gasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("insufficient funds for gas * price + value", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress was inappropriately allowed.")]
        public void NullFromAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, fromAddress, ToAddress, PrivateKey, Value, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress was inappropriately allowed.")]
        public void NullToAddress()
        {
            string toAddress = null;
            Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, toAddress, PrivateKey, Value, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A privateKey was inappropriately allowed.")]
        public void NullPrivateKey()
        {
            string privateKey = null;
            Manager.Blockchains.Transaction.CreateTransaction(
                Coin, Network, FromAddress, ToAddress, privateKey, Value, GasPrice, GasLimit);
        }

        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
        protected abstract string FromAddress { get; }
        protected abstract string ToAddress { get; }
        protected abstract double Value { get; }

        private string PrivateKey { get; } = "0x17de216dff24b36c35af535c7d4d9d36f57326f3ee8aaf7fd373715c27a15b7e";
        private double GasPrice { get; } = 21000000000.0;
        private double GasLimit { get; } = 21000.0;
    }
}