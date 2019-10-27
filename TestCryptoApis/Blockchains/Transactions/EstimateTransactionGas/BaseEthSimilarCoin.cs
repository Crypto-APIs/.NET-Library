using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.Transactions.EstimateTransactionGas
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, ToAddress, Value, Data);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.GasLimit),
                $"'{nameof(response.Payload.GasLimit)}' must not be null");
        }

        [TestMethod]
        public void WrongFromAddress()
        {
            var fromAddress = "qw'e";
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, fromAddress, ToAddress, Value, Data);

            AssertErrorMessage(response, $"{fromAddress} is not a valid Ethereum address");
        }

        [TestMethod]
        public void WrongToAddress()
        {
            var toAddress = "qw'e";
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, toAddress, Value, Data);

            AssertErrorMessage(response, $"{toAddress} is not a valid Ethereum address");
        }

        [TestMethod]
        public void WrongData()
        {
            var data = "qw'e";
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, ToAddress, Value, data);

            AssertErrorMessage(response, "Gas limit is not a valid integer number");
        }

        [TestMethod]
        public void ValueMoreThanBalance()
        {
            var value = 9999999999999;
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, ToAddress, value, Data);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.GasLimit),
                $"'{nameof(response.Payload.GasLimit)}' must not be null");
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
            string data = null;
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, ToAddress, Value, data);

            ////AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.GasLimit),
                $"'{nameof(response.Payload.GasLimit)}' must not be null");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string FromAddress { get; }
        protected abstract string ToAddress { get; }
        protected abstract double Value { get; }
        protected abstract string Data { get; }
    }
}