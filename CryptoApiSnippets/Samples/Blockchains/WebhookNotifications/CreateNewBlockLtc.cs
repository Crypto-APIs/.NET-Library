using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
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
          $"{response.Payload.Id}\""
        : $"CreateNewBlockLtc error: {response.ErrorMessage}");
    }
  }
}