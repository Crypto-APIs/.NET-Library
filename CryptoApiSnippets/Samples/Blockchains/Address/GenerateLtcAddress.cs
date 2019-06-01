using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
    partial class BlockchainSnippets
    {
        public void GenerateLtcAddress()
        {
            var coin = BtcSimilarCoin.Ltc;
            var network = BtcSimilarNetwork.Mainnet;

            var manager = new CryptoManager(ApiKey);
            var response = manager.Blockchains.Address.GenerateAddress(coin, network);

            Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
                ? $"GenerateLtcAddress executed successfully, new address is {response.Address}"
                : $"GenerateLtcAddress error: {response.ErrorMessage}");
        }
    }
}