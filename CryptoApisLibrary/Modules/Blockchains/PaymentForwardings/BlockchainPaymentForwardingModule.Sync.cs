using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Threading;

namespace CryptoApisLibrary.Modules.Blockchains.PaymentForwardings
{
    internal partial class BlockchainPaymentForwardingModule
    {
        public T CreatePayment<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string callbackUrl, string wallet, string password,
            int confirmations, double? fee = null)
            where T : CreateBtcPaymentResponse, new()
        {
            return CreatePaymentAsync<T>(CancellationToken.None, networkCoin, fromAddress, toAddress, callbackUrl,
                wallet, password, confirmations, fee).GetAwaiter().GetResult();
        }

        public T CreatePayment<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string callbackUrl, string password,
            int confirmations, double? gasPrice = null, double? gasLimit = null)
            where T : CreateEthPaymentResponse, new()
        {
            return CreatePaymentAsync<T>(CancellationToken.None, networkCoin, fromAddress, toAddress, callbackUrl,
                password, confirmations, gasPrice, gasLimit).GetAwaiter().GetResult();
        }

        public T CreatePaymentUsingPrivateKey<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string callbackUrl, string privateKey,
            int confirmations, double? gasPrice = null, double? gasLimit = null)
            where T : CreateEthPaymentResponse, new()
        {
            return CreatePaymentUsingPrivateKeyAsync<T>(CancellationToken.None, networkCoin, fromAddress, toAddress,
                callbackUrl, privateKey, confirmations, gasPrice, gasLimit).GetAwaiter().GetResult();
        }

        public T GetPayments<T>(NetworkCoin networkCoin)
            where T : GetPaymentsResponse, new()
        {
            return GetPaymentsAsync<T>(CancellationToken.None, networkCoin).GetAwaiter().GetResult();
        }

        public T GetHistoricalPayments<T>(NetworkCoin networkCoin)
            where T : GetHistoricalPaymentsResponse, new()
        {
            return GetHistoricalPaymentsAsync<T>(CancellationToken.None, networkCoin).GetAwaiter().GetResult();
        }

        public T DeletePayment<T>(NetworkCoin networkCoin, string paymentId)
            where T : DeletePaymentResponse, new()
        {
            return DeletePaymentAsync<T>(CancellationToken.None, networkCoin, paymentId).GetAwaiter().GetResult();
        }
    }
}