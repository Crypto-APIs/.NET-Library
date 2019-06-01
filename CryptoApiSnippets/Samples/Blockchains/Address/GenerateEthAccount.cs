using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
    partial class BlockchainSnippets
    {
        public void GenerateEthAccount()
        {
            var coin = EthSimilarCoin.Eth;
            var network = EthSimilarNetwork.Ropsten;
            var password = "password";

            var manager = new CryptoManager(ApiKey);
            var response = manager.Blockchains.Address.GenerateAccount(coin, network, password);

            Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
                ? $"GenerateEthAccount executed successfully, new address is {response.Address}"
                : $"GenerateEthAccount error: {response.ErrorMessage}");
        }
    }
}