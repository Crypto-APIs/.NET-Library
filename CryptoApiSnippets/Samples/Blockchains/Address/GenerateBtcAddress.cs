using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
    partial class BlockchainSnippets
    {
        public void GenerateBtcAddress()
        {
            var coin = BtcSimilarCoin.Btc;
            var network = BtcSimilarNetwork.Mainnet;

            var manager = new CryptoManager(ApiKey);
            var response = manager.Blockchains.Address.GenerateAddress(coin, network);

            Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
                ? $"GenerateBtcAddress executed successfully, new address is {response.Address}"
                : $"GenerateBtcAddress error: {response.ErrorMessage}");
        }
    }
}