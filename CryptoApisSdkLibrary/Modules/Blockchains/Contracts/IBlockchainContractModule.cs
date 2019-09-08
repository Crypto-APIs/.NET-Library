using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Contracts
{
    public interface IBlockchainContractModule
    {
        /// <summary>
        /// Retuns the average gas price and gas limit set by the Ethereum Blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <see cref=""/>
        EstimateGasContractResponse EstimateGas(EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Retuns the average gas price and gas limit set by the Ethereum Blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <see cref=""/>
        Task<EstimateGasContractResponse> EstimateGasAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Retuns the average gas price and gas limit set by the Ethereum Blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        /// <param name="privateKey">Private key.</param>
        /// <param name="byteCode">Byte code.</param>
        /// <see cref=""/>
        DeployContractResponse Deploy(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, double gasPrice, double gasLimit, string privateKey, string byteCode);

        /// <summary>
        /// Retuns the average gas price and gas limit set by the Ethereum Blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        /// <param name="privateKey">Private key.</param>
        /// <param name="byteCode">Byte code.</param>
        /// <see cref=""/>
        Task<DeployContractResponse> DeployAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, double gasPrice, double gasLimit, string privateKey, string byteCode);
    }
}