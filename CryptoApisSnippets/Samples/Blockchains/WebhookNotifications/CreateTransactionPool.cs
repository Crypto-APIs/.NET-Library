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
          NetworkCoin.EthRopsten, url, "0x4ab47e7b0204d6b3bf0e956db14e63142b9b5ab8");

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateTransactionPool executed successfully, " +
          $"HookId is \"{response.Hook.Id}\""
        : $"CreateTransactionPool error: {response.ErrorMessage}");
    }
  }
}