using CryptoApisSdkLibrary.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdkProject.Blockchains.PaymentForwardings.CreateUsingPrivateKey
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey(
                Coin, Network, FromAddress, ToAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Id));
        }

        [TestMethod]
        public void InvalidFromAddress()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var fromAddress = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey(
                Coin, Network, fromAddress, ToAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual($"{fromAddress}  is not a valid Ethereum address", response.ErrorMessage);
        }

        [TestMethod]
        public void TestEthInvalidToAddress()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var toAddress = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey(
                Coin, Network, FromAddress, toAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual($"{toAddress}  is not a valid Ethereum address", response.ErrorMessage);
        }

        [TestMethod]
        public void TestEthInvalidCallbackUrl()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var callbackUrl = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey(
                Coin, Network, FromAddress, ToAddress, callbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual(callbackUrl, response.Payload.Callback);
        }

        [TestMethod]
        public void TestEthInvalidPrivateKey()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var privateKey = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey(
                Coin, Network, FromAddress, ToAddress, CallbackUrl, privateKey, Confirmations, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("For input string: \"qwe\"", response.ErrorMessage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress of null was inappropriately allowed.")]
        public void TestEthNullFromAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey(
                Coin, Network, fromAddress, ToAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress of null was inappropriately allowed.")]
        public void TestEthNullToAddress()
        {
            string toAddress = null;
            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey(
                Coin, Network, FromAddress, toAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A CallbackUrl of null was inappropriately allowed.")]
        public void TestEthNullCallbackUrl()
        {
            string callbackUrl = null;
            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey(
                Coin, Network, FromAddress, ToAddress, callbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A PrivateKey of null was inappropriately allowed.")]
        public void TestEthNullPrivateKey()
        {
            string privateKey = null;
            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey(
                Coin, Network, FromAddress, ToAddress, CallbackUrl, privateKey, Confirmations, GasPrice, GasLimit);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Confirmations was inappropriately allowed.")]
        public void InvalidConfirmations()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var confirmations = 0;
            Manager.Blockchains.PaymentForwarding.CreatePayment(
                Coin, Network, FromAddress, ToAddress, CallbackUrl, PrivateKey, confirmations);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasPrice was inappropriately allowed.")]
        public void InvalidGasPrice()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var gasPrice = 0;
            Manager.Blockchains.PaymentForwarding.CreatePayment(
                Coin, Network, FromAddress, ToAddress, CallbackUrl, PrivateKey, Confirmations, gasPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasLimit was inappropriately allowed.")]
        public void InvalidGasLimit()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var gasLimit = 0;
            Manager.Blockchains.PaymentForwarding.CreatePayment(
                Coin, Network, FromAddress, ToAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, gasLimit);
        }

        protected abstract EthSimilarCoin Coin { get; }
        protected abstract EthSimilarNetwork Network { get; }
        private string PrivateKey { get; } = "0x17de216dff24b36c35af535c7d4d9d36f57326f3ee8aaf7fd373715c27a15b7e";
        private string CallbackUrl { get; } = "http://myaddress.com/paymet_forwarding_hook";
        private int Confirmations { get; } = 2;
        private double GasPrice { get; } = 5000000000;
        private double GasLimit { get; } = 21000;

        private string FromAddress
        {
            get
            {
                if (_fromAddress == null)
                {
                    _fromAddress = Manager.Blockchains.Address.GenerateAddress(Coin, Network).Payload.Address;
                    Assert.IsNotNull(_fromAddress);
                }
                return _fromAddress;
            }
        }

        private string ToAddress
        {
            get
            {
                if (_toAddress == null)
                {
                    _toAddress = Manager.Blockchains.Address.GenerateAddress(Coin, Network).Payload.Address;
                    Assert.IsNotNull(_toAddress);
                }
                return _toAddress;
            }
        }

        private string _fromAddress;
        private string _toAddress;
    }
}