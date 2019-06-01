using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
    partial class BlockchainSnippets
    {
        public void GetEthAddressTransactions()
        {
            var coin = EthSimilarCoin.Eth;
            var network = EthSimilarNetwork.Ropsten;
            var address = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";

            var manager = new CryptoManager(ApiKey);
            var response = manager.Blockchains.Address.GetAddressTransactions(coin, network, address);

            Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
                ? $"GetEthAddressTransactions executed successfully, {response.Transactions.Count} transactions returned"
                : $"GetEthAddressTransactions error: {response.ErrorMessage}");
        }
    }
}