using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByTransactionHashDoge()
    {
      var coin = BtcSimilarCoin.Doge;
      var network = BtcSimilarNetwork.Testnet;
      var transactionHash = "512ba78dbe7265f07ebec2297d59e0ddccc884fbf2fdd72cb14f924ffb9aefde";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfo(
        coin, network, transactionHash);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetInfoByTransactionHashDoge executed successfully, " +
          $"block hash is {response.Transaction.BlockHash}"
        : $"GetInfoByTransactionHashDoge error: {response.ErrorMessage}");
    }
  }
}