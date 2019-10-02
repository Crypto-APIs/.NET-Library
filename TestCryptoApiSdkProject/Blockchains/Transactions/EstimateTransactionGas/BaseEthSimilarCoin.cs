using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdkProject.Blockchains.Transactions.EstimateTransactionGas
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, ToAddress, Value, Data);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.GasNeeded));
        }

        [TestMethod]
        public void WrongFromAddress()
        {
            var fromAddress = "qwe";
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, fromAddress, ToAddress, Value, Data);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("qwe is not a valid Ethereum address", response.ErrorMessage);
        }

        [TestMethod]
        public void WrongToAddress()
        {
            var toAddress = "qwe";
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, toAddress, Value, Data);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("qwe is not a valid Ethereum address", response.ErrorMessage);
        }

        [TestMethod]
        public void WrongData()
        {
            var data = "qwe";
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, ToAddress, Value, data);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Gas limit is not a valid integer number", response.ErrorMessage);
        }

        [TestMethod]
        public void ValueMoreThanBalance()
        {
            var value = 9999999999999;
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, ToAddress, value, Data);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.GasNeeded));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress was inappropriately allowed.")]
        public void NullFromAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, fromAddress, ToAddress, Value, Data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress was inappropriately allowed.")]
        public void NullToAddress()
        {
            string toAddress = null;
            Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, toAddress, Value, Data);
        }

        [TestMethod]
        public void NullData()
        {
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, ToAddress, Value, data: null);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Internal Server Error", response.ErrorMessage);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string FromAddress { get; }
        protected abstract string ToAddress { get; }
        protected abstract double Value { get; }
        protected abstract string Data { get; }
    }
}