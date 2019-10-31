using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInternalTransactionsEth()
    {
      var transactionHash = "0x8a26cd4d52706aeb645eed328242165f59c76bde93b46a74497057146e0aca1e";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInternalTransactions<EthGetInternalTransactionsResponse>(
        NetworkCoin.EthMainNet, transactionHash);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInternalTransactionsEth executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetInternalTransactionsEth error: {response.ErrorMessage}");
    }
  }
}