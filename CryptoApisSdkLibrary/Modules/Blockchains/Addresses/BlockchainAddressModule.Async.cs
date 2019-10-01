using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Addresses
{
    internal partial class BlockchainAddressModule
    {
        public Task<T> GetAddressAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string address)
            where T : GetAddressResponse, new()
        {
            var request = Requests.GetAddress(networkCoin, address);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GenerateAddressAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GenerateAddressResponse, new()
        {
            var request = Requests.GenerateAddress(networkCoin);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetAddressInMultisignatureAddressesAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetMultisignatureAddressesResponse, new()
        {
            var request = Requests.GetAddressInMultisignatureAddresses(networkCoin, address, skip, limit);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetAddressTransactionsAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetAddressTransactionsResponse, new()
        {
            var request = Requests.GetAddressTransactions(networkCoin, address, skip, limit);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetAddressBalanceAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string address)
            where T : GetAddressBalanceResponse, new()
        {
            var request = Requests.GetAddressBalance(networkCoin, address);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GenerateAccountAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string password)
            where T : GenerateAccountResponse, new()
        {
            var request = Requests.GenerateAccount(networkCoin, password);
            return GetAsyncResponse<T>(request, cancellationToken);
        }
    }
}