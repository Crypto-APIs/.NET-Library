using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void QueuedTransactions()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.QueuedTransactions(
        coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "QueuedTransactions executed successfully, " +
          $"{response.Transactions.Count} queued transactions returned"
        : $"QueuedTransactions error: {response.ErrorMessage}");
    }
  }
}