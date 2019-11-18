using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void CreateNewBlockLtc()
    {
      var url = "http://www.mocky.io/v2/5b0d4b5f3100006e009d55f5";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.CreateNewBlock<BtcWebHookResponse>(
        NetworkCoin.LtcMainNet, url);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "CreateNewBlockLtc executed successfully, HookId is \"" +
          $"{response.Hook.Id}\""
        : $"CreateNewBlockLtc error: {response.ErrorMessage}");
    }
  }
}