using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
    partial class BlockchainSnippets
    {
        public void GetBchAddress()
        {
            var coin = BtcSimilarCoin.Bch;
            var network = BtcSimilarNetwork.Mainnet;
            var address = "1DBrYbe5U7LGDcHA5tiLCxivZ7JZAGqGhJ";

            var manager = new CryptoManager(ApiKey);
            var response = manager.Blockchains.Address.GetAddress(coin, network, address);

            Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
                ? $"GetBchAddress executed successfully, balance is {response.FinalBalance} now"
                : $"GetBchAddress error: {response.ErrorMessage}");
        }
    }
}