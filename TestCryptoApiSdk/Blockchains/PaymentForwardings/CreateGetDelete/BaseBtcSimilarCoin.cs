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
            var addressCount = 2;
            var fromWallet = Manager.Blockchains.Wallet.CreateHdWallet<HdWalletInfoResponse>(
                NetworkCoin, walletName, addressCount, Password);
            Assert.IsNotNull(fromWallet);
            try
            {
                var addresses = fromWallet.Wallet.Addresses.ToArray();
                Assert.AreEqual(2, addresses.Length, $"'Wallet.Addresses' count is wrong");
                var fromAddress = addresses[0].Address;
                Assert.IsNotNull(fromAddress, $"'{nameof(fromAddress)}' must not be null");
                var toAddress = addresses[1].Address;
                Assert.IsNotNull(toAddress, $"'{nameof(toAddress)}' must not be null");

                var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                    NetworkCoin, fromAddress, toAddress, CallbackUrl, fromWallet.Wallet.Name, Password, Confirmations, Fee);

                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Id), $"'Payload.Id' must not be null");
                var paymentId = response.Payload.Id;

                var doubleResponse = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                    NetworkCoin, fromAddress, toAddress, CallbackUrl, fromWallet.Wallet.Name, Password, Confirmations, Fee);
                AssertErrorMessage(doubleResponse, $"Payment Forwarding from address '{fromAddress}' already created");

                var tripleResponse = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                    NetworkCoin, toAddress, toAddress, CallbackUrl, fromWallet.Wallet.Name, Password, Confirmations, Fee);
                AssertErrorMessage(tripleResponse, "'to' address must be different from 'from' address");

                try
                {
                    var getResponse = Manager.Blockchains.PaymentForwarding.GetPayments<GetBtcPaymentsResponse>(NetworkCoin);
                    AssertNullErrorMessage(getResponse);
                    AssertNotEmptyCollection(nameof(getResponse.Payments), getResponse.Payments);
                    Assert.IsNotNull(getResponse.Payments.FirstOrDefault(h =>
                        h.Id.Equals(paymentId, StringComparison.OrdinalIgnoreCase)),
                        $"Collection must contains paymentId='{paymentId}'");

                    var getHistoricalResponse = Manager.Blockchains.PaymentForwarding.GetHistoricalPayments<GetBtcHistoricalPaymentsResponse>(
                        NetworkCoin);
                    AssertNullErrorMessage(getHistoricalResponse);
                    //Assert.IsTrue(getHistoricalResponse.Payments.Any(), "Collection must not be empty");
                    //Assert.IsNotNull(getHistoricalResponse.Payments.FirstOrDefault(h =>
                    //    h.Id.Equals(paymentId, StringComparison.OrdinalIgnoreCase)));
                }
                finally
                {
                    var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(NetworkCoin, paymentId);
                    AssertNullErrorMessage(deleteResponse);
                    Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message),
                        "'Message' must not be null");
                    Assert.AreEqual($"Payment Forwarding with uuid {paymentId} was successfully deleted",
                        deleteResponse.Payload.Message, "'Message' after deleting payment is wrong");
                }
            }
            finally
            {
                var fromWalletDelete = Manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(NetworkCoin, fromWallet.Wallet.Name);
                AssertNullErrorMessage(fromWalletDelete);
                Assert.AreEqual($"Wallet {walletName} was successfully deleted!", fromWalletDelete.Payload.Message,
                    "'Message' after deleting wallet is wrong");
            }
        }

        [TestMethod]
        public void InvalidFromAddress()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var fromAddress = "qw'e";
            var walletName = GetRandomWalletName();
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, fromAddress, ToAddress, CallbackUrl, walletName, Password, Confirmations, Fee);

            AssertErrorMessage(response, "'from' address is not valid");
        }

        [TestMethod]
        public void InvalidToAddress()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var toAddress = "qw'e";
            var walletName = GetRandomWalletName();
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, toAddress, CallbackUrl, walletName, Password, Confirmations, Fee);

            AssertErrorMessage(response, "'to' address is not valid");
        }

        [TestMethod]
        public void InvalidCallbackUrl()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var callbackUrl = "q'we";
            var walletName = GetRandomWalletName();
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, callbackUrl, walletName, Password, Confirmations, Fee);

            AssertErrorMessage(response, "'callback' url is not valid");
        }

        [TestMethod]
        public void InvalidWallet()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var wallet = "qw'e";
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, wallet, Password, Confirmations, Fee);

            AssertErrorMessage(response, $"Wallet '{wallet}' does not exist");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Confirmations was inappropriately allowed.")]
        public void InvalidConfirmations()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var confirmations = 0;
            var walletName = GetRandomWalletName();
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, walletName, Password, confirmations, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Fee was inappropriately allowed.")]
        public void InvalidFee()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var fee = 0;
            var walletName = GetRandomWalletName();
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, walletName, Password, Confirmations, fee);
        }

        [TestMethod]
        public void WeakPassword()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var password = "q'we";
            var walletName = GetRandomWalletName();
            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, walletName, password, Confirmations, Fee);

            AssertErrorMessage(response, "'password' is too weak. Min size is 10 characters, actual is 3");
        }

        [TestMethod]
        public void InvalidPassword()
        {
            if (!IsAdditionalPackagePlan)
                return;

            var walletName = GetRandomWalletName();
            var addressCount = 2;
            var fromWallet = Manager.Blockchains.Wallet.CreateHdWallet<HdWalletInfoResponse>(
                NetworkCoin, walletName, addressCount, Password);
            Assert.IsNotNull(fromWallet);
            try
            {
                var fromAddress = fromWallet.Wallet.Addresses.FirstOrDefault()?.Address;
                Assert.IsNotNull(fromAddress, $"{nameof(fromAddress)} must not be null");
                var toAddress = fromWallet.Wallet.Addresses.LastOrDefault()?.Address;
                Assert.IsNotNull(toAddress, $"{nameof(toAddress)} must not be null");
                var wrongPassword = "qweSdf34$dfw#";
                var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                    NetworkCoin, fromAddress, toAddress, CallbackUrl, fromWallet.Wallet.Name, wrongPassword, Confirmations, Fee);

                AssertErrorMessage(response, "'wallet' can not be decrypted with this 'password'");
            }
            finally
            {
                var fromWalletDelete = Manager.Blockchains.Wallet.DeleteWallet<DeleteWalletResponse>(NetworkCoin, fromWallet.Wallet.Name);
                AssertNullErrorMessage(fromWalletDelete);
                Assert.AreEqual($"Wallet {walletName} was successfully deleted!", fromWalletDelete.Payload.Message,
                    "'Message' is wrong");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress of null was inappropriately allowed.")]
        public void TestBtcNullFromAddress()
        {
            string fromAddress = null;
            var walletName = GetRandomWalletName();
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, fromAddress, ToAddress, CallbackUrl, walletName, Password, Confirmations, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress of null was inappropriately allowed.")]
        public void TestBtcNullToAddress()
        {
            string toAddress = null;
            var walletName = GetRandomWalletName();
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, toAddress, CallbackUrl, walletName, Password, Confirmations, Fee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "A CallbackUrl of null was inappropriately allowed.")]
        public void TestBtcNullCallbackUrl()
        {
            string callbackUrl = null;
            var walletName = GetRandomWalletName();
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, callbackUrl, walletName, Password, Confirmations, Fee);
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
            var walletName = GetRandomWalletName();
            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                NetworkCoin, FromAddress, ToAddress, CallbackUrl, walletName, password, Confirmations, Fee);
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
                    _toAddress = Manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(NetworkCoin).Payload.Address;
                    Assert.IsNotNull(_toAddress, $"'{nameof(_toAddress)}' must not be null");
                }
                return _toAddress;
            }
        }

        private string _fromAddress;
        private string _toAddress;
    }
}