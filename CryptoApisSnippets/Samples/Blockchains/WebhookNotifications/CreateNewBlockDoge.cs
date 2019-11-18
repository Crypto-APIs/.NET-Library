using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateNewBlockDoge()
    {
      var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.CreateNewBlock<BtcWebHookResponse>(
        NetworkCoin.DogeMainNet, url);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateNewBlockDoge executed successfully, HookId is \"" +
          $"{response.Hook.Id}\""
        : $"CreateNewBlockDoge error: {response.ErrorMessage}");
    }
  }
}