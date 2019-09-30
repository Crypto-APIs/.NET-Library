using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Addresses
{
    internal partial class BlockchainAddressModule
    {
        public Task<GetBtcAddressResponse> GetAddressAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string address)
        {
            var request = Requests.GetAddress(coin, network, address);
            return GetAsyncResponse<GetBtcAddressResponse>(request, cancellationToken);
        }

        public Task<GetEthAddressResponse> GetAddressAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string address)
        {
            var request = Requests.GetAddress(coin, network, address);
            return GetAsyncResponse<GetEthAddressResponse>(request, cancellationToken);
        }

        public Task<GenerateBtcAddressResponse> GenerateAddressAsync(
            CancellationToken cancellationToken, BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GenerateAddress(coin, network);
            return GetAsyncResponse<GenerateBtcAddressResponse>(request, cancellationToken);
        }

        public Task<GenerateEthAddressResponse> GenerateAddressAsync(CancellationToken cancellationToken, EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.GenerateAddress(coin, network);
            return GetAsyncResponse<GenerateEthAddressResponse>(request, cancellationToken);
        }

        public Task<GetMultisignatureAddressesResponse> GetAddressInMultisignatureAddressesAsync(
            CancellationToken cancellationToken, BtcSimilarCoin coin, BtcSimilarNetwork network,
            string address, int skip = 0, int limit = 50)
        {
            var request = Requests.GetAddressInMultisignatureAddresses(coin, network, address, skip, limit);
            return GetAsyncResponse<GetMultisignatureAddressesResponse>(request, cancellationToken);
        }

        public Task<GetBtcAddressTransactionsResponse> GetAddressTransactionsAsync(
            CancellationToken cancellationToken, BtcSimilarCoin coin, BtcSimilarNetwork network,
            string address, int skip = 0, int limit = 50)
        {
            var request = Requests.GetAddressTransactions(coin, network, address, skip, limit);
            return GetAsyncResponse<GetBtcAddressTransactionsResponse>(request, cancellationToken);
        }

        public Task<GetEthAddressTransactionsResponse> GetAddressTransactionsAsync(
            CancellationToken cancellationToken, EthSimilarCoin coin, EthSimilarNetwork network,
            string address, int skip = 0, int limit = 50)
        {
            var request = Requests.GetAddressTransactions(coin, network, address, skip, limit);
            return GetAsyncResponse<GetEthAddressTransactionsResponse>(request, cancellationToken);
        }

        public Task<GetEthAddressBalanceResponse> GetAddressBalanceAsync(
            CancellationToken cancellationToken, EthSimilarCoin coin, EthSimilarNetwork network,
            string address)
        {
            var request = Requests.GetAddressBalance(coin, network, address);
            return GetAsyncResponse<GetEthAddressBalanceResponse>(request, cancellationToken);
        }

        public Task<GenerateEthAccountResponse> GenerateAccountAsync(
            CancellationToken cancellationToken, EthSimilarCoin coin, EthSimilarNetwork network,
            string password)
        {
            var request = Requests.GenerateAccount(coin, network, password);
            return GetAsyncResponse<GenerateEthAccountResponse>(request, cancellationToken);
        }
    }
}