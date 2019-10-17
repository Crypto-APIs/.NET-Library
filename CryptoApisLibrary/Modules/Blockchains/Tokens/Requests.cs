using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.Misc;
using CryptoApisLibrary.RequestTypes;
using RestSharp;
using System;

namespace CryptoApisLibrary.Modules.Blockchains.Tokens
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest GetBalance(NetworkCoin networkCoin, string address, string contract)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));
            if (string.IsNullOrEmpty(contract))
                throw new ArgumentNullException(nameof(contract));

            return Request.Get($"{Consts.Blockchain}/{networkCoin}/tokens/{address}/{contract}/balance");
        }

        public IRestRequest Transfer(NetworkCoin networkCoin, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, string password, double amount)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            return InternalTransfer(networkCoin,
                new TransferTokensWithPasswordRequest(fromAddress, toAddress, contract, gasPrice, gasLimit, amount, password));
        }

        public IRestRequest Transfer(NetworkCoin networkCoin, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, double amount, string privateKey)
        {
            if (string.IsNullOrEmpty(privateKey))
                throw new ArgumentNullException(nameof(privateKey));

            return InternalTransfer(networkCoin,
                new TransferTokensWithPrivateKeyRequest(fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey));
        }

        public IRestRequest GetTokens(NetworkCoin networkCoin, string address, int skip, int limit)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.Blockchain}/{networkCoin}/tokens/address/{address}");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        private IRestRequest InternalTransfer(NetworkCoin networkCoin, TransferTokensRequest request)
        {
            if (string.IsNullOrEmpty(request.FromAddress))
                throw new ArgumentNullException(nameof(request.FromAddress));
            if (string.IsNullOrEmpty(request.ToAddress))
                throw new ArgumentNullException(nameof(request.ToAddress));
            if (string.IsNullOrEmpty(request.Contract))
                throw new ArgumentNullException(nameof(request.Contract));
            if (request.GasPrice <= 0)
                throw new ArgumentOutOfRangeException(nameof(request.GasPrice), request.GasPrice, "GasPrice is negative or zero");
            if (request.GasLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(request.GasLimit), request.GasLimit, "GasLimit is negative or zero");
            if (request.Amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(request.Amount), request.Amount, "Amount is negative or zero");

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/tokens/transfer");
        }

        private CryptoApiRequest Request { get; }
    }
}