using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHooksDoge()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.GetHooks<GetBtcHooksResponse>(
        NetworkCoin.DogeMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHooksDoge executed successfully, {response.Hooks.Count} hooks returned"
        : $"GetHooksDoge error: {response.ErrorMessage}");
    }
  }
}