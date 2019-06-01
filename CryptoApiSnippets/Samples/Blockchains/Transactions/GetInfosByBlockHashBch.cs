using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfosByBlockHashBch()
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Testnet;
      var blockHash = "00000000007458053c7cfa0105abd5b778753074d4aac19d7beedd0a74bc1e34";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfos(
        coin, network, blockHash, skip: 0, limit: 4);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetInfosByBlockHashBch executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetInfosByBlockHashBch error: {response.ErrorMessage}");
    }
  }
}