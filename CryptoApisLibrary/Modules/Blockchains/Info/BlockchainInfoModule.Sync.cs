using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Threading;

namespace CryptoApisLibrary.Modules.Blockchains.Info
{
    internal partial class BlockchainInfoModule
    {
        public T GetInfo<T>(NetworkCoin networkCoin)
            where T : GetInfoResponse, new()
        {
            return GetInfoAsync<T>(CancellationToken.None, networkCoin).GetAwaiter().GetResult();
        }

        public T GetBlockHash<T>(NetworkCoin networkCoin, string blockHash)
            where T : GetHashInfoResponse, new()
        {
            return GetBlockHashAsync<T>(CancellationToken.None, networkCoin, blockHash).GetAwaiter().GetResult();
        }

        public T GetBlockHeight<T>(NetworkCoin networkCoin, int blockHeight)
            where T : GetHashInfoResponse, new()
        {
            return GetBlockHeightAsync<T>(CancellationToken.None, networkCoin, blockHeight).GetAwaiter().GetResult();
        }

        public T GetLatestBlock<T>(NetworkCoin networkCoin)
            where T : GetHashInfoResponse, new()
        {
            return GetLatestBlockAsync<T>(CancellationToken.None, networkCoin).GetAwaiter().GetResult();
        }
    }
}