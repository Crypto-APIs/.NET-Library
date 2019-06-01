using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfosByBlockHeightBch()
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;
      var blockHeight = 552875;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfos(
        coin, network, blockHeight, skip: 0, limit: 4);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetInfosByBlockHeightBch executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetInfosByBlockHeightBch error: {response.ErrorMessage}");
    }
  }
}