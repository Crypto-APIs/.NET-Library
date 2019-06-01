using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Info
{
    internal class BlockchainInfoModule : BaseModule, IBlockchainInfoModule
    {
        public BlockchainInfoModule(IRestClient client, CryptoApiRequest request) : base(client, request)
        {
        }

        public GetBtcInfoResponse GetInfo(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var response = GetInfoResponse(coin, network);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetBtcInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetBtcInfoResponse>(response);
        }

        public GetEthInfoResponse GetInfo(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var response = GetInfoResponse(coin, network);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetEthInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetEthInfoResponse>(response);
        }

        public GetBtcHashInfoResponse GetBlockHash(BtcSimilarCoin coin, BtcSimilarNetwork network, string blockHash)
        {
            var response = GetBlockHashResponse(coin, network, blockHash);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetBtcHashInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetBtcHashInfoResponse>(response);
        }

        public GetEthHashInfoResponse GetBlockHash(EthSimilarCoin coin, EthSimilarNetwork network, string blockHash)
        {
            var response = GetBlockHashResponse(coin, network, blockHash);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetEthHashInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetEthHashInfoResponse>(response);
        }

        public GetBtcHashInfoResponse GetBlockHeigh(BtcSimilarCoin coin, BtcSimilarNetwork network, int blockHeight)
        {
            var response = GetBlockHeighResponse(coin, network, blockHeight);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetBtcHashInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetBtcHashInfoResponse>(response);
        }

        public GetEthHashInfoResponse GetBlockHeigh(EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight)
        {
            var response = GetBlockHeighResponse(coin, network, blockHeight);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetEthHashInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetEthHashInfoResponse>(response);
        }

        public GetBtcHashInfoResponse GetLatestBlock(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var response = GetLatestBlockResponse(coin, network);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetBtcHashInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetBtcHashInfoResponse>(response);
        }

        public GetEthHashInfoResponse GetLatestBlock(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var response = GetLatestBlockResponse(coin, network);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetEthHashInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetEthHashInfoResponse>(response);
        }

        private IRestResponse GetInfoResponse(Coin coin, Network network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/info");
            return Client.Execute(request);
        }

        private IRestResponse GetBlockHashResponse(Coin coin, Network network, string blockHash)
        {
            if (string.IsNullOrEmpty(blockHash))
                throw new ArgumentNullException(nameof(blockHash));

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/blocks/{blockHash}");
            return Client.Execute(request);
        }

        private IRestResponse GetBlockHeighResponse(Coin coin, Network network, int blockHeight)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/blocks/{blockHeight}");
            return Client.Execute(request);
        }

        private IRestResponse GetLatestBlockResponse(Coin coin, Network network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/blocks/latest");
            return Client.Execute(request);
        }
    }
}