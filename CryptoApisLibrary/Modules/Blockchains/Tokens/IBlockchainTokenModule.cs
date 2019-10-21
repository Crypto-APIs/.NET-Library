using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Blockchains.Tokens
{
    public interface IBlockchainTokenModule
    {
        /// <summary>
        /// Get token balances of adressess, as well as to transfer tokens from one address to another.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address with tokens.</param>
        /// <param name="contract">Contract address.</param>
        T GetBalance<T>(NetworkCoin networkCoin, string address, string contract)
            where T : GetBalanceTokenResponse, new();

        /// <summary>
        /// Get token balances of adressess, as well as to transfer tokens from one address to another.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address with tokens.</param>
        /// <param name="contract">Contract address.</param>
        Task<T> GetBalanceAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string address, string contract)
            where T : GetBalanceTokenResponse, new();

        /// <summary>
        /// Transfer Tokens using password.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="contract">Contract address.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        /// <param name="password">Password.</param>
        /// <param name="amount">The amount of token is per unit.</param>
        T Transfer<T>(NetworkCoin networkCoin, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, string password, double amount)
            where T : TransferTokensResponse, new();

        /// <summary>
        /// Transfer Tokens using password.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="contract">Contract address.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        /// <param name="password">Password.</param>
        /// <param name="amount">The amount of token is per unit.</param>
        Task<T> TransferAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, string password, double amount)
            where T : TransferTokensResponse, new();

        /// <summary>
        /// Transfer Tokens using private key.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="contract">Contract address.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        /// <param name="amount">The amount of token is per unit.</param>
        /// <param name="privateKey">Private key.</param>
        T Transfer<T>(NetworkCoin networkCoin, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, double amount, string privateKey)
            where T : TransferTokensResponse, new();

        /// <summary>
        /// Transfer Tokens using private key.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="contract">Contract address.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        /// <param name="amount">The amount of token is per unit.</param>
        /// <param name="privateKey">Private key.</param>
        Task<T> TransferAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress,
            string contract, double gasPrice, double gasLimit, double amount, string privateKey)
            where T : TransferTokensResponse, new();

        /// <summary>
        /// Get list of each transfer for the specified address.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address with tokens.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        T GetTokens<T>(NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetEthTokensResponse, new();

        /// <summary>
        /// Get list of each transfer for the specified address.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address with tokens.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        Task<T> GetTokensAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetEthTokensResponse, new();

        /// <summary>
        /// Get list of token transactions for the specified address.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address with tokens.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        T GetTransactions<T>(NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetEthTransactionsResponse, new();

        /// <summary>
        /// Get list of token transactions for the specified address.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="address">Address with tokens.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        Task<T> GetTransactionsAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string address, int skip = 0, int limit = 50)
            where T : GetEthTransactionsResponse, new();

        /// <summary>
        /// Get list of token transactions for the specified address.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="contract">Contract address.</param>
        T GetTokenTotalSupplyAndDecimals<T>(NetworkCoin networkCoin, string contract)
            where T : GetTokenTotalSupplyAndDecimalsResponse, new();

        /// <summary>
        /// Get list of token transactions for the specified address.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="contract">Contract address.</param>
        Task<T> GetTokenTotalSupplyAndDecimalsAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string contract)
            where T : GetTokenTotalSupplyAndDecimalsResponse, new();
    }
}