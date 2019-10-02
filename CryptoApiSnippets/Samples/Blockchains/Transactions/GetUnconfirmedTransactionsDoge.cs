using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetUnconfirmedTransactionsDoge()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.
        GetUnconfirmedTransactions<GetUnconfirmedTransactionsResponse>(
          NetworkCoin.DogeMainNet, skip:0, limit:50);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetUnconfirmedTransactionsDoge executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetUnconfirmedTransactionsDoge error: {response.ErrorMessage}");
    }
  }
}