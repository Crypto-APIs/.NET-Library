using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void TransactionsFeeLtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.TransactionsFee<BtcTransactionsFeeResponse>(
        NetworkCoin.LtcMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "TransactionsFeeLtc executed successfully, " +
          $"recommended transactions fee is '{response.Fee.Recommended}'"
        : $"TransactionsFeeLtc error: {response.ErrorMessage}");
    }
  }
}