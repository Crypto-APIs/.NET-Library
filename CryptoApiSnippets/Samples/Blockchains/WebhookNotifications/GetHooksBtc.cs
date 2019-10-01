using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHooksBtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.GetHooks<GetBtcHooksResponse>(
        NetworkCoin.BtcMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHooksBtc executed successfully, {response.Hooks.Count} hooks returned"
        : $"GetHooksBtc error: {response.ErrorMessage}");
    }
  }
}