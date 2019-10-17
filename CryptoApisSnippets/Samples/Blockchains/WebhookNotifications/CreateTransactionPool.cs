using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateTransactionPool()
    {
      var url = "http://somepoint.point";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.CreateTransactionPool<EthWebHookResponse>(
          NetworkCoin.EthRopsten, url);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateTransactionPool executed successfully, " +
          $"HookId is \"{response.Payload.Id}\""
        : $"CreateTransactionPool error: {response.ErrorMessage}");
    }
  }
}