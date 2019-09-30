using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.RequestTypes;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Addresses
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest GetAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string address)
        {
            return InternalGetAddress(coin, network, address);
        }

        public IRestRequest GetAddress(EthSimilarCoin coin, EthSimilarNetwork network, string address)
        {
            return InternalGetAddress(coin, network, address);
        }

        public IRestRequest GenerateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            return InternalGenerateAddress(coin, network);
        }

        public IRestRequest GenerateAddress(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            return InternalGenerateAddress(coin, network);
        }

        public IRestRequest GetAddressInMultisignatureAddresses(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string address, int skip, int limit)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");
            if (limit > 50)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, $"The maximum value of limit is 50. Actual value is {limit}");

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/address/{address}/multisig");
            request.AddQueryParameter("index", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        public IRestRequest GetAddressTransactions(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string address, int skip, int limit)
        {
            return InternalGetAddressTransactions(coin, network, address, skip, limit);
        }

        public IRestRequest GetAddressTransactions(
            EthSimilarCoin coin, EthSimilarNetwork network, string address, int skip, int limit)
        {
            return InternalGetAddressTransactions(coin, network, address, skip, limit);
        }

        public IRestRequest GetAddressBalance(EthSimilarCoin coin, EthSimilarNetwork network, string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/address/{address}/balance");
            return request;
        }

        public IRestRequest GenerateAccount(EthSimilarCoin coin, EthSimilarNetwork network, string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/account",
                new GenerateEthAccountRequest(password));
            return request;
        }

        private IRestRequest InternalGetAddress(Coin coin, Network network, string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/address/{address}");
        }

        private IRestRequest InternalGenerateAddress(Coin coin, Network network)
        {
            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/address");
        }

        private IRestRequest InternalGetAddressTransactions(
            Coin coin, Network network, string address, int skip, int limit)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");
            if (limit > 50)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, $"The maximum value of limit is 50. Actual value is {limit}");

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/address/{address}/transactions");
            request.AddQueryParameter("index", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            return request;
        }

        private CryptoApiRequest Request { get; }
    }
}