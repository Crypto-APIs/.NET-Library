using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdkProject.Blockchains.PaymentForwardings.CreateGetDelete
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

            Assert.IsNotNull(response);
            Assert.IsTrue(string.IsNullOrEmpty(response.ErrorMessage));
            var paymentId = response.Payload.Id;
            Assert.IsFalse(string.IsNullOrEmpty(paymentId));

            var doubleResponse = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);
            Assert.IsNotNull(doubleResponse);
            Assert.IsFalse(string.IsNullOrEmpty(doubleResponse.ErrorMessage));
            Assert.AreEqual($"Payment Forwarding from address '{FromAddress}' already created", doubleResponse.ErrorMessage);

            var tripleResponse = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, ToAddress, ToAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);
            Assert.IsNotNull(tripleResponse);
            Assert.IsFalse(string.IsNullOrEmpty(tripleResponse.ErrorMessage));
            Assert.AreEqual($"'to' address must be different from 'from' address", tripleResponse.ErrorMessage);

            try
            {
                var getResponse = Manager.Blockchains.PaymentForwarding.GetPayments<GetEthPaymentsResponse>(NetworkCoin);
                Assert.IsTrue(string.IsNullOrEmpty(getResponse.ErrorMessage));
                Assert.IsTrue(getResponse.Payments.Any());
                Assert.IsNotNull(getResponse.Payments.FirstOrDefault(h =>
                    h.Id.Equals(paymentId, StringComparison.OrdinalIgnoreCase)));

                var getHistoricalResponse = Manager.Blockchains.PaymentForwarding.GetHistoricalPayments<GetEthHistoricalPaymentsResponse>(NetworkCoin);
                Assert.IsTrue(string.IsNullOrEmpty(getHistoricalResponse.ErrorMessage));
                Assert.IsTrue(getHistoricalResponse.Payments.Any());
                Assert.IsNotNull(getHistoricalResponse.Payments.FirstOrDefault(h =>
                    h.Id.Equals(paymentId, StringComparison.OrdinalIgnoreCase)));
            }
            finally
            {
                var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteEthPaymentResponse>(NetworkCoin, paymentId);
                Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message));
                Assert.AreEqual("ok", deleteResponse.Payload.Message);
            }
        }

        [TestMethod]
        public void InvalidFromAddress()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var fromAddress = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, fromAddress, ToAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual($"{fromAddress}  is not a valid Ethereum address", response.ErrorMessage);
        }

        [TestMethod]
        public void InvalidToAddress()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var toAddress = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, toAddress, CallbackUrl, Password, Confirmations, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual($"{toAddress}  is not a valid Ethereum address", response.ErrorMessage);
        }

        [Ignore] // #032
        [TestMethod]
        public void InvalidCallbackUrl()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var callbackUrl = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, callbackUrl, Password, Confirmations, GasPrice, GasLimit); // todo: I don't know what password

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("", response.ErrorMessage);
        }

        [TestMethod]
        public void InvalidPassword()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var password = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateEthPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, password, Confirmations, GasPrice, GasLimit);

            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrEmpty(response.ErrorMessage));
            Assert.AreEqual("Wrong password", response.ErrorMessage);
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
                    _toAddress = Manager.Blockchains.Address.GenerateAddress<GenerateEthAddressResponse>(NetworkCoin).Payload.Address;
                    Assert.IsNotNull(_toAddress);
                }
                return _toAddress;
            }
        }

        private string _fromAddress;
        private string _toAddress;
    }
}