using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetUnconfirmedTransactionsBtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.
        GetUnconfirmedTransactions<GetUnconfirmedTransactionsResponse>(
          NetworkCoin.BtcMainNet, skip: 0, limit: 50);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetUnconfirmedTransactionsBtc executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetUnconfirmedTransactionsBtc error: {response.ErrorMessage}");
    }
  }
}