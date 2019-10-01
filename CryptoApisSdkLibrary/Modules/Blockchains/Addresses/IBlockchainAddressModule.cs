using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Addresses
{
    public interface IBlockchainAddressModule
    {
        /// <summary>
        /// General information about a blockchain.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address in blockchain.</param>
        T GetAddress<T>(NetworkCoin networkCoin, string address) where T : GetAddressResponse, new();

        /// <summary>
        /// General information about a blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address in blockchain.</param>
        Task<T> GetAddressAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string address)
            where T : GetAddressResponse, new();

        /// <summary>
        /// Allows you to generate private-public key-pairs along with an associated public address for a blockchain.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        T GenerateAddress<T>(NetworkCoin networkCoin) where T : GenerateAddressResponse, new();

        /// <summary>
        /// Allows you to generate private-public key-pairs along with an associated public address for a blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        Task<T> GenerateAddressAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GenerateAddressResponse, new();

        /// <summary>
        /// Returns a general information about a single address that is involved in multisignature addresses.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address in blockchain.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return. The maximum value of limit is 50.</param>
        T GetAddressInMultisignatureAddresses<T>(
            NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetMultisignatureAddressesResponse, new();

        /// <summary>
        /// Returns a general information about a single address that is involved in multisignature addresses.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address in blockchain.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return. The maximum value of limit is 50.</param>
        Task<T> GetAddressInMultisignatureAddressesAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetMultisignatureAddressesResponse, new();

        /// <summary>
        /// Returns all information available about a particular address, including an array of complete transactions for a blockchain.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address in blockchain.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return. The maximum value of limit is 50.</param>
        T GetAddressTransactions<T>(NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetAddressTransactionsResponse, new();

        /// <summary>
        /// Returns all information available about a particular address, including an array of complete transactions for a blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address in blockchain.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return. The maximum value of limit is 50.</param>
        Task<T> GetAddressTransactionsAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetAddressTransactionsResponse, new();

        /// <summary>
        /// Get a subset of information on a public address.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address in blockchain.</param>
        T GetAddressBalance<T>(NetworkCoin networkCoin, string address)
            where T : GetAddressBalanceResponse, new();

        /// <summary>
        /// Get a subset of information on a public address.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address in blockchain.</param>
        Task<T> GetAddressBalanceAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string address)
            where T : GetAddressBalanceResponse, new();

        /// <summary>
        /// Allows you to generate private-public key-pairs along with an associated public address encoded in a keyfile.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="password"></param>
        T GenerateAccount<T>(NetworkCoin networkCoin, string password)
            where T : GenerateAccountResponse, new();

        /// <summary>
        /// Allows you to generate private-public key-pairs along with an associated public address encoded in a keyfile.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="password"></param>
        Task<T> GenerateAccountAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string password)
            where T : GenerateAccountResponse, new();
    }
}