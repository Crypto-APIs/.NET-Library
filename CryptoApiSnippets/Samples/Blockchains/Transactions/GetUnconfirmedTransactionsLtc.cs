using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetUnconfirmedTransactionsLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetUnconfirmedTransactions(
        coin, network, skip: 0, limit: 50);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetUnconfirmedTransactionsLtc executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetUnconfirmedTransactionsLtc error: {response.ErrorMessage}");
    }
  }
}