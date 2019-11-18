using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CryptoApisLibrary.Tests.Blockchains.PaymentForwardings.CreateGetDelete
{
    [TestClass]
    public class EthSimilarCoin : BaseTest
    {
        [Ignore] // #032 // todo: need test refactoring
        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void GeneralTest(NetworkCoin networkCoin)
        {
            if (!IsAdditionalPackagePlan)
                return;

            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, FromAddress(networkCoin), ToAddress(networkCoin), CallbackUrl, Password, Confirmations, GasPrice, GasLimit);

            AssertNullErrorMessage(response);
            var paymentId = response.Payload.Id;
            Assert.IsFalse(string.IsNullOrEmpty(paymentId));

            var doubleResponse = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, FromAddress(networkCoin), ToAddress(networkCoin), CallbackUrl, Password, Confirmations, GasPrice, GasLimit);
            AssertErrorMessage(doubleResponse, $"Payment Forwarding from address '{FromAddress(networkCoin)}' already created");

            var tripleResponse = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, ToAddress(networkCoin), ToAddress(networkCoin), CallbackUrl, Password, Confirmations, GasPrice, GasLimit);
            AssertErrorMessage(tripleResponse, "'to' address must be different from 'from' address");

            try
            {
                var getResponse = Manager.Blockchains.PaymentForwarding.GetPayments<GetEthPaymentsResponse>(networkCoin);
                AssertNullErrorMessage(getResponse);
                AssertNotEmptyCollection(nameof(getResponse.Payments), getResponse.Payments);
                Assert.IsNotNull(getResponse.Payments.FirstOrDefault(h =>
                    h.Id.Equals(paymentId, StringComparison.OrdinalIgnoreCase)),
                    $"Collection must contains paymentId='{paymentId}'");

                var getHistoricalResponse = Manager.Blockchains.PaymentForwarding.GetHistoricalPayments<GetEthHistoricalPaymentsResponse>(
                    networkCoin);
                AssertNullErrorMessage(getHistoricalResponse);
                AssertNotEmptyCollection(nameof(getHistoricalResponse.Payments), getHistoricalResponse.Payments);
                Assert.IsNotNull(getHistoricalResponse.Payments.FirstOrDefault(h =>
                    h.Id.Equals(paymentId, StringComparison.OrdinalIgnoreCase)),
                    $"Collection must contain paymentId='{paymentId}'");
            }
            finally
            {
                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteEthPaymentResponse>(networkCoin, paymentId);
                AssertNullErrorMessage(deleteResponse);
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message),
                    "'Message' must not be null");
                Assert.AreEqual("ok", deleteResponse.Payload.Message,
                    "'Message' after deleting payment is wrong");
            }
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void InvalidFromAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var fromAddress = "qw'e";

            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, fromAddress, ToAddress(networkCoin), CallbackUrl, Password, Confirmations, GasPrice, GasLimit);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, $"{fromAddress}  is not a valid Ethereum address");
            }
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void InvalidToAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var toAddress = "q'we";

            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, FromAddress(networkCoin), toAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, $"{toAddress}  is not a valid Ethereum address");
            }
        }

        [Ignore] // #032
        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void InvalidCallbackUrl_ErrorMessage(NetworkCoin networkCoin)
        {
            var callbackUrl = "q'we";

            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, FromAddress(networkCoin), ToAddress(networkCoin), callbackUrl, Password, Confirmations, GasPrice, GasLimit); // todo: I don't know what password

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "");
            }
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        public void InvalidPassword_ErrorMessage(NetworkCoin networkCoin)
        {
            var password = "q'we";

            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, FromAddress(networkCoin), ToAddress(networkCoin), CallbackUrl, password, Confirmations, GasPrice, GasLimit);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "Wrong password");
            }
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress of null was inappropriately allowed.")]
        public void NullFromAddress_Exception(NetworkCoin networkCoin)
        {
            string fromAddress = null;
            var toAddress = "Any toAddress (does not affect the test result)";

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress of null was inappropriately allowed.")]
        public void NullToAddress_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            string toAddress = null;

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A CallbackUrl of null was inappropriately allowed.")]
        public void NullCallbackUrl_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            string callbackUrl = null;

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, callbackUrl, Password, Confirmations, GasPrice, GasLimit);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A Password of null was inappropriately allowed.")]
        public void NullPassword_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            string password = null;

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, CallbackUrl, password, Confirmations, GasPrice, GasLimit);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Confirmations was inappropriately allowed.")]
        public void InvalidConfirmations_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            var confirmations = 0;

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, CallbackUrl, Password, confirmations);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasPrice was inappropriately allowed.")]
        public void InvalidGasPrice_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            var gasPrice = 0;

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, CallbackUrl, Password, Confirmations, gasPrice);
        }

        [DataTestMethod]
        [EthSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasLimit was inappropriately allowed.")]
        public void InvalidGasLimit_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            var gasLimit = 0;

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                networkCoin, fromAddress, toAddress, CallbackUrl, Password, Confirmations, GasPrice, gasLimit);
        }

        private string CallbackUrl { get; } = "http://myaddress.com/paymet_forwarding_hook";
        private string Password { get; } = "SECRET123456";
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