using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Blockchains.Transactions.SendAllAmountUsingPassword
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

            AssertNotNullResponse(response);
            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex));
        }

        [TestMethod]
        public void WrongFromAddress()
        {
            var fromAddress = "qwe";
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPassword<CreateEthTransactionResponse>(
                NetworkCoin, fromAddress, ToAddress, Password);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, $"{fromAddress} is not a valid Ethereum address");
        }

        [TestMethod]
        public void WrongToAddress()
        {
            var toAddress = "qwe";
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPassword<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, toAddress, Password);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, $"There is no registry for address: {FromAddress}");
        }

        [TestMethod]
        public void WrongPassword()
        {
            var password = "qwe";
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPassword<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, password);

            AssertNotNullResponse(response);
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