using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Contracts
{
    public interface IBlockchainContractModule
    {
        /// <summary>
        /// Retuns the average gas price and gas limit set by the Ethereum Blockchain.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        EstimateGasContractResponse EstimateGas(EthSimilarCoin coin, EthSimilarNetwork network);

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
        DeployContractResponse Deploy(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, double gasPrice, double gasLimit, string privateKey, string byteCode);
    }
}