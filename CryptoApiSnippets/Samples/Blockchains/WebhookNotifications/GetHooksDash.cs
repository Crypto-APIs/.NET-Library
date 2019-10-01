using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHooksDash()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.GetHooks<GetBtcHooksResponse>(
        NetworkCoin.DashMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHooksDash executed successfully, {response.Hooks.Count} hooks returned"
        : $"GetHooksDash error: {response.ErrorMessage}");
    }
  }
}