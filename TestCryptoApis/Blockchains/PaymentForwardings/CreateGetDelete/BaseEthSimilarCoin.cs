using System;
using System.Linq;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCryptoApis.Blockchains.PaymentForwardings.CreateGetDelete
{
    [TestClass]
    public abstract class BaseEthSimilarCoin : BaseTest
    {
        [Ignore] // #032
        [TestMethod]
        public void GeneralTest()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);

            AssertNullErrorMessage(response);
            var paymentId = response.Payload.Id;
            Assert.IsFalse(string.IsNullOrEmpty(paymentId));

            var doubleResponse = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);
            AssertErrorMessage(doubleResponse, $"Payment Forwarding from address '{FromAddress}' already created");

            var tripleResponse = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, ToAddress, ToAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);
            AssertErrorMessage(tripleResponse, "'to' address must be different from 'from' address");

            try
            {
                var getResponse = Manager.Blockchains.PaymentForwarding.GetPayments<GetEthPaymentsResponse>(NetworkCoin);
                AssertNullErrorMessage(getResponse);
                AssertNotEmptyCollection(nameof(getResponse.Payments), getResponse.Payments);
                Assert.IsNotNull(getResponse.Payments.FirstOrDefault(h =>
                    h.Id.Equals(paymentId, StringComparison.OrdinalIgnoreCase)),
                    $"Collection must contains paymentId='{paymentId}'");

                var getHistoricalResponse = Manager.Blockchains.PaymentForwarding.GetHistoricalPayments<GetEthHistoricalPaymentsResponse>(
                    NetworkCoin);
                AssertNullErrorMessage(getHistoricalResponse);
                AssertNotEmptyCollection(nameof(getHistoricalResponse.Payments), getHistoricalResponse.Payments);
                Assert.IsNotNull(getHistoricalResponse.Payments.FirstOrDefault(h =>
                    h.Id.Equals(paymentId, StringComparison.OrdinalIgnoreCase)), 
                    $"Collection must contain paymentId='{paymentId}'");
            }
            finally
            {
                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteEthPaymentResponse>(NetworkCoin, paymentId);
                AssertNullErrorMessage(deleteResponse);
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message), 
                    "'Message' must not be null");
                Assert.AreEqual("ok", deleteResponse.Payload.Message, 
                    "'Message' after deleting payment is wrong");
            }
        }

        [TestMethod]
        public void InvalidFromAddress()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var fromAddress = "qw'e";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, fromAddress, ToAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);

            AssertErrorMessage(response, $"{fromAddress}  is not a valid Ethereum address");
        }

        [TestMethod]
        public void InvalidToAddress()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var toAddress = "q'we";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, toAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);

            AssertErrorMessage(response, $"{toAddress}  is not a valid Ethereum address");
        }

        [Ignore] // #032
        [TestMethod]
        public void InvalidCallbackUrl()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var callbackUrl = "q'we";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, callbackUrl, Password, Confirmations, GasPrice, GasLimit); // todo: I don't know what password

            AssertErrorMessage(response, "");
        }

        [TestMethod]
        public void InvalidPassword()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var password = "q'we";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, password, Confirmations, GasPrice, GasLimit);

            AssertErrorMessage(response, "Wrong password");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress of null was inappropriately allowed.")]
        public void TestBtcNullFromAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, fromAddress, ToAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress of null was inappropriately allowed.")]
        public void TestBtcNullToAddress()
        {
            string toAddress = null;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, toAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A CallbackUrl of null was inappropriately allowed.")]
        public void TestBtcNullCallbackUrl()
        {
            string callbackUrl = null;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, callbackUrl, Password, Confirmations, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Password of null was inappropriately allowed.")]
        public void TestBtcNullPassword()
        {
            string password = null;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, password, Confirmations, GasPrice, GasLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Confirmations was inappropriately allowed.")]
        public void InvalidConfirmations()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var confirmations = 0;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, Password, confirmations);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasPrice was inappropriately allowed.")]
        public void InvalidGasPrice()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var gasPrice = 0;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, Password, Confirmations, gasPrice);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A GasLimit was inappropriately allowed.")]
        public void InvalidGasLimit()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var gasLimit = 0;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, Password, Confirmations, GasPrice, gasLimit);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        private string CallbackUrl { get; } = "http://myaddress.com/paymet_forwarding_hook";
        private string Password { get; } = "SECRET123456";
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