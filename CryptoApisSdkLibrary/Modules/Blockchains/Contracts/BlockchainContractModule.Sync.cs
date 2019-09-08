using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Contracts
{
    internal partial class BlockchainContractModule
    {
        public EstimateGasContractResponse EstimateGas(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.EstimateGas(coin, network);
            return GetSync<EstimateGasContractResponse>(request);
        }

        public DeployContractResponse Deploy(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, double gasPrice, double gasLimit, string privateKey, string byteCode)
        {
            var request = Requests.Deploy(coin, network,
                fromAddress, gasPrice, gasLimit, privateKey, byteCode);
            return GetSync<DeployContractResponse>(request);
        }
    }
}