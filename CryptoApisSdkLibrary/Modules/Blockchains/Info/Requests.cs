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
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/info");
        }

        public IRestRequest GetInfo(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/info");
        }

        public IRestRequest GetBlockHash(BtcSimilarCoin coin, BtcSimilarNetwork network, string blockHash)
        {
            if (string.IsNullOrEmpty(blockHash))
                throw new ArgumentNullException(nameof(blockHash));

            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/blocks/{blockHash}");
        }

        public IRestRequest GetBlockHash(EthSimilarCoin coin, EthSimilarNetwork network, string blockHash)
        {
            if (string.IsNullOrEmpty(blockHash))
                throw new ArgumentNullException(nameof(blockHash));

            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/blocks/{blockHash}");
        }

        public IRestRequest GetBlockHeight(BtcSimilarCoin coin, BtcSimilarNetwork network, int blockHeight)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/blocks/{blockHeight}");
        }

        public IRestRequest GetBlockHeight(EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/blocks/{blockHeight}");
        }

        public IRestRequest GetLatestBlock(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/blocks/latest");
        }

        public IRestRequest GetLatestBlock(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/blocks/latest");
        }

        private CryptoApiRequest Request { get; }
    }
}