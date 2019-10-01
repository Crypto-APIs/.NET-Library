using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetAddressTransactionsLtc()
    {
      var address = "LL9nMSQrfp2RKwSdDZwHSDsyX44kTXqrKw";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
        NetworkCoin.LtcMainNet, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAddressTransactionsLtc executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetAddressTransactionsLtc error: {response.ErrorMessage}");
    }
  }
}