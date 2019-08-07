using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByTransactionIdDash()
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Testnet;
      var transactionId = "9df2da1770e009bd7d75947fc9be07980bf30a67ae59a893cb89c1f4eeb57a19";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfo(
        coin, network, transactionId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoByTransactionIdDash executed successfully, " +
          $"block hash is {response.Transaction.BlockHash}"
        : $"GetInfoByTransactionIdDash error: {response.ErrorMessage}");
    }
  }
}