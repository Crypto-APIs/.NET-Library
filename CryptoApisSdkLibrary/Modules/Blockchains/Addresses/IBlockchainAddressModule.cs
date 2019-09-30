using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Addresses
{
    public interface IBlockchainAddressModule
    {
        /// <summary>
        /// General information about a BTC-similar blockchain.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="address">Address in blockchain.</param>
        GetBtcAddressResponse GetAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string address);

        /// <summary>
        /// General information about a BTC-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="address">Address in blockchain.</param>
        Task<GetBtcAddressResponse> GetAddressAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string address);

        /// <summary>
        /// General information about a ETH-similar blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="address">Address in blockchain.</param>
        GetEthAddressResponse GetAddress(EthSimilarCoin coin, EthSimilarNetwork network, string address);

        /// <summary>
        /// General information about a ETH-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="address">Address in blockchain.</param>
        Task<GetEthAddressResponse> GetAddressAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string address);

        /// <summary>
        /// Allows you to generate private-public key-pairs along with an associated public address for a BTC-similar blockchain.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        GenerateBtcAddressResponse GenerateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Allows you to generate private-public key-pairs along with an associated public address for a BTC-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        Task<GenerateBtcAddressResponse> GenerateAddressAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Allows you to generate private-public key-pairs along with an associated public address for a ETH-similar blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        GenerateEthAddressResponse GenerateAddress(EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Allows you to generate private-public key-pairs along with an associated public address for a ETH-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        Task<GenerateEthAddressResponse> GenerateAddressAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Returns a general information about a single address that is involved in multisignature addresses.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="address">Address in blockchain.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return. The maximum value of limit is 50.</param>
        GetMultisignatureAddressesResponse GetAddressInMultisignatureAddresses(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string address, int skip = 0, int limit = 50);

        /// <summary>
        /// Returns a general information about a single address that is involved in multisignature addresses.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="address">Address in blockchain.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return. The maximum value of limit is 50.</param>
        Task<GetMultisignatureAddressesResponse> GetAddressInMultisignatureAddressesAsync(
            CancellationToken cancellationToken, BtcSimilarCoin coin, BtcSimilarNetwork network,
            string address, int skip = 0, int limit = 50);

        /// <summary>
        /// Returns all information available about a particular address, including an array of complete transactions for a BTC-similar blockchain.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="address">Address in blockchain.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return. The maximum value of limit is 50.</param>
        GetBtcAddressTransactionsResponse GetAddressTransactions(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string address, int skip = 0, int limit = 50);

        /// <summary>
        /// Returns all information available about a particular address, including an array of complete transactions for a BTC-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="address">Address in blockchain.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return. The maximum value of limit is 50.</param>
        Task<GetBtcAddressTransactionsResponse> GetAddressTransactionsAsync(
            CancellationToken cancellationToken, BtcSimilarCoin coin, BtcSimilarNetwork network,
            string address, int skip = 0, int limit = 50);

        /// <summary>
        /// Returns all information available about a particular address, including an array of complete transactions for a ETH-similar blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="address">Address in blockchain.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return. The maximum value of limit is 50.</param>
        GetEthAddressTransactionsResponse GetAddressTransactions(
            EthSimilarCoin coin, EthSimilarNetwork network, string address, int skip = 0, int limit = 50);

        /// <summary>
        /// Returns all information available about a particular address, including an array of complete transactions for a ETH-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="address">Address in blockchain.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return. The maximum value of limit is 50.</param>
        Task<GetEthAddressTransactionsResponse> GetAddressTransactionsAsync(
            CancellationToken cancellationToken, EthSimilarCoin coin, EthSimilarNetwork network,
            string address, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a subset of information on a public address.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="address">Address in blockchain.</param>
        GetEthAddressBalanceResponse GetAddressBalance(EthSimilarCoin coin, EthSimilarNetwork network, string address);

        /// <summary>
        /// Get a subset of information on a public address.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="address">Address in blockchain.</param>
        Task<GetEthAddressBalanceResponse> GetAddressBalanceAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string address);

        /// <summary>
        /// Allows you to generate private-public key-pairs along with an associated public address encoded in a keyfile.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="password"></param>
        GenerateEthAccountResponse GenerateAccount(EthSimilarCoin coin, EthSimilarNetwork network, string password);

        /// <summary>
        /// Allows you to generate private-public key-pairs along with an associated public address encoded in a keyfile.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="password"></param>
        Task<GenerateEthAccountResponse> GenerateAccountAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string password);
    }
}