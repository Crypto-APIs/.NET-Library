using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Blockchains.Info
{
    internal partial class BlockchainInfoModule
    {
        public Task<T> GetInfoAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GetInfoResponse, new()
        {
            var request = Requests.GetInfo(networkCoin);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetBlockHashAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string blockHash)
            where T : GetHashInfoResponse, new()
        {
            var request = Requests.GetBlockHash(networkCoin, blockHash);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetBlockHeightAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, int blockHeight)
            where T : GetHashInfoResponse, new()
        {
            var request = Requests.GetBlockHeight(networkCoin, blockHeight);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetLatestBlockAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GetHashInfoResponse, new()
        {
            var request = Requests.GetLatestBlock(networkCoin);
            return GetAsyncResponse<T>(request, cancellationToken);
        }
    }
}