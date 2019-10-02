using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetUnconfirmedTransactionsBch()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.
        GetUnconfirmedTransactions<GetUnconfirmedTransactionsResponse>(
          NetworkCoin.BchMainNet, skip:0, limit:50);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetUnconfirmedTransactionsBch executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetUnconfirmedTransactionsBch error: {response.ErrorMessage}");
    }
  }
}