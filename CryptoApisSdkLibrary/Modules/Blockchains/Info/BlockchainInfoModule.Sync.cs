using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Info
{
    internal partial class BlockchainInfoModule
    {
        public GetBtcInfoResponse GetInfo(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetInfo(coin, network);
            return GetSync<GetBtcInfoResponse>(request);
        }

        public GetEthInfoResponse GetInfo(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.GetInfo(coin, network);
            return GetSync<GetEthInfoResponse>(request);
        }

        public GetBtcHashInfoResponse GetBlockHash(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string blockHash)
        {
            var request = Requests.GetBlockHash(coin, network, blockHash);
            return GetSync<GetBtcHashInfoResponse>(request);
        }

        public GetEthHashInfoResponse GetBlockHash(
            EthSimilarCoin coin, EthSimilarNetwork network, string blockHash)
        {
            var request = Requests.GetBlockHash(coin, network, blockHash);
            return GetSync<GetEthHashInfoResponse>(request);
        }

        public GetBtcHashInfoResponse GetBlockHeigh(BtcSimilarCoin coin, BtcSimilarNetwork network, int blockHeight)
        {
            var request = Requests.GetBlockHeight(coin, network, blockHeight);
            return GetSync<GetBtcHashInfoResponse>(request);
        }

        public GetEthHashInfoResponse GetBlockHeigh(EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight)
        {
            var request = Requests.GetBlockHeight(coin, network, blockHeight);
            return GetSync<GetEthHashInfoResponse>(request);
        }

        public GetBtcHashInfoResponse GetLatestBlock(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetLatestBlock(coin, network);
            return GetSync<GetBtcHashInfoResponse>(request);
        }

        public GetEthHashInfoResponse GetLatestBlock(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.GetLatestBlock(coin, network);
            return GetSync<GetEthHashInfoResponse>(request);
        }
    }
}