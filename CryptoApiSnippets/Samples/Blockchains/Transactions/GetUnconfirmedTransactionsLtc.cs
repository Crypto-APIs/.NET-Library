using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetUnconfirmedTransactionsLtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.
        GetUnconfirmedTransactions<GetUnconfirmedTransactionsResponse>(
          NetworkCoin.LtcMainNet, skip: 0, limit: 50);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetUnconfirmedTransactionsLtc executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetUnconfirmedTransactionsLtc error: {response.ErrorMessage}");
    }
  }
}