using System.Threading;
using System.Threading.Tasks;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Contracts
{
    internal partial class BlockchainContractModule
    {
        public Task<EstimateGasContractResponse> EstimateGasAsync(CancellationToken cancellationToken, 
            EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.EstimateGas(coin, network);
            return GetAsyncResponse<EstimateGasContractResponse>(request, cancellationToken);

        }

        public Task<DeployContractResponse> DeployAsync(CancellationToken cancellationToken, 
            EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, 
            double gasPrice, double gasLimit, string privateKey, string byteCode)
        {
            var request = Requests.Deploy(coin, network, fromAddress, gasPrice, gasLimit, privateKey, byteCode);
            return GetAsyncResponse<DeployContractResponse>(request, cancellationToken);
        }
    }
}