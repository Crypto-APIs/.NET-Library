using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestCryptoApiSdk.Blockchains.PaymentForwardings.CreateGetDelete
{
    [TestClass]
    public abstract class BaseBtcSimilarCoin : BaseTest
    {
        [TestMethod]
        public void GeneralTest()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var walletName = GetRandomWalletName();
            var fromWallet = Manager.Blockchains.Wallet.CreateHdWallet<HdWalletInfoResponse>(NetworkCoin, walletName, 2, Password);
            Assert.IsNotNull(fromWallet);
            try
            {
                var addresses = fromWallet.Wallet.Addresses.ToArray();
                Assert.AreEqual(2, addresses.Length);
                var fromAddress = addresses[0].Address;
                Assert.IsNotNull(fromAddress);
                var toAddress = addresses[1].Address;
                Assert.IsNotNull(toAddress);

                var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                    NetworkCoin, fromAddress, toAddress, CallbackUrl, fromWallet.Wallet.Name, Password, Confirmations, Fee);

                AssertNotNullResponse(response);
                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Id));
                var paymentId = response.Payload.Id;

                var doubleResponse = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                    NetworkCoin, fromAddress, toAddress, CallbackUrl, fromWallet.Wallet.Name, Password, Confirmations, Fee);
                Assert.IsNotNull(doubleResponse);
                Assert.IsFalse(string.IsNullOrEmpty(doubleResponse.ErrorMessage));
                Assert.AreEqual($"Payment Forwarding from address '{fromAddress}' already created", doubleResponse.ErrorMessage);

                var tripleResponse = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                    NetworkCoin, toAddress, toAddress, CallbackUrl, fromWallet.Wallet.Name, Password, Confirmations, Fee);
                Assert.IsNotNull(tripleResponse);
                Assert.IsFalse(string.IsNullOrEmpty(tripleResponse.ErrorMessage));
                Assert.AreEqual($"'to' address must be different from 'from' address", tripleResponse.ErrorMessage);

                try
                {
                    var getResponse = Manager.Blockchains.PaymentForwarding.GetPayments<GetBtcPaymentsResponse>(NetworkCoin);
                    Assert.IsNotNull(getResponse);
                    Assert.IsTrue(getResponse.Payments.Any(), "Collection must not be empty");
                    Assert.IsNotNull(getResponse.Payments.FirstOrDefault(h =>
                        h.Id.Equals(paymentId, StringComparison.OrdinalIgnoreCase)));

                    var getHistoricalResponse = Manager.Blockchains.PaymentForwarding.GetHistoricalPayments<GetBtcHistoricalPaymentsResponse>(NetworkCoin);
                    Assert.IsTrue(string.IsNullOrEmpty(getHistoricalResponse.ErrorMessage));
                    //Assert.IsTrue(getHistoricalResponse.Payments.Any(), "Collection must not be empty");
                    //Assert.IsNotNull(getHistoricalResponse.Payments.FirstOrDefault(h =>
                    //    h.Id.Equals(paymentId, StringComparison.OrdinalIgnoreCase)));
                }
                finally
                {
                    var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(NetworkCoin, paymentId);
                    Assert.IsNotNull(deleteResponse);
                    Assert.IsTrue(string.IsNullOrEmpty(deleteResponse.ErrorMessage));
                    Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message));
                    Assert.AreEqual($"Payment Forwarding with uuid {paymentId} was successfully deleted", deleteResponse.Payload.Message);
                }
            }
            finally
            {
                var fromWalletDelete = Manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(NetworkCoin, fromWallet.Wallet.Name);
                Assert.IsNotNull(fromWalletDelete);
                Assert.IsTrue(string.IsNullOrEmpty(fromWalletDelete.ErrorMessage));
                Assert.AreEqual($"Wallet {walletName} was successfully deleted!", fromWalletDelete.Payload.Message);
            }
        }

        [TestMethod]
        public void InvalidFromAddress()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var fromAddress = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, fromAddress, ToAddress, CallbackUrl, GetRandomWalletName(), Password, Confirmations, Fee);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "'from' address is not valid");
        }

        [TestMethod]
        public void InvalidToAddress()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var toAddress = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, toAddress, CallbackUrl, GetRandomWalletName(), Password, Confirmations, Fee);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "'to' address is not valid");
        }

        [TestMethod]
        public void InvalidCallbackUrl()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var callbackUrl = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, callbackUrl, GetRandomWalletName(), Password, Confirmations, Fee);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "'callback' url is not valid");
        }

        [TestMethod]
        public void InvalidWallet()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var wallet = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, wallet, Password, Confirmations, Fee);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, $"Wallet '{wallet}' does not exist");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Confirmations was inappropriately allowed.")]
        public void InvalidConfirmations()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var confirmations = 0;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, GetRandomWalletName(), Password, confirmations, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Fee was inappropriately allowed.")]
        public void InvalidFee()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var fee = 0;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, GetRandomWalletName(), Password, Confirmations, fee);
        }

        [TestMethod]
        public void WeakPassword()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var password = "qwe";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, GetRandomWalletName(), password, Confirmations, Fee);

            AssertNotNullResponse(response);
            AssertErrorMessage(response, "'password' is too weak. Min size is 10 characters, actual is 3");
        }

        [TestMethod]
        public void InvalidPassword()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var walletName = GetRandomWalletName();
            var fromWallet = Manager.Blockchains.Wallet.CreateHdWallet<HdWalletInfoResponse>(NetworkCoin, walletName, 2, Password);
            Assert.IsNotNull(fromWallet);
            try
            {
                var fromAddress = fromWallet.Wallet.Addresses.FirstOrDefault()?.Address;
                Assert.IsNotNull(fromAddress);
                var toAddress = fromWallet.Wallet.Addresses.LastOrDefault()?.Address;
                Assert.IsNotNull(toAddress);
                var wrongPassword = "qweSdf34$dfw#";
                var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                    NetworkCoin, fromAddress, toAddress, CallbackUrl, fromWallet.Wallet.Name, wrongPassword, Confirmations, Fee);

                AssertNotNullResponse(response);
                AssertErrorMessage(response, "'wallet' can not be decrypted with this 'password'");
            }
            finally
            {
                var fromWalletDelete = Manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(NetworkCoin, fromWallet.Wallet.Name);
                Assert.IsNotNull(fromWalletDelete);
                Assert.IsTrue(string.IsNullOrEmpty(fromWalletDelete.ErrorMessage));
                Assert.AreEqual($"Wallet {walletName} was successfully deleted!", fromWalletDelete.Payload.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress of null was inappropriately allowed.")]
        public void TestBtcNullFromAddress()
        {
            string fromAddress = null;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, fromAddress, ToAddress, CallbackUrl, GetRandomWalletName(), Password, Confirmations, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress of null was inappropriately allowed.")]
        public void TestBtcNullToAddress()
        {
            string toAddress = null;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, toAddress, CallbackUrl, GetRandomWalletName(), Password, Confirmations, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A CallbackUrl of null was inappropriately allowed.")]
        public void TestBtcNullCallbackUrl()
        {
            string callbackUrl = null;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, callbackUrl, GetRandomWalletName(), Password, Confirmations, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Wallet of null was inappropriately allowed.")]
        public void TestBtcNullWallet()
        {
            string wallet = null;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, wallet, Password, Confirmations, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A Password of null was inappropriately allowed.")]
        public void TestBtcNullPassword()
        {
            string password = null;
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, GetRandomWalletName(), password, Confirmations, Fee);
        }

        protected abstract NetworkCoin NetworkCoin { get; }
        private string CallbackUrl { get; } = "http://myaddress.com/paymet_forwarding_hook";
        private string Password { get; } = "SECRET123456";
        private int Confirmations { get; } = 2;
        private double Fee { get; } = 0.00022827;

        private string GetRandomWalletName()
        {
            return $"wallet{new Random().Next(int.MaxValue)}";
        }

        private string FromAddress
        {
            get
            {
                if (_fromAddress == null)
                {
                    _fromAddress = Manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(NetworkCoin).Payload.Address;
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
                    _toAddress = Manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(NetworkCoin).Payload.Address;
                    Assert.IsNotNull(_toAddress);
                }
                return _toAddress;
            }
        }

        private string _fromAddress;
        private string _toAddress;
    }
}