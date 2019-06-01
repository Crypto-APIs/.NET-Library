using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.RequestTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Tokens
{
    internal class BlockchainTokenModule : BaseModule, IBlockchainTokenModule
    {
        public BlockchainTokenModule(IRestClient client, CryptoApiRequest request) : base(client, request)
        {
        }

        public GetBalanceTokenResponse GetBalance(EthSimilarCoin coin, EthSimilarNetwork network, string address, string contract)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));
            if (string.IsNullOrEmpty(contract))
                throw new ArgumentNullException(nameof(contract));

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/tokens/{address}/{contract}/balance");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetBalanceTokenResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetBalanceTokenResponse>(response);
        }

        public TransferTokensResponse Transfer(EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, string password, double amount)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            return InternalTransfer(coin, network,
                new TransferTokensWithPasswordRequest(fromAddress, toAddress, contract, gasPrice, gasLimit, amount, password));
        }

        public TransferTokensResponse Transfer(EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, double amount, string privateKey)
        {
            if (string.IsNullOrEmpty(privateKey))
                throw new ArgumentNullException(nameof(privateKey));

            return InternalTransfer(coin, network,
                new TransferTokensWithPrivateKeyRequest(fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey));
        }

        public GetTokensResponse GetTokens(EthSimilarCoin coin, EthSimilarNetwork network, string address, int skip = 0, int limit = 50)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/tokens/address/{address}");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetTokensResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetTokensResponse>(response);
        }

        private TransferTokensResponse InternalTransfer(EthSimilarCoin coin, EthSimilarNetwork network,
            TransferTokensRequest request)
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

            var response = Client.Execute(Request.Post($"{Consts.Blockchain}/{coin}/{network}/tokens/transfer", request));

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<TransferTokensResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<TransferTokensResponse>(response);
        }
    }
}