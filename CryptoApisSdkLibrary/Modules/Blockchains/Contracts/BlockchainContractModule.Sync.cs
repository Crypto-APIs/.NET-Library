using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Contracts
{
    internal partial class BlockchainContractModule
    {
        public T EstimateGas<T>(NetworkCoin networkCoin)
            where T : EstimateGasContractResponse, new()
        {
            return EstimateGasAsync<T>(CancellationToken.None, networkCoin).GetAwaiter().GetResult();
        }

        public T Deploy<T>(NetworkCoin networkCoin,
            string fromAddress, double gasPrice, double gasLimit, string privateKey, string byteCode)
            where T : DeployContractResponse, new()
        {
            return DeployAsync<T>(CancellationToken.None, networkCoin, fromAddress,
                gasPrice, gasLimit, privateKey, byteCode).GetAwaiter().GetResult();
        }
    }
}