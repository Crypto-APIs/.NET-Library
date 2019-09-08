using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.PaymentForwardings
{
    internal partial class BlockchainPaymentForwardingModule
    {
        public CreateBtcPaymentResponse CreatePayment(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string fromAddress, string toAddress, string callbackUrl, string wallet, string password,
            int confirmations, double? fee = null)
        {
            var request = Requests.CreatePayment(coin, network, fromAddress, toAddress, callbackUrl,
                wallet, password, confirmations, fee);
            return GetSync<CreateBtcPaymentResponse>(request);
        }

        public CreateEthPaymentResponse CreatePayment(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string callbackUrl, string password,
            int confirmations, double? gasPrice = null, double? gasLimit = null)
        {
            var request = Requests.CreatePayment(coin, network, fromAddress, toAddress, callbackUrl,
                 password, confirmations, gasPrice, gasLimit);
            return GetSync<CreateEthPaymentResponse>(request);
        }

        public CreateEthPaymentResponse CreatePaymentUsingPrivateKey(
            EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string callbackUrl, string privateKey,
            int confirmations, double? gasPrice = null, double? gasLimit = null)
        {
            var request = Requests.CreatePaymentUsingPrivateKey(
                coin, network, fromAddress, toAddress, callbackUrl,
                privateKey, confirmations, gasPrice, gasLimit);
            return GetSync<CreateEthPaymentResponse>(request);
        }

        public GetBtcPaymentsResponse GetPayments(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetPayments(coin, network);
            return GetSync<GetBtcPaymentsResponse>(request);
        }

        public GetEthPaymentsResponse GetPayments(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.GetPayments(coin, network);
            return GetSync<GetEthPaymentsResponse>(request);
        }

        public GetBtcHistoricalPaymentsResponse GetHistoricalPayments(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetHistoricalPayments(coin, network);
            return GetSync<GetBtcHistoricalPaymentsResponse>(request);
        }

        public GetEthHistoricalPaymentsResponse GetHistoricalPayments(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.GetHistoricalPayments(coin, network);
            return GetSync<GetEthHistoricalPaymentsResponse>(request);
        }

        public DeleteBtcPaymentResponse DeletePayment(BtcSimilarCoin coin, BtcSimilarNetwork network, string paymentId)
        {
            var request = Requests.DeletePayment(coin, network, paymentId);
            return GetSync<DeleteBtcPaymentResponse>(request);
        }

        public DeleteEthPaymentResponse DeletePayment(EthSimilarCoin coin, EthSimilarNetwork network, string paymentId)
        {
            var request = Requests.DeletePayment(coin, network, paymentId);
            return GetSync<DeleteEthPaymentResponse>(request);
        }
    }
}