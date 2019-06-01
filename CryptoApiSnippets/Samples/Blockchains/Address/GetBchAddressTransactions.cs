using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
    partial class BlockchainSnippets
    {
        public void GetBchAddressTransactions()
        {
            var coin = BtcSimilarCoin.Bch;
            var network = BtcSimilarNetwork.Mainnet;
            var address = "bitcoincash:qzrx05s5t7gdxq9gt7rx7sdurktyr85krvrx8spqq8";

            var manager = new CryptoManager(ApiKey);
            var response = manager.Blockchains.Address.GetAddressTransactions(coin, network, address);

            Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
                ? $"GetBchAddressTransactions executed successfully, {response.Transactions.Count} transactions returned"
                : $"GetBchAddressTransactions error: {response.ErrorMessage}");
        }
    }
}