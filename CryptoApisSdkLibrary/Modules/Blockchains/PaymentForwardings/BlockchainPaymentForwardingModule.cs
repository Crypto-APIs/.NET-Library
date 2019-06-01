using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.RequestTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Blockchains.PaymentForwardings
{
    internal class BlockchainPaymentForwardingModule : BaseModule, IBlockchainPaymentForwardingModule
    {
        public BlockchainPaymentForwardingModule(IRestClient client, CryptoApiRequest request) : base(client, request)
        {
        }

        public CreateBtcPaymentResponse CreatePayment(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string fromAddress, string toAddress, string callbackUrl, string wallet, string password,
            int confirmations, double? fee = null)
        {
            if (fromAddress == null)
                throw new ArgumentNullException(nameof(fromAddress));
            if (toAddress == null)
                throw new ArgumentNullException(nameof(toAddress));
            if (callbackUrl == null)
                throw new ArgumentNullException(nameof(callbackUrl));
            if (wallet == null)
                throw new ArgumentNullException(nameof(wallet));
            if (password == null)
                throw new ArgumentNullException(nameof(password));
            if (confirmations <= 0)
                throw new ArgumentOutOfRangeException(nameof(confirmations), confirmations, "Confirmations is negative or zero");
            if (fee.HasValue && fee.Value <= 0)
                throw new ArgumentOutOfRangeException(nameof(fee));

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/payments",
                new CreateBtcPaymentRequest(fromAddress, toAddress, callbackUrl, wallet, password, confirmations, fee));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateBtcPaymentResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateBtcPaymentResponse>(response);
        }

        public CreateEthPaymentResponse CreatePayment(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string callbackUrl, string password, 
            int confirmations, double? gasPrice = null, double? gasLimit = null)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            var paymentRequest = new CreateEthPaymentPasswordRequest(fromAddress, toAddress, callbackUrl, password,
                confirmations, gasPrice, gasLimit);
            return InternalCreatePayment(coin, network, paymentRequest);
        }

        public CreateEthPaymentResponse CreatePaymentUsingPrivateKey(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string callbackUrl, string privateKey,
            int confirmations, double? gasPrice = null, double? gasLimit = null)
        {
            if (string.IsNullOrEmpty(privateKey))
                throw new ArgumentNullException(nameof(privateKey));

            var paymentRequest = new CreateEthPaymentPrivateKeyRequest(fromAddress, toAddress, callbackUrl, privateKey,
                confirmations, gasPrice, gasLimit);
            return InternalCreatePayment(coin, network, paymentRequest);
        }

        private CreateEthPaymentResponse InternalCreatePayment(EthSimilarCoin coin, EthSimilarNetwork network,
            CreateEthPaymentRequest request)
        {
            if (string.IsNullOrEmpty(request.FromAddress))
                throw new ArgumentNullException(nameof(request.FromAddress));
            if (string.IsNullOrEmpty(request.ToAddress))
                throw new ArgumentNullException(nameof(request.ToAddress));
            if (string.IsNullOrEmpty(request.Callback))
                throw new ArgumentNullException(nameof(request.Callback));
            if (request.Confirmations <= 0)
                throw new ArgumentOutOfRangeException(nameof(request.Confirmations), request.Confirmations, "Confirmations is negative or zero");
            if (request.GasPrice.HasValue && request.GasPrice <= 0)
                throw new ArgumentOutOfRangeException(nameof(request.GasPrice), request.GasPrice, "GasPrice is negative or zero");
            if (request.GasLimit.HasValue && request.GasLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(request.GasLimit), request.GasLimit, "GasLimit is negative or zero");

            var response = Client.Execute(
                Request.Post($"{Consts.Blockchain}/{coin}/{network}/payments", request));

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateEthPaymentResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateEthPaymentResponse>(response);
        }

        public GetBtcPaymentsResponse GetPayments(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/payments");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetBtcPaymentsResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetBtcPaymentsResponse>(response);
        }

        public GetEthPaymentsResponse GetPayments(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/payments");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetEthPaymentsResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetEthPaymentsResponse>(response);
        }

        public GetBtcHistoricalPaymentsResponse GetHistoricalPayments(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/payments/history");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetBtcHistoricalPaymentsResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetBtcHistoricalPaymentsResponse>(response);
        }

        public GetEthHistoricalPaymentsResponse GetHistoricalPayments(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/payments/history");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetEthHistoricalPaymentsResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetEthHistoricalPaymentsResponse>(response);
        }

        public DeleteBtcPaymentResponse DeletePayment(BtcSimilarCoin coin, BtcSimilarNetwork network, string paymentId)
        {
            if (string.IsNullOrEmpty(paymentId))
                throw new ArgumentNullException(nameof(paymentId));

            var request = Request.Delete($"{Consts.Blockchain}/{coin}/{network}/payments/{paymentId}");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<DeleteBtcPaymentResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<DeleteBtcPaymentResponse>(response);
        }

        public DeleteEthPaymentResponse DeletePayment(EthSimilarCoin coin, EthSimilarNetwork network, string paymentId)
        {
            if (string.IsNullOrEmpty(paymentId))
                throw new ArgumentNullException(nameof(paymentId));

            var request = Request.Delete($"{Consts.Blockchain}/{coin}/{network}/payments/{paymentId}");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<DeleteEthPaymentResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<DeleteEthPaymentResponse>(response);
        }
    }
}