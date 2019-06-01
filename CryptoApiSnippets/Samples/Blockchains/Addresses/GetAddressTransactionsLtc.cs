using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetAddressTransactionsLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;
      var address = "LL9nMSQrfp2RKwSdDZwHSDsyX44kTXqrKw";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GetAddressTransactions(
        coin, network, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetAddressTransactionsLtc executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetAddressTransactionsLtc error: {response.ErrorMessage}");
    }
  }
}