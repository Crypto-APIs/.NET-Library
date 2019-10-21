using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.Misc;
using CryptoApisLibrary.RequestTypes;
using RestSharp;
using System;

namespace CryptoApisLibrary.Modules.Blockchains.Addresses
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest GetAddress(NetworkCoin networkCoin, string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            return Request.Get($"{Consts.Blockchain}/{networkCoin}/address/{address}");
        }

        public IRestRequest GenerateAddress(NetworkCoin networkCoin)
        {
            return Request.Post($"{Consts.Blockchain}/{networkCoin}/address");
        }

        public IRestRequest GetAddressInMultisignatureAddresses(
            NetworkCoin networkCoin, string address, int skip, int limit)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");
            if (limit > 50)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, $"The maximum value of limit is 50. Actual value is {limit}");

            var request = Request.Get($"{Consts.Blockchain}/{networkCoin}/address/{address}/multisig");
            request.AddQueryParameter("index", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        public IRestRequest GetAddressTransactions(NetworkCoin networkCoin, string address, int skip, int limit)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");
            if (limit > 50)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, $"The maximum value of limit is 50. Actual value is {limit}");

            var request = Request.Get($"{Consts.Blockchain}/{networkCoin}/address/{address}/transactions");
            request.AddQueryParameter("index", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        public IRestRequest GetNonce(NetworkCoin networkCoin, string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            var request = Request.Get($"{Consts.Blockchain}/{networkCoin}/address/{address}/nonce");
            return request;
        }

        public IRestRequest GenerateAccount(NetworkCoin networkCoin, string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            var request = Request.Post($"{Consts.Blockchain}/{networkCoin}/account",
                new GenerateEthAccountRequest(password));
            return request;
        }

        private CryptoApiRequest Request { get; }
    }
}