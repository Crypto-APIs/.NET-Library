using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoApisLibrary.Tests.Blockchains.Transactions.SendAllAmountUsingPassword
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [Ignore] // todo: no funds for full testing
        [TestMethod]
        public void TestSimple()
        {
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPassword<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, Password);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex), "'Hex' must not be null");
        }

        [TestMethod]
        public void WrongFromAddress()
        {
            var fromAddress = "qw'e";
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPassword<CreateEthTransactionResponse>(
                NetworkCoin, fromAddress, ToAddress, Password);

            AssertErrorMessage(response, $"{fromAddress} is not a valid Ethereum address");
        }

        [TestMethod]
        public void WrongToAddress()
        {
            var toAddress = "qw'e";
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPassword<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, toAddress, Password);

            AssertErrorMessage(response, $"There is no registry for address: {FromAddress}");
        }

        [TestMethod]
        public void WrongPassword()
        {
            var password = "qw'e";
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPassword<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, password);

            AssertErrorMessage(response, $"There is no registry for address: { FromAddress }");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress was inappropriately allowed.")]
        public void NullFromAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.Transaction.SendAllAmountUsingPassword<CreateEthTransactionResponse>(
                NetworkCoin, fromAddress, ToAddress, Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress was inappropriately allowed.")]
        public void NullToAddress()
        {
            string toAddress = null;
            Manager.Blockchains.Transaction.SendAllAmountUsingPassword<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, toAddress, Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Password was inappropriately allowed.")]
        public void NullPassword()
        {
            string password = null;
            Manager.Blockchains.Transaction.SendAllAmountUsingPassword<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, password);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string FromAddress { get; }
        protected abstract string ToAddress { get; }

        private string Password { get; } = "123";
    }
}