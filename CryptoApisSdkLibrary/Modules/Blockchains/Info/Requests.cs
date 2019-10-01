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

        public IRestRequest GetInfo(NetworkCoin networkCoin)
        {
            return Request.Get($"{Consts.Blockchain}/{networkCoin}/info");
        }

        public IRestRequest GetBlockHash(NetworkCoin networkCoin, string blockHash)
        {
            if (string.IsNullOrEmpty(blockHash))
                throw new ArgumentNullException(nameof(blockHash));

            return Request.Get($"{Consts.Blockchain}/{networkCoin}/blocks/{blockHash}");
        }

        public IRestRequest GetBlockHeight(NetworkCoin networkCoin, int blockHeight)
        {
            return Request.Get($"{Consts.Blockchain}/{networkCoin}/blocks/{blockHeight}");
        }

        public IRestRequest GetLatestBlock(NetworkCoin networkCoin)
        {
            return Request.Get($"{Consts.Blockchain}/{networkCoin}/blocks/latest");
        }

        private CryptoApiRequest Request { get; }
    }
}