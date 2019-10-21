using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Blockchains.Tokens
{
    internal partial class BlockchainTokenModule
    {
        public Task<T> GetBalanceAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            string address, string contract)
            where T : GetBalanceTokenResponse, new()
        {
            var request = Requests.GetBalance(networkCoin, address, contract);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> TransferAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            string fromAddress, string toAddress, string contract, double gasPrice, double gasLimit, string password, double amount)
            where T : TransferTokensResponse, new()
        {
            var request = Requests.Transfer(networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, password, amount);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> TransferAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            string fromAddress, string toAddress, string contract, double gasPrice, double gasLimit, double amount, string privateKey)
            where T : TransferTokensResponse, new()
        {
            var request = Requests.Transfer(networkCoin, fromAddress, toAddress, contract, gasPrice, gasLimit, amount, privateKey);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetTokensAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string address,
            int skip = 0, int limit = 50)
            where T : GetEthTokensResponse, new()
        {
            var request = Requests.GetTokens(networkCoin, address, skip, limit);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetTransactionsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            string address, int skip = 0, int limit = 50) where T : GetEthTransactionsResponse, new()
        {
            var request = Requests.GetTransactions(networkCoin, address, skip, limit);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetTokenTotalSupplyAndDecimalsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            string contract) where T : GetTokenTotalSupplyAndDecimalsResponse, new()
        {
            var request = Requests.GetTokenTotalSupplyAndDecimalsAsync(networkCoin, contract);
            return GetAsyncResponse<T>(request, cancellationToken);
        }
    }
}