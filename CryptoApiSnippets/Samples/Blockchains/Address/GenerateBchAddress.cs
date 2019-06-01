using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
    partial class BlockchainSnippets
    {
        public void GenerateBchAddress()
        {
            var coin = BtcSimilarCoin.Bch;
            var network = BtcSimilarNetwork.Mainnet;

            var manager = new CryptoManager(ApiKey);
            var response = manager.Blockchains.Address.GenerateAddress(coin, network);

            Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
                ? $"GenerateBchAddress executed successfully, new address is {response.Address}"
                : $"GenerateBchAddress error: {response.ErrorMessage}");
        }
    }
}