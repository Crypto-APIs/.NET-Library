using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Collections.Generic;

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
        /// <see cref=""/>
        WalletInfoResponse CreateWallet(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, IEnumerable<string> addresses);

        /// <summary>
        /// Create Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addressCount">Number of addresses that should be generated in new wallet.</param>
        /// <param name="password">Wallet password.</param>
        /// <see cref=""/>
        HdWalletInfoResponse CreateHdWallet(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, int addressCount, string password);

        /// <summary>
        /// Get list of all wallets.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <see cref=""/>
        GetWalletsResponse GetWallets(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Get list of all Hierarchical Deterministic (HD) wallets.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <see cref=""/>
        GetHdWalletsResponse GetHdWallets(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Get information about the wallets.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <see cref=""/>
        WalletInfoResponse GetWalletInfo(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);

        /// <summary>
        /// Get information about the Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <see cref=""/>
        HdWalletInfoResponse GetHdWalletInfo(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);

        /// <summary>
        /// Add addresses to the wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addresses">Array of addresses that will be added to wallet.</param>
        /// <see cref=""/>
        WalletInfoResponse AddAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, IEnumerable<string> addresses);

        /// <summary>
        /// Add addresses to the normal wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <see cref=""/>
        GenerateWalletAddressResponse GenerateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);

        /// <summary>
        /// Add addresses to the Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="addressCount">Count of generated addresses.</param>
        /// <param name="encryptedPassword">Encrypted password</param>
        /// <see cref=""/>
        HdWalletInfoResponse GenerateHdAddress(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string walletName, int addressCount, string encryptedPassword);

        /// <summary>
        /// Remove address from the wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <param name="address">Address which should be deleted.</param>
        /// <see cref=""/>
        RemoveAddressResponse RemoveAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName, string address);

        /// <summary>
        /// Delete wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <see cref=""/>
        DeleteWalletResponse DeleteWallet(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);

        /// <summary>
        /// Delete Hierarchical Deterministic (HD) wallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="walletName">Wallet name.</param>
        /// <see cref=""/>
        DeleteWalletResponse DeleteHdWallet(BtcSimilarCoin coin, BtcSimilarNetwork network, string walletName);
    }
}