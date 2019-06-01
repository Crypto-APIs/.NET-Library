using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetUnconfirmedTransactionsBtc()
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetUnconfirmedTransactions(
        coin, network, skip: 0, limit: 50);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetUnconfirmedTransactionsBtc executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetUnconfirmedTransactionsBtc error: {response.ErrorMessage}");
    }
  }
}