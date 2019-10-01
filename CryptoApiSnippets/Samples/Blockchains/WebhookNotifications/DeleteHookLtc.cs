using CryptoApisSdkLibrary.DataTypes;
using System;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHookLtc(string hookId)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(
        NetworkCoin.LtcMainNet, hookId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeleteHookLtc executed successfully, Status is \"" +
          $"{response.Payload.Message}\""
        : $"DeleteHookLtc error: {response.ErrorMessage}");
    }
  }
}