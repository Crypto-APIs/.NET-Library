using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
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