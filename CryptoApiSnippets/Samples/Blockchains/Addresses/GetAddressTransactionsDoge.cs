using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetAddressTransactionsDoge()
    {
      var address = "bitcoincash:qzrx05s5t7gdxq9gt7rx7sdurktyr85krvrx8spqq8";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
        NetworkCoin.DogeMainNet, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAddressTransactionsDoge executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetAddressTransactionsDoge error: {response.ErrorMessage}");
    }
  }
}