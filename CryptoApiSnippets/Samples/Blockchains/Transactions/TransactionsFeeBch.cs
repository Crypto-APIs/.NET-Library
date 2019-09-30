using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void TransactionsFeeBch()
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.TransactionsFee(
        coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "TransactionsFeeBch executed successfully, " +
          $"recommended transactions fee is '{response.Payload.Recommended}'"
        : $"TransactionsFeeBch error: {response.ErrorMessage}");
    }
  }
}