using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Blockchains.Contracts
{
    public interface IBlockchainContractModule
    {
        /// <summary>
        /// Retuns the average gas price and gas limit set by the Ethereum Blockchain.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        T EstimateGas<T>(NetworkCoin networkCoin)
            where T : EstimateGasContractResponse, new();

        /// <summary>
        /// Retuns the average gas price and gas limit set by the Ethereum Blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        Task<T> EstimateGasAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : EstimateGasContractResponse, new();

        /// <summary>
        /// Retuns the average gas price and gas limit set by the Ethereum Blockchain.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        /// <param name="privateKey">Private key.</param>
        /// <param name="byteCode">Byte code.</param>
        T Deploy<T>(NetworkCoin networkCoin, string fromAddress,
            double gasPrice, double gasLimit, string privateKey, string byteCode)
            where T : DeployContractResponse, new();

        /// <summary>
        /// Retuns the average gas price and gas limit set by the Ethereum Blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        /// <param name="privateKey">Private key.</param>
        /// <param name="byteCode">Byte code.</param>
        Task<T> DeployAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            string fromAddress, double gasPrice, double gasLimit, string privateKey, string byteCode)
            where T : DeployContractResponse, new();
    }
}