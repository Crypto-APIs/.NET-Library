using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfosByBlockHashLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;
      var blockHash = "08362fd156d3076ac883cca5715b25dbd5576730de0863cf0cce50602d8dae0f";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfos(
        coin, network, blockHash, skip: 0, limit: 4);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetInfosByBlockHashLtc executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetInfosByBlockHashLtc error: {response.ErrorMessage}");
    }
  }
}