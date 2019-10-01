using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Info
{
    internal partial class BlockchainInfoModule
    {
        public T GetInfo<T>(NetworkCoin networkCoin)
            where T : GetInfoResponse, new()
        {
            var request = Requests.GetInfo(networkCoin);
            return GetSync<T>(request);
        }

        public T GetBlockHash<T>(NetworkCoin networkCoin, string blockHash)
            where T : GetHashInfoResponse, new()
        {
            var request = Requests.GetBlockHash(networkCoin, blockHash);
            return GetSync<T>(request);
        }

        public T GetBlockHeight<T>(NetworkCoin networkCoin, int blockHeight)
            where T : GetHashInfoResponse, new()
        {
            var request = Requests.GetBlockHeight(networkCoin, blockHeight);
            return GetSync<T>(request);
        }

        public T GetLatestBlock<T>(NetworkCoin networkCoin)
            where T : GetHashInfoResponse, new()
        {
            var request = Requests.GetLatestBlock(networkCoin);
            return GetSync<T>(request);
        }
    }
}