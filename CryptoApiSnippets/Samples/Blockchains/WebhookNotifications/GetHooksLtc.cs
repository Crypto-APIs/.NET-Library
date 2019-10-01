using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHooksLtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.GetHooks<GetBtcHooksResponse>(
        NetworkCoin.LtcMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHooksLtc executed successfully, {response.Hooks.Count} hooks returned"
        : $"GetHooksLtc error: {response.ErrorMessage}");
    }
  }
}