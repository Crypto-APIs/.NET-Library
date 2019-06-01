using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfosByBlockHeightLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;
      var blockHeight = 552875;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfos(
        coin, network, blockHeight, skip: 0, limit: 4);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetInfosByBlockHeightLtc executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetInfosByBlockHeightLtc error: {response.ErrorMessage}");
    }
  }
}