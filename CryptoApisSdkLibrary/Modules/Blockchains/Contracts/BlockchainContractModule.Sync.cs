using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Contracts
{
    internal partial class BlockchainContractModule
    {
        public T EstimateGas<T>(NetworkCoin networkCoin)
            where T : EstimateGasContractResponse, new()
        {
            var request = Requests.EstimateGas(networkCoin);
            return GetSync<T>(request);
        }

        public T Deploy<T>(NetworkCoin networkCoin,
            string fromAddress, double gasPrice, double gasLimit, string privateKey, string byteCode)
            where T : DeployContractResponse, new()
        {
            var request = Requests.Deploy(networkCoin,
                fromAddress, gasPrice, gasLimit, privateKey, byteCode);
            return GetSync<T>(request);
        }
    }
}