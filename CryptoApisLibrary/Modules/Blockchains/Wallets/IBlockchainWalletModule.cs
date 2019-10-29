using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Blockchains.Wallets
{
    public interface IBlockchainWalletModule
    {
        /// <summary>
        /// Create normal wallet.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addresses">Array of addresses that will be added to wallet.</param>
        T CreateWallet<T>(NetworkCoin networkCoin, string walletName, IEnumerable<string> addresses)
            where T : WalletInfoResponse, new();

        /// <summary>
        /// Create normal wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addresses">Array of addresses that will be added to wallet.</param>
        Task<T> CreateWalletAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName, IEnumerable<string> addresses)
            where T : WalletInfoResponse, new();

        /// <summary>
        /// Create Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addressCount">Number of addresses that should be generated in new wallet.</param>
        /// <param name="password">Wallet password.</param>
        T CreateHdWallet<T>(NetworkCoin networkCoin, string walletName, int addressCount, string password)
            where T : HdWalletInfoResponse, new();

        /// <summary>
        /// Create Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addressCount">Number of addresses that should be generated in new wallet.</param>
        /// <param name="password">Wallet password.</param>
        Task<T> CreateHdWalletAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName, int addressCount, string password)
            where T : HdWalletInfoResponse, new();

        /// <summary>
        /// Get list of all wallets.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        T GetWallets<T>(NetworkCoin networkCoin)
            where T : GetWalletsResponse, new();

        /// <summary>
        /// Get list of all wallets.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        Task<T> GetWalletsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GetWalletsResponse, new();

        /// <summary>
        /// Get list of all Hierarchical Deterministic (HD) wallets.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        T GetHdWallets<T>(NetworkCoin networkCoin)
            where T : GetHdWalletsResponse, new();

        /// <summary>
        /// Get list of all Hierarchical Deterministic (HD) wallets.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        Task<T> GetHdWalletsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GetHdWalletsResponse, new();

        /// <summary>
        /// Get information about the wallets.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        T GetWalletInfo<T>(NetworkCoin networkCoin, string walletName)
            where T : WalletInfoResponse, new();

        /// <summary>
        /// Get information about the wallets.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        Task<T> GetWalletInfoAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string walletName)
            where T : WalletInfoResponse, new();

        /// <summary>
        /// Get information about the Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        T GetHdWalletInfo<T>(NetworkCoin networkCoin, string walletName)
            where T : HdWalletInfoResponse, new();

        /// <summary>
        /// Get information about the Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        Task<T> GetHdWalletInfoAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string walletName)
            where T : HdWalletInfoResponse, new();

        /// <summary>
        /// Add addresses to the wallet.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addresses">Array of addresses that will be added to wallet.</param>
        T AddAddress<T>(NetworkCoin networkCoin, string walletName, IEnumerable<string> addresses)
            where T : WalletInfoResponse, new();

        /// <summary>
        /// Add addresses to the wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addresses">Array of addresses that will be added to wallet.</param>
        Task<T> AddAddressAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName, IEnumerable<string> addresses)
            where T : WalletInfoResponse, new();

        /// <summary>
        /// Add addresses to the normal wallet.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        T GenerateAddress<T>(NetworkCoin networkCoin, string walletName)
            where T : GenerateWalletAddressResponse, new();

        /// <summary>
        /// Add addresses to the normal wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        Task<T> GenerateAddressAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string walletName)
            where T : GenerateWalletAddressResponse, new();

        /// <summary>
        /// Add addresses to the Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addressCount">Count of generated addresses.</param>
        /// <param name="encryptedPassword">Encrypted password</param>
        T GenerateHdAddress<T>(NetworkCoin networkCoin, string walletName, int addressCount, string encryptedPassword)
            where T : HdWalletInfoResponse, new();

        /// <summary>
        /// Add addresses to the Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addressCount">Count of generated addresses.</param>
        /// <param name="encryptedPassword">Encrypted password</param>
        Task<T> GenerateHdAddressAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName, int addressCount, string encryptedPassword)
            where T : HdWalletInfoResponse, new();

        /// <summary>
        /// Remove address from the wallet.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="address">Address which should be deleted.</param>
        T RemoveAddress<T>(NetworkCoin networkCoin, string walletName, string address)
            where T : RemoveAddressResponse, new();

        /// <summary>
        /// Remove address from the wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="address">Address which should be deleted.</param>
        Task<T> RemoveAddressAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string walletName, string address)
            where T : RemoveAddressResponse, new();

        /// <summary>
        /// Delete wallet.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        T DeleteWallet<T>(NetworkCoin networkCoin, string walletName)
            where T : DeleteWalletResponse, new();

        /// <summary>
        /// Delete wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        Task<T> DeleteWalletAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string walletName)
            where T : DeleteWalletResponse, new();

        /// <summary>
        /// Delete Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">HD-wallet name.</param>
        T DeleteHdWallet<T>(NetworkCoin networkCoin, string walletName)
            where T : DeleteWalletResponse, new();

        /// <summary>
        ///
        /// Delete Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">HD-wallet name.</param>
        Task<T> DeleteHdWalletAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string walletName)
            where T : DeleteWalletResponse, new();

        /// <summary>
        /// Create a random extended public key (based on your password), xpriv and wif.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="password">Wallet password.</param>
        T CreateXPub<T>(NetworkCoin networkCoin, string password)
            where T : CreateXPubResponse, new();

        /// <summary>
        /// Create a random extended public key (based on your password), xpriv and wif.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="password">Wallet password.</param>
        Task<T> CreateXPubAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string password)
            where T : CreateXPubResponse, new();

        /// <summary>
        /// Get the change(KeyPurpose: Change) addresses associated with the specified xpub.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="xpub">XPub.</param>
        /// <param name="startIndex">Start index of collection.</param>
        /// <param name="finishIndex">Finish index of collection.</param>
        T GetXPubChangeAddresses<T>(NetworkCoin networkCoin, string xpub, int startIndex, int finishIndex)
            where T : GetXPubAddressesResponse, new();

        /// <summary>
        /// Get the change(KeyPurpose: Change) addresses associated with the specified xpub.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="xpub">XPub.</param>
        /// <param name="startIndex">Start index of collection.</param>
        /// <param name="finishIndex">Finish index of collection.</param>
        Task<T> GetXPubChangeAddressesAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            string xpub, int startIndex, int finishIndex)
            where T : GetXPubAddressesResponse, new();

        /// <summary>
        /// Get the receive(KeyPurpose: RECEIVE_FUNDS) addresses associated with the specified xpub.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="xpub">XPub.</param>
        /// <param name="startIndex">Start index of collection.</param>
        /// <param name="finishIndex">Finish index of collection.</param>
        T GetXPubReceiveAddresses<T>(NetworkCoin networkCoin, string xpub, int startIndex, int finishIndex)
            where T : GetXPubAddressesResponse, new();

        /// <summary>
        /// Get the receive(KeyPurpose: RECEIVE_FUNDS) addresses associated with the specified xpub.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="xpub">XPub.</param>
        /// <param name="startIndex">Start index of collection.</param>
        /// <param name="finishIndex">Finish index of collection.</param>
        Task<T> GetXPubReceiveAddressesAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            string xpub, int startIndex, int finishIndex)
            where T : GetXPubAddressesResponse, new();

        /// <summary>
        /// This endpoint allows you to import an address.
        /// Although it is only an address it will be treated as an HDwallet.
        /// Therefore, with the imported wallet users can make transactions and payment forwardings.
        /// Moreover, imported wallets can be listed and deleted.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="password">Wallet password.</param>
        /// <param name="privateKey">Private key.</param>
        /// <param name="address">Address.</param>
        T ImportAddressAsWallet<T>(NetworkCoin networkCoin, string walletName, string password, string privateKey, string address)
            where T : ImportAddressAsWalletResponse, new();

        /// <summary>
        /// This endpoint allows you to import an address.
        /// Although it is only an address it will be treated as an HDwallet.
        /// Therefore, with the imported wallet users can make transactions and payment forwardings.
        /// Moreover, imported wallets can be listed and deleted.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, DASH on Testnet, ...)</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="password">Wallet password.</param>
        /// <param name="privateKey">Private key.</param>
        /// <param name="address">Address.</param>
        Task<T> ImportAddressAsWalletAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            string walletName, string password, string privateKey, string address)
            where T : ImportAddressAsWalletResponse, new();
    }
}