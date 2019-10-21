using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetTransactionsEth()
    {
      var address = "0x59fc0Ab4072aAe70c38167881BE24f9CAfC8070d";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Token.GetTransactions<GetEthTransactionsResponse>(
          NetworkCoin.EthMainNet, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetTransactionsEth executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetTransactionsEth error: {response.ErrorMessage}");
    }
  }
}