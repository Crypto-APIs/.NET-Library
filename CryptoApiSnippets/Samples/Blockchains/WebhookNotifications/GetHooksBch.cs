using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHooksBch()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.GetHooks<GetBtcHooksResponse>(
          NetworkCoin.BchMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHooksBch executed successfully, {response.Hooks.Count} hooks returned"
        : $"GetHooksBch error: {response.ErrorMessage}");
    }
  }
}