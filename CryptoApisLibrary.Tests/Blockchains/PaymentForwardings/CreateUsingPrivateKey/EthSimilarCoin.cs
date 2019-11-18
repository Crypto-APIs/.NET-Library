using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CryptoApisLibrary.Tests.Blockchains.PaymentForwardings.CreateUsingPrivateKey
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void AllCorrect_ShouldPass(NetworkCoin networkCoin)
        {
            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                networkCoin, FromAddress(networkCoin), ToAddress(networkCoin), CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Id), "'Payload.Id' must not be null");
            }
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void InvalidFromAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var fromAddress = "q'we";

            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                networkCoin, fromAddress, ToAddress(networkCoin), CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, $"{fromAddress}  is not a valid Ethereum address");
            }
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void InvalidToAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var toAddress = "qw'e";

            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                networkCoin, FromAddress(networkCoin), toAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, $"{toAddress}  is not a valid Ethereum address");
            }
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void InvalidCallbackUrl_ErrorMessage(NetworkCoin networkCoin)
        {
            var callbackUrl = "q'we";

            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                networkCoin, FromAddress(networkCoin), ToAddress(networkCoin), callbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertNullErrorMessage(response);
                Assert.AreEqual(callbackUrl, response.Payload.Callback, "'Callback' must not be null");
            }
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void InvalidPrivateKey_ErrorMessage(NetworkCoin networkCoin)
        {
            var privateKey = "q'we";

            var response = Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                networkCoin, FromAddress(networkCoin), ToAddress(networkCoin), CallbackUrl, privateKey, Confirmations,
                GasPrice, GasLimit);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "For input string: \"q'we\"");
            }
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress of null was inappropriately allowed.")]
        public void NullFromAddress_Exception(NetworkCoin networkCoin)
        {
            string fromAddress = null;
            var toAddress = "Any toAddress (does not affect the test result)";

            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress of null was inappropriately allowed.")]
        public void NullToAddress_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            string toAddress = null;

            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A CallbackUrl of null was inappropriately allowed.")]
        public void NullCallbackUrl_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            string callbackUrl = null;

            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, callbackUrl, PrivateKey, Confirmations, GasPrice, GasLimit);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A PrivateKey of null was inappropriately allowed.")]
        public void NullPrivateKey_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            string privateKey = null;

            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, CallbackUrl, privateKey, Confirmations, GasPrice, GasLimit);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Confirmations was inappropriately allowed.")]
        public void InvalidConfirmations_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            var confirmations = 0;

            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, CallbackUrl, PrivateKey, confirmations);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasPrice was inappropriately allowed.")]
        public void InvalidGasPrice_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            var gasPrice = 0;

            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, CallbackUrl, PrivateKey, Confirmations, gasPrice);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasLimit was inappropriately allowed.")]
        public void InvalidGasLimit_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            var gasLimit = 0;

            Manager.Blockchains.PaymentForwarding.CreatePaymentUsingPrivateKey<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, CallbackUrl, PrivateKey, Confirmations, GasPrice, gasLimit);
        }

        private string PrivateKey { get; } = "0x17de216dff24b36c35af535c7d4d9d36f57326f3ee8aaf7fd373715c27a15b7e";
        private string CallbackUrl { get; } = "http://myaddress.com/paymet_forwarding_hook";
        private int Confirmations { get; } = 2;
        private double GasPrice { get; } = 5000000000;
        private double GasLimit { get; } = 21000;

        private string FromAddress(NetworkCoin networkCoin)
        {
            if (_fromAddress == null)
            {
                _fromAddress = Manager.Blockchains.Address.GenerateAddress<GenerateEthAddressResponse>(networkCoin).Payload.Address;
                Assert.IsNotNull(_fromAddress, $"'{nameof(_fromAddress)}' must not be null");
            }
            return _fromAddress;
        }

        private string ToAddress(NetworkCoin networkCoin)
        {
            if (_toAddress == null)
            {
                _toAddress = Manager.Blockchains.Address.GenerateAddress<GenerateEthAddressResponse>(networkCoin).Payload.Address;
                Assert.IsNotNull(_toAddress, $"'{nameof(_toAddress)}' must not be null");
            }
            return _toAddress;
        }

        private string _fromAddress;
        private string _toAddress;
    }
}