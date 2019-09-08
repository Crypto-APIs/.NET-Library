using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Wallets
{
    internal partial class BlockchainWalletModule
    {
        public Task<WalletInfoResponse> CreateWalletAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, IEnumerable<string> addresses)
        {
            var request = Requests.CreateWallet(coin, network, walletName, addresses);
            return GetAsyncResponse<WalletInfoResponse>(request, cancellationToken);
        }

        public Task<HdWalletInfoResponse> CreateHdWalletAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, int addressCount, string password)
        {
            var request = Requests.CreateHdWallet(coin, network, walletName, addressCount, password);
            return GetAsyncResponse<HdWalletInfoResponse>(request, cancellationToken);
        }

        public Task<GetWalletsResponse> GetWalletsAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetWallets(coin, network);
            return GetAsyncResponse<GetWalletsResponse>(request, cancellationToken);
        }

        public Task<GetHdWalletsResponse> GetHdWalletsAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetHdWallets(coin, network);
            return GetAsyncResponse<GetHdWalletsResponse>(request, cancellationToken);
        }

        public Task<WalletInfoResponse> GetWalletInfoAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            var request = Requests.GetWalletInfo(coin, network, walletName);
            return GetAsyncResponse<WalletInfoResponse>(request, cancellationToken);
        }

        public Task<HdWalletInfoResponse> GetHdWalletInfoAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            var request = Requests.GetHdWalletInfo(coin, network, walletName);
            return GetAsyncResponse<HdWalletInfoResponse>(request, cancellationToken);
        }

        public Task<WalletInfoResponse> AddAddressAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, IEnumerable<string> addresses)
        {
            var request = Requests.AddAddress(coin, network, walletName, addresses);
            return GetAsyncResponse<WalletInfoResponse>(request, cancellationToken);
        }

        public Task<GenerateWalletAddressResponse> GenerateAddressAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            var request = Requests.GenerateAddress(coin, network, walletName);
            return GetAsyncResponse<GenerateWalletAddressResponse>(request, cancellationToken);
        }

        public Task<HdWalletInfoResponse> GenerateHdAddressAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, int addressCount, string encryptedPassword)
        {
            var request = Requests.GenerateHdAddress(coin, network, walletName, addressCount, encryptedPassword);
            return GetAsyncResponse<HdWalletInfoResponse>(request, cancellationToken);
        }

        public Task<RemoveAddressResponse> RemoveAddressAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, string address)
        {
            var request = Requests.RemoveAddress(coin, network, walletName, address);
            return GetAsyncResponse<RemoveAddressResponse>(request, cancellationToken);
        }

        public Task<DeleteWalletResponse> DeleteWalletAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            var request = Requests.DeleteWallet(coin, network, walletName);
            return GetAsyncResponse<DeleteWalletResponse>(request, cancellationToken);
        }

        public Task<DeleteWalletResponse> DeleteHdWalletAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName)
        {
            var request = Requests.DeleteHdWallet(coin, network, walletName);
            return GetAsyncResponse<DeleteWalletResponse>(request, cancellationToken);
        }
    }
}