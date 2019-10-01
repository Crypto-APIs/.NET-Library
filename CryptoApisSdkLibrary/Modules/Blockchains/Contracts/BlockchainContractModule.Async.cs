using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Contracts
{
    internal partial class BlockchainContractModule
    {
        public Task<T> EstimateGasAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin)
            where T : EstimateGasContractResponse, new()
        {
            var request = Requests.EstimateGas(networkCoin);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> DeployAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, double gasPrice, double gasLimit, string privateKey, string byteCode)
            where T : DeployContractResponse, new()
        {
            var request = Requests.Deploy(networkCoin, fromAddress, gasPrice, gasLimit, privateKey, byteCode);
            return GetAsyncResponse<T>(request, cancellationToken);
        }
    }
}