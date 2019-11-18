using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateNewBlockEth()
    {
      var url = "http://somepoint.point";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.CreateNewBlock<EthWebHookResponse>(
        NetworkCoin.EthRopsten, url);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateNewBlockEth executed successfully, HookId is \"" +
          $"{response.Hook.Id}\""
        : $"CreateNewBlockEth error: {response.ErrorMessage}");
    }
  }
}