using System;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApiSdk.Blockchains.Transactions.LocallySignTransaction
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            var response = Manager.Blockchains.Transaction.LocallySignTransaction<LocallySignTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, Value);

            AssertNullErrorMessage(response);
            Assert.AreEqual(FromAddress, response.Payload.FromAddress, 
                $"'{nameof(FromAddress)}' is wrong");
        }

        [TestMethod]
        public void WrongFromAddress()
        {
            var fromAddress = "qwe";
            var response = Manager.Blockchains.Transaction.LocallySignTransaction<LocallySignTransactionResponse>(
                NetworkCoin, fromAddress, ToAddress, Value);

            AssertErrorMessage(response, $"{fromAddress} is not a valid Ethereum address");
        }

        [TestMethod]
        public void WrongToAddress()
        {
            var toAddress = "qwe";
            var response = Manager.Blockchains.Transaction.LocallySignTransaction<LocallySignTransactionResponse>(
                NetworkCoin, FromAddress, toAddress, Value);

            AssertErrorMessage(response, $"{toAddress} is not a valid Ethereum address");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress was inappropriately allowed.")]
        public void NullFromAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.Transaction.LocallySignTransaction<LocallySignTransactionResponse>(
                NetworkCoin, fromAddress, ToAddress, Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress was inappropriately allowed.")]
        public void NullToAddress()
        {
            string toAddress = null;
            Manager.Blockchains.Transaction.LocallySignTransaction<LocallySignTransactionResponse>(
                NetworkCoin, FromAddress, toAddress, Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Value was inappropriately allowed.")]
        public void InvalidValue()
        {
            var value = -1.212;
            Manager.Blockchains.Transaction.LocallySignTransaction<LocallySignTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, value);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string FromAddress { get; }
        protected abstract string ToAddress { get; }
        protected abstract double Value { get; }
    }
}