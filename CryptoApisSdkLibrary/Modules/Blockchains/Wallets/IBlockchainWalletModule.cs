using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Wallets
{
    public interface IBlockchainWalletModule
    {
        /// <summary>
        /// Create normal wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addresses">Array of addresses that will be added to wallet.</param>
        WalletInfoResponse CreateWallet(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, IEnumerable<string> addresses);

        /// <summary>
        /// Create normal wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addresses">Array of addresses that will be added to wallet.</param>
        Task<WalletInfoResponse> CreateWalletAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, IEnumerable<string> addresses);

        /// <summary>
        /// Create Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addressCount">Number of addresses that should be generated in new wallet.</param>
        /// <param name="password">Wallet password.</param>
        HdWalletInfoResponse CreateHdWallet(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, int addressCount, string password);

        /// <summary>
        /// Create Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addressCount">Number of addresses that should be generated in new wallet.</param>
        /// <param name="password">Wallet password.</param>
        Task<HdWalletInfoResponse> CreateHdWalletAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, int addressCount, string password);

        /// <summary>
        /// Get list of all wallets.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        GetWalletsResponse GetWallets(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Get list of all wallets.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        Task<GetWalletsResponse> GetWalletsAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Get list of all Hierarchical Deterministic (HD) wallets.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        GetHdWalletsResponse GetHdWallets(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Get list of all Hierarchical Deterministic (HD) wallets.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        Task<GetHdWalletsResponse> GetHdWalletsAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Get information about the wallets.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        WalletInfoResponse GetWalletInfo(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);

        /// <summary>
        /// Get information about the wallets.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        Task<WalletInfoResponse> GetWalletInfoAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);

        /// <summary>
        /// Get information about the Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        HdWalletInfoResponse GetHdWalletInfo(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);

        /// <summary>
        /// Get information about the Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        Task<HdWalletInfoResponse> GetHdWalletInfoAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);

        /// <summary>
        /// Add addresses to the wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addresses">Array of addresses that will be added to wallet.</param>
        WalletInfoResponse AddAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, IEnumerable<string> addresses);

        /// <summary>
        /// Add addresses to the wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addresses">Array of addresses that will be added to wallet.</param>
        Task<WalletInfoResponse> AddAddressAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, IEnumerable<string> addresses);

        /// <summary>
        /// Add addresses to the normal wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        GenerateWalletAddressResponse GenerateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);

        /// <summary>
        /// Add addresses to the normal wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        Task<GenerateWalletAddressResponse> GenerateAddressAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);

        /// <summary>
        /// Add addresses to the Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addressCount">Count of generated addresses.</param>
        /// <param name="encryptedPassword">Encrypted password</param>
        HdWalletInfoResponse GenerateHdAddress(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, int addressCount, string encryptedPassword);

        /// <summary>
        /// Add addresses to the Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addressCount">Count of generated addresses.</param>
        /// <param name="encryptedPassword">Encrypted password</param>
        Task<HdWalletInfoResponse> GenerateHdAddressAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, int addressCount, string encryptedPassword);

        /// <summary>
        /// Remove address from the wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="address">Address which should be deleted.</param>
        RemoveAddressResponse RemoveAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, string address);

        /// <summary>
        /// Remove address from the wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="address">Address which should be deleted.</param>
        Task<RemoveAddressResponse> RemoveAddressAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, string address);

        /// <summary>
        /// Delete wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        DeleteWalletResponse DeleteWallet(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);

        /// <summary>
        /// Delete wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        Task<DeleteWalletResponse> DeleteWalletAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);

        /// <summary>
        /// Delete Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        DeleteWalletResponse DeleteHdWallet(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);

        /// <summary>
        /// Delete Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        Task<DeleteWalletResponse> DeleteHdWalletAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);
    }
}