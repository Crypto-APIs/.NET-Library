using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void TransactionsFeeDoge()
    {
      var coin = BtcSimilarCoin.Doge;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.TransactionsFee(
        coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "TransactionsFeeDoge executed successfully, " +
          $"recommended transactions fee is '{response.Payload.Recommended}'"
        : $"TransactionsFeeDoge error: {response.ErrorMessage}");
    }
  }
}