using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using CryptoApisLibrary.Tests.TestDataProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CryptoApisLibrary.Tests.Blockchains.PaymentForwardings.CreateGetDelete
{
    [TestClass]
    public class BtcSimilarCoin : BaseTest
    {
        // todo: need test refactoring
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void GeneralTest(NetworkCoin networkCoin)
        {
            if (!IsAdditionalPackagePlan)
                return;

            var walletName = GetRandomWalletName();
            var addressCount = 2;
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var confirmations = 2;
            var password = "SECRET123456";
            var fromWallet = Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(
                networkCoin, walletName, addressCount, password);
            Assert.IsNotNull(fromWallet);
            try
            {
                var addresses = fromWallet.Wallet.Addresses.ToArray();
                Assert.AreEqual(2, addresses.Length, $"'Wallet.Addresses' count is wrong");
                var fromAddress = addresses[0].Address;
                Assert.IsNotNull(fromAddress, $"'{nameof(fromAddress)}' must not be null");
                var toAddress = addresses[1].Address;
                Assert.IsNotNull(toAddress, $"'{nameof(toAddress)}' must not be null");
                var fee = 0.00022827;

                var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                    networkCoin, fromAddress, toAddress, callbackUrl, fromWallet.Wallet.Name, password, confirmations, fee);

                AssertNullErrorMessage(response);
                Assert.IsFalse(string.IsNullOrEmpty(response.Payload.Id), $"'Payload.Id' must not be null");
                var paymentId = response.Payload.Id;

                var doubleResponse = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                    networkCoin, fromAddress, toAddress, callbackUrl, fromWallet.Wallet.Name, password, confirmations, fee);
                AssertErrorMessage(doubleResponse, $"Payment Forwarding from address '{fromAddress}' already created");

                var tripleResponse = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                    networkCoin, toAddress, toAddress, callbackUrl, fromWallet.Wallet.Name, password, confirmations, fee);
                AssertErrorMessage(tripleResponse, "'to' address must be different from 'from' address");

                try
                {
                    var getResponse = Manager.Blockchains.PaymentForwarding.GetPayments<GetBtcPaymentsResponse>(networkCoin);
                    AssertNullErrorMessage(getResponse);
                    AssertNotEmptyCollection(nameof(getResponse.Payments), getResponse.Payments);
                    Assert.IsNotNull(getResponse.Payments.FirstOrDefault(h =>
                        h.Id.Equals(paymentId, StringComparison.OrdinalIgnoreCase)),
                        $"Collection must contains paymentId='{paymentId}'");

                    var getHistoricalResponse = Manager.Blockchains.PaymentForwarding.GetHistoricalPayments<GetBtcHistoricalPaymentsResponse>(
                        networkCoin);
                    AssertNullErrorMessage(getHistoricalResponse);
                    //Assert.IsTrue(getHistoricalResponse.Payments.Any(), "Collection must not be empty");
                    //Assert.IsNotNull(getHistoricalResponse.Payments.FirstOrDefault(h =>
                    //    h.Id.Equals(paymentId, StringComparison.OrdinalIgnoreCase)));
                }
                finally
                {
                    var deleteResponse = Manager.Blockchains.PaymentForwarding.DeletePayment<DeleteBtcPaymentResponse>(networkCoin, paymentId);
                    AssertNullErrorMessage(deleteResponse);
                    Assert.IsFalse(string.IsNullOrEmpty(deleteResponse.Payload.Message),
                        "'Message' must not be null");
                    Assert.AreEqual($"Payment Forwarding with uuid {paymentId} was successfully deleted",
                        deleteResponse.Payload.Message, "'Message' after deleting payment is wrong");
                }
            }
            finally
            {
                var fromWalletDelete = Manager.Blockchains.Wallet.DeleteHdWallet<DeleteWalletResponse>(networkCoin, fromWallet.Wallet.Name);
                AssertNullErrorMessage(fromWalletDelete);
                Assert.AreEqual($"Wallet {walletName} was successfully deleted!", fromWalletDelete.Payload.Message,
                    "'Message' after deleting wallet is wrong");
            }
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void InvalidFromAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var fromAddress = "qw'e";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var walletName = GetRandomWalletName();
            var password = "SECRET123456";
            var confirmations = 2;
            var fee = 0.00022827;

            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                networkCoin, fromAddress, ToAddress(networkCoin), callbackUrl, walletName, password, confirmations, fee);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "'from' address is not valid");
            }
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void InvalidToAddress_ErrorMessage(NetworkCoin networkCoin)
        {
            var toAddress = "qw'e";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var walletName = GetRandomWalletName();
            var password = "SECRET123456"; 
            var confirmations = 2;
            var fee = 0.00022827;

            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                networkCoin, FromAddress(networkCoin), toAddress, callbackUrl, walletName, password, confirmations, fee);


            AssertErrorMessage(response, "'to' address is not valid");
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void InvalidCallbackUrl_ErrorMessage(NetworkCoin networkCoin)
        {
            var callbackUrl = "q'we";
            var walletName = GetRandomWalletName();
            var password = "SECRET123456";
            var confirmations = 2;
            var fee = 0.00022827;

            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                networkCoin, FromAddress(networkCoin), ToAddress(networkCoin), callbackUrl, walletName, password, confirmations, fee);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "'callback' url is not valid");
            }
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void InvalidWallet_ErrorMessage(NetworkCoin networkCoin)
        {
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var wallet = "qw'e";
            var password = "SECRET123456";
            var confirmations = 2;
            var fee = 0.00022827;

            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                networkCoin, FromAddress(networkCoin), ToAddress(networkCoin), callbackUrl, wallet, password, confirmations, fee);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, $"Wallet '{wallet}' does not exist");
            }
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Confirmations was inappropriately allowed.")]
        public void InvalidConfirmations_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var walletName = GetRandomWalletName();
            var password = "SECRET123456";
            var confirmations = 0;
            var fee = 0.00022827;

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                networkCoin, fromAddress, toAddress, callbackUrl, walletName, password, confirmations, fee);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "A Fee was inappropriately allowed.")]
        public void InvalidFee_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var walletName = GetRandomWalletName();
            var password = "SECRET123456";
            var confirmations = 2;
            var fee = 0;

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                networkCoin, fromAddress, toAddress, callbackUrl, walletName, password, confirmations, fee);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void WeakPassword_ErrorMessage(NetworkCoin networkCoin)
        {
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook"; 
            var walletName = GetRandomWalletName();
            var password = "q'we";
            var confirmations = 2;
            var fee = 0.00022827;

            var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                networkCoin, FromAddress(networkCoin), ToAddress(networkCoin), callbackUrl, walletName, password, confirmations, fee);

            if (AssertAdditionalPackagePlan(response))
            {
                AssertErrorMessage(response, "'password' is too weak. Min size is 10 characters, actual is 4");
            }
        }

        // todo: need test refactoring
        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        public void InvalidPassword(NetworkCoin networkCoin)
        {
            if (!IsAdditionalPackagePlan)
                return;

            var walletName = GetRandomWalletName();
            var addressCount = 2;
            var password = "SECRET123456";
            var fromWallet = Manager.Blockchains.Wallet.CreateHdWallet<BtcHdWalletInfoResponse>(
                networkCoin, walletName, addressCount, password);
            Assert.IsNotNull(fromWallet);
            try
            {
                var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
                var fromAddress = fromWallet.Wallet.Addresses.FirstOrDefault()?.Address;
                Assert.IsNotNull(fromAddress, $"{nameof(fromAddress)} must not be null");
                var toAddress = fromWallet.Wallet.Addresses.LastOrDefault()?.Address;
                Assert.IsNotNull(toAddress, $"{nameof(toAddress)} must not be null");
                var wrongPassword = "qweSdf34$dfw#";
                var confirmations = 2;
                var fee = 0.00022827;

                var response = Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                    networkCoin, fromAddress, toAddress, callbackUrl, fromWallet.Wallet.Name, wrongPassword, confirmations, fee);

                AssertErrorMessage(response, "'wallet' cannot be decrypted with this 'password'");
            }
            finally
            {
                var fromWalletDelete = Manager.Blockchains.Wallet.DeleteHdWallet<DeleteWalletResponse>(networkCoin, fromWallet.Wallet.Name);
                AssertNullErrorMessage(fromWalletDelete);
                Assert.AreEqual($"Wallet {walletName} was successfully deleted!", fromWalletDelete.Payload.Message,
                    "'Message' is wrong");
            }
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A FromAddress of null was inappropriately allowed.")]
        public void NullFromAddress_Exception(NetworkCoin networkCoin)
        {
            string fromAddress = null;
            var toAddress = "Any toAddress (does not affect the test result)";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var walletName = GetRandomWalletName();
            var password = "SECRET123456";
            var confirmations = 2;
            var fee = 0.00022827;

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                networkCoin, fromAddress, toAddress, callbackUrl, walletName, password, confirmations, fee);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A ToAddress of null was inappropriately allowed.")]
        public void NullToAddress_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            string toAddress = null;
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var walletName = GetRandomWalletName();
            var password = "SECRET123456"; 
            var confirmations = 2;
            var fee = 0.00022827;

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                networkCoin, fromAddress, toAddress, callbackUrl, walletName, password, confirmations, fee);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A CallbackUrl of null was inappropriately allowed.")]
        public void NullCallbackUrl_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            string callbackUrl = null;
            var walletName = GetRandomWalletName();
            var password = "SECRET123456";
            var confirmations = 2;
            var fee = 0.00022827;

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                networkCoin, fromAddress, toAddress, callbackUrl, walletName, password, confirmations, fee);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A Wallet of null was inappropriately allowed.")]
        public void NullWallet_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            string wallet = null;
            var password = "SECRET123456";
            var confirmations = 2;
            var fee = 0.00022827;

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                networkCoin, fromAddress, toAddress, callbackUrl, wallet, password, confirmations, fee);
        }

        [DataTestMethod]
        [BtcSimilarNetworkCoinProvider]
        [ExpectedException(typeof(ArgumentNullException), "A Password of null was inappropriately allowed.")]
        public void NullPassword_Exception(NetworkCoin networkCoin)
        {
            var fromAddress = "Any fromAddress (does not affect the test result)";
            var toAddress = "Any toAddress (does not affect the test result)";
            var callbackUrl = "http://myaddress.com/paymet_forwarding_hook";
            var walletName = GetRandomWalletName();
            string password = null;
            var confirmations = 2;
            var fee = 0.00022827;

            Manager.Blockchains.PaymentForwarding.CreatePayment<CreateBtcPaymentResponse>(
                networkCoin, fromAddress, toAddress, callbackUrl, walletName, password, confirmations, fee);
        }

        private string GetRandomWalletName()
        {
            return $"wallet{new Random().Next(int.MaxValue)}";
        }

        private string FromAddress(NetworkCoin networkCoin)
        {
            if (_fromAddress == null)
            {
                _fromAddress = Manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(networkCoin).Payload.Address;
                Assert.IsNotNull(_fromAddress, $"'{nameof(_fromAddress)}' must not be null");
            }
            return _fromAddress;
        }

        private string ToAddress(NetworkCoin networkCoin)
        {
            if (_toAddress == null)
            {
                _toAddress = Manager.Blockchains.Address.GenerateAddress<GenerateBtcAddressResponse>(networkCoin).Payload.Address;
                Assert.IsNotNull(_toAddress, $"'{nameof(_toAddress)}' must not be null");
            }
            return _toAddress;
        }

        private string _fromAddress;
        private string _toAddress;
    }
}