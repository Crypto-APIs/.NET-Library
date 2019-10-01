using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Info
{
    public interface IBlockchainInfoModule
    {
        /// <summary>
        /// General information about a blockchain.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        T GetInfo<T>(NetworkCoin networkCoin)
            where T : GetInfoResponse, new();

        /// <summary>
        /// General information about a blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        Task<T> GetInfoAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GetInfoResponse, new();

        /// <summary>
        /// Information for particular block in a blockchain.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHash">Hash of the block in blockchain.</param>
        T GetBlockHash<T>(NetworkCoin networkCoin, string blockHash)
            where T : GetHashInfoResponse, new();

        /// <summary>
        /// Information for particular block in the BTC-similar blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHash">Hash of the block in blockchain.</param>
        Task<T> GetBlockHashAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string blockHash)
            where T : GetHashInfoResponse, new();

        /// <summary>
        /// Information for particular block in a blockchain.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHeight">Height of the block in blockchain.</param>
        T GetBlockHeight<T>(NetworkCoin networkCoin, int blockHeight)
            where T : GetHashInfoResponse, new();

        /// <summary>
        /// Information for particular block in a blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHeight">Height of the block in blockchain.</param>
        Task<T> GetBlockHeightAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, int blockHeight)
            where T : GetHashInfoResponse, new();

        /// <summary>
        /// Information for the latest block in the BTC-similar blockchain.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        T GetLatestBlock<T>(NetworkCoin networkCoin)
            where T : GetHashInfoResponse, new();

        /// <summary>
        /// Information for the latest block in a blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        Task<T> GetLatestBlockAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GetHashInfoResponse, new();
    }
}