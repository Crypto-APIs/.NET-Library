using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void TransactionsFeeEth()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.TransactionsFee<EthTransactionsFeeResponse>(
        NetworkCoin.EthMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "TransactionsFeeEth executed successfully, " +
          $"recommended transactions fee is '{response.Fee.Recommended}'"
        : $"TransactionsFeeEth error: {response.ErrorMessage}");
    }
  }
}