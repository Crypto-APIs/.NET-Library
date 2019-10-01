using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.PaymentForwardings
{
    internal partial class BlockchainPaymentForwardingModule
    {
        public T CreatePayment<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string callbackUrl, string wallet, string password,
            int confirmations, double? fee = null)
            where T : CreateBtcPaymentResponse, new()
        {
            var request = Requests.CreatePayment(networkCoin, fromAddress, toAddress, callbackUrl,
                wallet, password, confirmations, fee);
            return GetSync<T>(request);
        }

        public T CreatePayment<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string callbackUrl, string password,
            int confirmations, double? gasPrice = null, double? gasLimit = null)
            where T : CreateEthPaymentResponse, new()
        {
            var request = Requests.CreatePayment(networkCoin, fromAddress, toAddress, callbackUrl,
                 password, confirmations, gasPrice, gasLimit);
            return GetSync<T>(request);
        }

        public T CreatePaymentUsingPrivateKey<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string callbackUrl, string privateKey,
            int confirmations, double? gasPrice = null, double? gasLimit = null)
            where T : CreateEthPaymentResponse, new()
        {
            var request = Requests.CreatePaymentUsingPrivateKey(
                networkCoin, fromAddress, toAddress, callbackUrl,
                privateKey, confirmations, gasPrice, gasLimit);
            return GetSync<T>(request);
        }

        public T GetPayments<T>(NetworkCoin networkCoin)
            where T : GetPaymentsResponse, new()
        {
            var request = Requests.GetPayments(networkCoin);
            return GetSync<T>(request);
        }

        public T GetHistoricalPayments<T>(NetworkCoin networkCoin)
            where T : GetHistoricalPaymentsResponse, new()
        {
            var request = Requests.GetHistoricalPayments(networkCoin);
            return GetSync<T>(request);
        }

        public T DeletePayment<T>(NetworkCoin networkCoin, string paymentId)
            where T : DeletePaymentResponse, new()
        {
            var request = Requests.DeletePayment(networkCoin, paymentId);
            return GetSync<T>(request);
        }
    }
}