using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void QueuedTransactions()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.QueuedTransactions<QueuedTransactionsResponse>(
        NetworkCoin.EthMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "QueuedTransactions executed successfully, " +
          $"{response.Transactions.Count} queued transactions returned"
        : $"QueuedTransactions error: {response.ErrorMessage}");
    }
  }
}