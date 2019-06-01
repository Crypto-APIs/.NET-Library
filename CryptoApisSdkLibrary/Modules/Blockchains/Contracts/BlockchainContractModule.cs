using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.RequestTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Contracts
{
    internal class BlockchainContractModule : BaseModule, IBlockchainContractModule
    {
        public BlockchainContractModule(IRestClient client, CryptoApiRequest request) : base(client, request)
        {
        }

        public EstimateGasContractResponse EstimateGas(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/contracts/gas");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<EstimateGasContractResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<EstimateGasContractResponse>(response);
        }

        public DeployContractResponse Deploy(EthSimilarCoin coin, EthSimilarNetwork network, 
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

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/contracts",
                new DeployContractRequest(privateKey, fromAddress, gasPrice, gasLimit, byteCode));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<DeployContractResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<DeployContractResponse>(response);
        }
    }
}