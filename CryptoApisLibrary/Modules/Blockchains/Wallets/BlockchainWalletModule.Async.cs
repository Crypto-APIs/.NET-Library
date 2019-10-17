using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Blockchains.Wallets
{
    internal partial class BlockchainWalletModule
    {
        public Task<T> CreateWalletAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName, IEnumerable<string> addresses)
            where T : WalletInfoResponse, new()
        {
            var request = Requests.CreateWallet(networkCoin, walletName, addresses);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> CreateHdWalletAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName, int addressCount, string password)
            where T : HdWalletInfoResponse, new()
        {
            var request = Requests.CreateHdWallet(networkCoin, walletName, addressCount, password);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetWalletsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GetWalletsResponse, new()
        {
            var request = Requests.GetWallets(networkCoin);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetHdWalletsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GetHdWalletsResponse, new()
        {
            var request = Requests.GetHdWallets(networkCoin);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetWalletInfoAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName)
            where T : WalletInfoResponse, new()
        {
            var request = Requests.GetWalletInfo(networkCoin, walletName);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetHdWalletInfoAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName)
            where T : HdWalletInfoResponse, new()
        {
            var request = Requests.GetHdWalletInfo(networkCoin, walletName);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> AddAddressAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName, IEnumerable<string> addresses)
            where T : WalletInfoResponse, new()
        {
            var request = Requests.AddAddress(networkCoin, walletName, addresses);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GenerateAddressAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName)
            where T : GenerateWalletAddressResponse, new()
        {
            var request = Requests.GenerateAddress(networkCoin, walletName);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GenerateHdAddressAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName, int addressCount, string encryptedPassword)
            where T : HdWalletInfoResponse, new()
        {
            var request = Requests.GenerateHdAddress(networkCoin, walletName, addressCount, encryptedPassword);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> RemoveAddressAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName, string address)
            where T : RemoveAddressResponse, new()
        {
            var request = Requests.RemoveAddress(networkCoin, walletName, address);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> DeleteWalletAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName)
            where T : DeleteWalletResponse, new()
        {
            var request = Requests.DeleteWallet(networkCoin, walletName);
            return GetAsyncResponse<T>(request, cancellationToken);
        }
    }
}