using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void TransactionsFeeBch()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.TransactionsFee<BtcTransactionsFeeResponse>(
        NetworkCoin.BchMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "TransactionsFeeBch executed successfully, " +
          $"recommended transactions fee is '{response.Fee.Recommended}'"
        : $"TransactionsFeeBch error: {response.ErrorMessage}");
    }
  }
}