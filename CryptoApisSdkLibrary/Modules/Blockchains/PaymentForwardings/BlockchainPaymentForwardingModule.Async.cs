using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.PaymentForwardings
{
    internal partial class BlockchainPaymentForwardingModule
    {
        public Task<CreateBtcPaymentResponse> CreatePaymentAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string fromAddress, string toAddress,
            string callbackUrl, string wallet, string password, int confirmations, double? fee = null)
        {
            var request = Requests.CreatePayment(coin, network, fromAddress, toAddress, callbackUrl,
                wallet, password, confirmations, fee);
            return GetAsyncResponse<CreateBtcPaymentResponse>(request, cancellationToken);
        }

        public Task<CreateEthPaymentResponse> CreatePaymentAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress,
            string callbackUrl, string password, int confirmations, double? gasPrice = null, double? gasLimit = null)
        {
            var request = Requests.CreatePayment(coin, network, fromAddress, toAddress, callbackUrl,
                password, confirmations, gasPrice, gasLimit);
            return GetAsyncResponse<CreateEthPaymentResponse>(request, cancellationToken);
        }

        public Task<CreateEthPaymentResponse> CreatePaymentUsingPrivateKeyAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress,
            string callbackUrl, string privateKey, int confirmations, double? gasPrice = null, double? gasLimit = null)
        {
            var request = Requests.CreatePaymentUsingPrivateKey(
                coin, network, fromAddress, toAddress, callbackUrl,
                privateKey, confirmations, gasPrice, gasLimit);
            return GetAsyncResponse<CreateEthPaymentResponse>(request, cancellationToken);
        }

        public Task<GetBtcPaymentsResponse> GetPaymentsAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetPayments(coin, network);
            return GetAsyncResponse<GetBtcPaymentsResponse>(request, cancellationToken);
        }

        public Task<GetEthPaymentsResponse> GetPaymentsAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.GetPayments(coin, network);
            return GetAsyncResponse<GetEthPaymentsResponse>(request, cancellationToken);
        }

        public Task<GetBtcHistoricalPaymentsResponse> GetHistoricalPaymentsAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetHistoricalPayments(coin, network);
            return GetAsyncResponse<GetBtcHistoricalPaymentsResponse>(request, cancellationToken);
        }

        public Task<GetEthHistoricalPaymentsResponse> GetHistoricalPaymentsAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.GetHistoricalPayments(coin, network);
            return GetAsyncResponse<GetEthHistoricalPaymentsResponse>(request, cancellationToken);
        }

        public Task<DeleteBtcPaymentResponse> DeletePaymentAsync(CancellationToken cancellationToken,
        BtcSimilarCoin coin, BtcSimilarNetwork network, string paymentId)
        {
            var request = Requests.DeletePayment(coin, network, paymentId);
            return GetAsyncResponse<DeleteBtcPaymentResponse>(request, cancellationToken);
        }

        public Task<DeleteEthPaymentResponse> DeletePaymentAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string paymentId)
        {
            var request = Requests.DeletePayment(coin, network, paymentId);
            return GetAsyncResponse<DeleteEthPaymentResponse>(request, cancellationToken);
        }
    }
}