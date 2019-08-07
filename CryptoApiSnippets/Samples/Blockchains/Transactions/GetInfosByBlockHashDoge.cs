using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfosByBlockHashDoge()
    {
      var coin = BtcSimilarCoin.Doge;
      var network = BtcSimilarNetwork.Testnet;
      var blockHash = "2babf28b085c2efb4615d41051c59a7c257d1ad9e71ce308fb72eb1a93805a19";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfos(
        coin, network, blockHash, skip: 0, limit: 4);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfosByBlockHashDoge executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetInfosByBlockHashDoge error: {response.ErrorMessage}");
    }
  }
}