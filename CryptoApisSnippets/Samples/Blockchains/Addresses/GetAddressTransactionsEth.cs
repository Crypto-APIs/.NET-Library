using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetAddressTransactionsEth()
    {
      var address = "0x0cb1883c01377f45ee5d7448a32b5ac1709afc11";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GetAddressTransactions<GetEthAddressTransactionsResponse>(
        NetworkCoin.EthRopsten, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAddressTransactionsEth executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetAddressTransactionsEth error: {response.ErrorMessage}");
    }
  }
}