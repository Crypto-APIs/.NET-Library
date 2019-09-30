using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void TransactionsFeeBtc()
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.TransactionsFee(
        coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "TransactionsFeeBtc executed successfully, " +
          $"recommended transactions fee is '{response.Payload.Recommended}'"
        : $"TransactionsFeeBtc error: {response.ErrorMessage}");
    }
  }
}