using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByTransactionIdDoge()
    {
      var coin = BtcSimilarCoin.Doge;
      var network = BtcSimilarNetwork.Testnet;
      var transactionId = "512ba78dbe7265f07ebec2297d59e0ddccc884fbf2fdd72cb14f924ffb9aefde";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfo(
        coin, network, transactionId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoByTransactionIdDoge executed successfully, " +
          $"block hash is {response.Transaction.BlockHash}"
        : $"GetInfoByTransactionIdDoge error: {response.ErrorMessage}");
    }
  }
}