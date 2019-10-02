using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void TransactionsFeeBtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.TransactionsFee<BtcTransactionsFeeResponse>(
        NetworkCoin.BtcMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "TransactionsFeeBtc executed successfully, " +
          $"recommended transactions fee is '{response.Payload.Recommended}'"
        : $"TransactionsFeeBtc error: {response.ErrorMessage}");
    }
  }
}