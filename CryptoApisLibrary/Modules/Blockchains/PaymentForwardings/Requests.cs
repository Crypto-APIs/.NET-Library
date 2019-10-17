using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.Misc;
using CryptoApisLibrary.RequestTypes;
using RestSharp;
using System;

namespace CryptoApisLibrary.Modules.Blockchains.PaymentForwardings
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest CreatePayment(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string callbackUrl, string wallet, string password,
            int confirmations, double? fee)
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

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/payments",
                new CreateBtcPaymentRequest(fromAddress, toAddress, callbackUrl, wallet, password, confirmations, fee));
        }

        public IRestRequest CreatePayment(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string callbackUrl, string password,
            int confirmations, double? gasPrice, double? gasLimit)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            var paymentRequest = new CreateEthPaymentPasswordRequest(
                fromAddress, toAddress, callbackUrl, password,
                confirmations, gasPrice, gasLimit);
            return InternalCreatePayment(networkCoin, paymentRequest);
        }

        public IRestRequest CreatePaymentUsingPrivateKey(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string callbackUrl, string privateKey,
            int confirmations, double? gasPrice, double? gasLimit)
        {
            if (string.IsNullOrEmpty(privateKey))
                throw new ArgumentNullException(nameof(privateKey));

            var paymentRequest = new CreateEthPaymentPrivateKeyRequest(
                fromAddress, toAddress, callbackUrl, privateKey,
                confirmations, gasPrice, gasLimit);
            return InternalCreatePayment(networkCoin, paymentRequest);
        }

        public IRestRequest GetPayments(NetworkCoin networkCoin)
        {
            return Request.Get($"{Consts.Blockchain}/{networkCoin}/payments");
        }

        public IRestRequest GetHistoricalPayments(NetworkCoin networkCoin)
        {
            return Request.Get($"{Consts.Blockchain}/{networkCoin}/payments/history");
        }

        public IRestRequest DeletePayment(NetworkCoin networkCoin, string paymentId)
        {
            if (string.IsNullOrEmpty(paymentId))
                throw new ArgumentNullException(nameof(paymentId));

            return Request.Delete($"{Consts.Blockchain}/{networkCoin}/payments/{paymentId}");
        }

        private IRestRequest InternalCreatePayment(NetworkCoin networkCoin,
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

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/payments", request);
        }

        private CryptoApiRequest Request { get; }
    }
}