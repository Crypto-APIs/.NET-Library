using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Blockchains.PaymentForwardings
{
    internal partial class BlockchainPaymentForwardingModule
    {
        public Task<T> CreatePaymentAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress,
            string callbackUrl, string wallet, string password, int confirmations, double? fee = null)
            where T : CreateBtcPaymentResponse, new()
        {
            var request = Requests.CreatePayment(networkCoin, fromAddress, toAddress, callbackUrl,
                wallet, password, confirmations, fee);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> CreatePaymentAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress,
            string callbackUrl, string password, int confirmations, double? gasPrice = null, double? gasLimit = null)
            where T : CreateEthPaymentResponse, new()
        {
            var request = Requests.CreatePayment(networkCoin, fromAddress, toAddress, callbackUrl,
                password, confirmations, gasPrice, gasLimit);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> CreatePaymentUsingPrivateKeyAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress,
            string callbackUrl, string privateKey, int confirmations, double? gasPrice = null, double? gasLimit = null)
            where T : CreateEthPaymentResponse, new()
        {
            var request = Requests.CreatePaymentUsingPrivateKey(
                networkCoin, fromAddress, toAddress, callbackUrl,
                privateKey, confirmations, gasPrice, gasLimit);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetPaymentsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GetPaymentsResponse, new()
        {
            var request = Requests.GetPayments(networkCoin);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetHistoricalPaymentsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GetHistoricalPaymentsResponse, new()
        {
            var request = Requests.GetHistoricalPayments(networkCoin);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> DeletePaymentAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string paymentId)
            where T : DeletePaymentResponse, new()
        {
            var request = Requests.DeletePayment(networkCoin, paymentId);
            return GetAsyncResponse<T>(request, cancellationToken);
        }
    }
}