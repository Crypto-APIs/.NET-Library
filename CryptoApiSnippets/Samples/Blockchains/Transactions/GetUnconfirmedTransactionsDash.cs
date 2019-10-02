using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetUnconfirmedTransactionsDash()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.
        GetUnconfirmedTransactions<GetUnconfirmedTransactionsResponse>(
          NetworkCoin.DashMainNet, skip:0, limit:50);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetUnconfirmedTransactionsDash executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetUnconfirmedTransactionsDash error: {response.ErrorMessage}");
    }
  }
}