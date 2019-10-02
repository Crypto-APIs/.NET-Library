using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void PendingTransactions()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.PendingTransactions<PendingTransactionsResponse>(
        NetworkCoin.EthMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "PendingTransactions executed successfully, " +
          $"{response.Transactions.Count} pending transactions returned"
        : $"PendingTransactions error: {response.ErrorMessage}");
    }
  }
}