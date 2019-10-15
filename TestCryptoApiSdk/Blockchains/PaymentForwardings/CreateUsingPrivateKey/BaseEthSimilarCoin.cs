using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCryptoApiSdk.Blockchains.PaymentForwardings.CreateUsingPrivateKey
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);

            AssertNullErrorMessage(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Id), "'Payload.Id' must not be null");
        }

        [TestMethod]
        public void InvalidFromAddress()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var fromAddress = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                NetworkCoin, fromAddress, ToAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);

            AssertErrorMessage(response, $"{fromAddress}  is not a valid Ethereum address");
        }

        [TestMethod]
        public void TestEthInvalidToAddress()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var toAddress = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, toAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);

            AssertErrorMessage(response, $"{toAddress}  is not a valid Ethereum address");
        }

        [TestMethod]
        public void TestEthInvalidCallbackUrl()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var callbackUrl = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, callbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);

            AssertNullErrorMessage(response);
            Assert.AreEqual(callbackUrl, response.Payload.Callback, "'Callback' must not be null");
        }

        [TestMethod]
        public void TestEthInvalidPrivateKey()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var privateKey = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, privateKey, Confirmations, GasPrice, GasLimit);

            AssertErrorMessage(response, "For input string: \"qwe\"");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress of null was inappropriately allowed.")]
        public void TestEthNullFromAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                NetworkCoin, fromAddress, ToAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress of null was inappropriately allowed.")]
        public void TestEthNullToAddress()
        {
            string toAddress = null;
            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, toAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A CallbackUrl of null was inappropriately allowed.")]
        public void TestEthNullCallbackUrl()
        {
            string callbackUrl = null;
            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, callbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A PrivateKey of null was inappropriately allowed.")]
        public void TestEthNullPrivateKey()
        {
            string privateKey = null;
            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, privateKey, Confirmations, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Confirmations was inappropriately allowed.")]
        public void InvalidConfirmations()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var confirmations = 0;
            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, PrivateKey, confirmations);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasPrice was inappropriately allowed.")]
        public void InvalidGasPrice()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var gasPrice = 0;
            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, PrivateKey, Confirmations, gasPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasLimit was inappropriately allowed.")]
        public void InvalidGasLimit()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var gasLimit = 0;
            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, gasLimit);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
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
                    _fromAddress = Manager.Blockchains.Address.GenerateAddress<GenerateEthAddressResponse>(NetworkCoin).Payload.Address;
                    Assert.IsNotNull(_fromAddress, $"'{nameof(_fromAddress)}' must not be null");
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
                    _toAddress = Manager.Blockchains.Address.GenerateAddress<GenerateEthAddressResponse>(NetworkCoin).Payload.Address;
                    Assert.IsNotNull(_toAddress, $"'{nameof(_toAddress)}' must not be null");
                }
                return _toAddress;
            }
        }

        private string _fromAddress;
        private string _toAddress;
    }
}