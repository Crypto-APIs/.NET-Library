using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.RequestTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using RestSharp;
using System;
using System.Diagnostics;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Addresses
{
    internal class BlockchainAddressModule : BaseModule, IBlockchainAddressModule
    {
        public BlockchainAddressModule(IRestClient client, CryptoApiRequest request) : base(client, request)
        {
        }

        public GetBtcAddressResponse GetAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string address)
        {
            var response = GetAddressResponse(coin, network, address);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetBtcAddressResponse>(response);
                var data = responseObject.Data;
                if (coin != BtcSimilarCoin.Bch && data?.Payload != null)
                {
                    Debug.Assert(data.Payload.Legacy == null);
                }
                return data;
            }
            return MakeErrorMessage<GetBtcAddressResponse>(response);
        }

        public GetEthAddressResponse GetAddress(EthSimilarCoin coin, EthSimilarNetwork network, string address)
        {
            var response = GetAddressResponse(coin, network, address);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetEthAddressResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetEthAddressResponse>(response);
        }

        public GenerateBtcAddressResponse GenerateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var response = GenerateAddressResponse(coin, network);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GenerateBtcAddressResponse>(response);
                var data = responseObject.Data;
                if (coin != BtcSimilarCoin.Bch && data?.Payload != null)
                {
                    Debug.Assert(data.Payload.Bch == null);
                }
                return data;
            }
            return MakeErrorMessage<GenerateBtcAddressResponse>(response);
        }


        public GetMultisignatureAddressesResponse GetAddressInMultisignatureAddresses(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string address, int skip = 0, int limit = 50)
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
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetMultisignatureAddressesResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetMultisignatureAddressesResponse>(response);
        }

        public GenerateEthAddressResponse GenerateAddress(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var response = GenerateAddressResponse(coin, network);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GenerateEthAddressResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GenerateEthAddressResponse>(response);
        }

        public GetBtcAddressTransactionsResponse GetAddressTransactions(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string address, int skip = 0, int limit = 50)
        {
            var response = GetAddressTransactionsResponse(coin, network, address, skip, limit);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetBtcAddressTransactionsResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetBtcAddressTransactionsResponse>(response);
        }

        public GetEthAddressTransactionsResponse GetAddressTransactions(
            EthSimilarCoin coin, EthSimilarNetwork network, string address, int skip = 0, int limit = 50)
        {
            var response = GetAddressTransactionsResponse(coin, network, address, skip, limit);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetEthAddressTransactionsResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetEthAddressTransactionsResponse>(response);
        }

        public GetEthAddressBalanceResponse GetAddressBalance(EthSimilarCoin coin, EthSimilarNetwork network, string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/address/{address}/balance");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetEthAddressBalanceResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetEthAddressBalanceResponse>(response);
        }

        public GenerateEthAccountResponse GenerateAccount(EthSimilarCoin coin, EthSimilarNetwork network, string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/account",
                new GenerateEthAccountRequest(password));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GenerateEthAccountResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GenerateEthAccountResponse>(response);
        }

        private IRestResponse GetAddressResponse(Coin coin, Network network, string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/address/{address}");
            return Client.Execute(request);
        }

        private IRestResponse GenerateAddressResponse(Coin coin, Network network)
        {
            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/address");
            return Client.Execute(request);
        }

        private IRestResponse GetAddressTransactionsResponse(Coin coin, Network network, string address, int skip, int limit)
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
            return Client.Execute(request);
        }
    }
}