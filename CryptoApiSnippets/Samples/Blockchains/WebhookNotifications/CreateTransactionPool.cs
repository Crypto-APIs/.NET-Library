using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateTransactionPool()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Ropsten;
      var url = "http://somepoint.point";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.CreateTransactionPool(
          coin, network, url);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"CreateTransactionPool executed successfully, " +
          $"HookId is \"{response.Payload.Id}\""
        : $"CreateTransactionPool error: {response.ErrorMessage}");
    }
  }
}