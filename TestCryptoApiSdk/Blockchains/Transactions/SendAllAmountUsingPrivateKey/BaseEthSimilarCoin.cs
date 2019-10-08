using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Blockchains.Transactions.SendAllAmountUsingPrivateKey
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [Ignore]
        [TestMethod]
        public void TestSimple()
        {
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPrivateKey<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, PrivateKey);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Hex));
        }

        [Ignore]
        [TestMethod]
        public void BalanceIsNotEnough()
        {
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPrivateKey<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, PrivateKey);

            AssertNullErrorMessage(response);
            Assert.AreEqual("Balance is not enough", response.ErrorMessage);
        }

        [TestMethod]
        public void WrongFromAddress()
        {
            var fromAddress = "qwe";
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPrivateKey<CreateEthTransactionResponse>(
                NetworkCoin, fromAddress, ToAddress, PrivateKey);

            AssertErrorMessage(response, $"{fromAddress} is not a valid Ethereum address");
        }

        [TestMethod]
        public void WrongToAddress()
        {
            var toAddress = "qwe";
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPrivateKey<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, toAddress, PrivateKey);

            AssertErrorMessage(response, $"{toAddress} is not a valid Ethereum address");
        }

        [Ignore]
        [TestMethod]
        public void TestWrongPrivateKey()
        {
            var privateKey = "qwe";
            var response = Manager.Blockchains.Transaction.SendAllAmountUsingPrivateKey<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, privateKey);

            AssertErrorMessage(response, "Bad Request"); // todo: "Bad Request" on Ropsten, "Balance is not enoug" on Mainnet and RinkenBy
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress was inappropriately allowed.")]
        public void NullFromAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.Transaction.SendAllAmountUsingPrivateKey<CreateEthTransactionResponse>(
                NetworkCoin, fromAddress, ToAddress, PrivateKey);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress was inappropriately allowed.")]
        public void NullToAddress()
        {
            string toAddress = null;
            Manager.Blockchains.Transaction.SendAllAmountUsingPrivateKey<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, toAddress, PrivateKey);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A PrivateKey was inappropriately allowed.")]
        public void NullPrivateKey()
        {
            string privateKey = null;
            Manager.Blockchains.Transaction.SendAllAmountUsingPrivateKey<CreateEthTransactionResponse>(
                NetworkCoin, FromAddress, ToAddress, privateKey);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        protected abstract string FromAddress { get; }
        protected abstract string ToAddress { get; }

        private string PrivateKey { get; } = "0x17de216dff24b36c35af535c7d4d9d36f57326f3ee8aaf7fd373715c27a15b7e";
    }
}