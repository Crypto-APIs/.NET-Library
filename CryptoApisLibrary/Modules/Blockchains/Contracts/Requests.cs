using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.Misc;
using CryptoApisLibrary.RequestTypes;
using RestSharp;
using System;

namespace CryptoApisLibrary.Modules.Blockchains.Contracts
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest EstimateGas(NetworkCoin networkCoin)
        {
            return Request.Get($"{Consts.Blockchain}/{networkCoin}/contracts/gas");
        }

        public IRestRequest Deploy(NetworkCoin networkCoin, string fromAddress,
            double gasPrice, double gasLimit, string privateKey, string byteCode)
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

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/contracts",
                new DeployContractRequest(privateKey, fromAddress, gasPrice, gasLimit, byteCode));
        }

        private CryptoApiRequest Request { get; }
    }
}