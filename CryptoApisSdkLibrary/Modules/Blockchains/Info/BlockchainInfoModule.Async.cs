using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Info
{
    internal partial class BlockchainInfoModule
    {
        public Task<GetBtcInfoResponse> GetInfoAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetInfo(coin, network);
            return GetAsyncResponse<GetBtcInfoResponse>(request, cancellationToken);
        }

        public Task<GetEthInfoResponse> GetInfoAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.GetInfo(coin, network);
            return GetAsyncResponse<GetEthInfoResponse>(request, cancellationToken);
        }

        public Task<GetBtcHashInfoResponse> GetBlockHashAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string blockHash)
        {
            var request = Requests.GetBlockHash(coin, network, blockHash);
            return GetAsyncResponse<GetBtcHashInfoResponse>(request, cancellationToken);
        }

        public Task<GetEthHashInfoResponse> GetBlockHashAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string blockHash)
        {
            var request = Requests.GetBlockHash(coin, network, blockHash);
            return GetAsyncResponse<GetEthHashInfoResponse>(request, cancellationToken);
        }

        public Task<GetBtcHashInfoResponse> GetBlockHeighAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, int blockHeight)
        {
            var request = Requests.GetBlockHeight(coin, network, blockHeight);
            return GetAsyncResponse<GetBtcHashInfoResponse>(request, cancellationToken);
        }

        public Task<GetEthHashInfoResponse> GetBlockHeighAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight)
        {
            var request = Requests.GetBlockHeight(coin, network, blockHeight);
            return GetAsyncResponse<GetEthHashInfoResponse>(request, cancellationToken);
        }

        public Task<GetBtcHashInfoResponse> GetLatestBlockAsync(CancellationToken cancellationToken, BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetLatestBlock(coin, network);
            return GetAsyncResponse<GetBtcHashInfoResponse>(request, cancellationToken);
        }

        public Task<GetEthHashInfoResponse> GetLatestBlockAsync(CancellationToken cancellationToken, EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.GetLatestBlock(coin, network);
            return GetAsyncResponse<GetEthHashInfoResponse>(request, cancellationToken);
        }
    }
}