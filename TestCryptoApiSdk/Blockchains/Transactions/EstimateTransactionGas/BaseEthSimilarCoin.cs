﻿using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace TestCryptoApiSdk.Blockchains.Transactions.EstimateTransactionGas
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, ToAddress, Value, Data);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.GasNeeded));
        }

        [TestMethod]
        public void WrongFromAddress()
        {
            var fromAddress = "qwe";
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, fromAddress, ToAddress, Value, Data);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, $"{fromAddress} is not a valid Ethereum address");
        }

        [TestMethod]
        public void WrongToAddress()
        {
            var toAddress = "qwe";
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, toAddress, Value, Data);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, $"{toAddress} is not a valid Ethereum address");
        }

        [TestMethod]
        public void WrongData()
        {
            var data = "qwe";
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, ToAddress, Value, data);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Gas limit is not a valid integer number");
        }

        [TestMethod]
        public void ValueMoreThanBalance()
        {
            var value = 9999999999999;
            var response = Manager.Blockchains.Transaction.EstimateTransactionGas<EstimateTransactionGasResponse>(
                NetworkCoin, FromAddress, ToAddress, value, Data);

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
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

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "Internal Server Error");
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string FromAddress { get; }
        protected abstract string ToAddress { get; }
        protected abstract double Value { get; }
        protected abstract string Data { get; }
    }
}