using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Info
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)

        {
            Request = request;
        }

        public IRestRequest GetInfo(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            return InternalGetInfo(coin, network);
        }

        public IRestRequest GetInfo(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            return InternalGetInfo(coin, network);
        }

        public IRestRequest GetBlockHash(BtcSimilarCoin coin, BtcSimilarNetwork network, string blockHash)
        {
            return InternalGetBlockHash(coin, network, blockHash);
        }

        public IRestRequest GetBlockHash(EthSimilarCoin coin, EthSimilarNetwork network, string blockHash)
        {
            return InternalGetBlockHash(coin, network, blockHash);
        }

        public IRestRequest GetBlockHeight(BtcSimilarCoin coin, BtcSimilarNetwork network, int blockHeight)
        {
            return InternalGetBlockHeight(coin, network, blockHeight);
        }

        public IRestRequest GetBlockHeight(EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight)
        {
            return InternalGetBlockHeight(coin, network, blockHeight);
        }

        public IRestRequest GetLatestBlock(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            return InternalGetLatestBlock(coin, network);
        }

        public IRestRequest GetLatestBlock(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            return InternalGetLatestBlock(coin, network);
        }

        private IRestRequest InternalGetInfo(Coin coin, Network network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/info");
        }

        private IRestRequest InternalGetBlockHash(Coin coin, Network network, string blockHash)
        {
            if (string.IsNullOrEmpty(blockHash))
                throw new ArgumentNullException(nameof(blockHash));

            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/blocks/{blockHash}");
        }

        private IRestRequest InternalGetBlockHeight(Coin coin, Network network, int blockHeight)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/blocks/{blockHeight}");
        }

        private IRestRequest InternalGetLatestBlock(Coin coin, Network network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/blocks/latest");
        }

        private CryptoApiRequest Request { get; }
    }
}