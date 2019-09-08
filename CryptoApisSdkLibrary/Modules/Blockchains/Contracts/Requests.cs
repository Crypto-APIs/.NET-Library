using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.RequestTypes;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Contracts
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest EstimateGas(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/contracts/gas");
        }

        public IRestRequest Deploy(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, double gasPrice, double gasLimit, string privateKey, string byteCode)
        {
            if (string.IsNullOrEmpty(fromAddress))
                throw new ArgumentNullException(nameof(fromAddress));
            if (string.IsNullOrEmpty(privateKey))
                throw new ArgumentNullException(nameof(privateKey));
            if (string.IsNullOrEmpty(byteCode))
                throw new ArgumentNullException(nameof(byteCode));
            if (gasPrice <= 0)
                throw new ArgumentOutOfRangeException(nameof(gasPrice), gasPrice, "GasPrice is negative or zero");
            if (gasLimit <= 0)
                throw new ArgumentOutOfRangeException(nameof(gasLimit), gasLimit, "GasLimit is negative or zero");

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/contracts",
                new DeployContractRequest(privateKey, fromAddress, gasPrice, gasLimit, byteCode));
        }

        private CryptoApiRequest Request { get; }
    }
}