using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHookDoge(string hookId)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(
        NetworkCoin.DogeMainNet, hookId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeleteHookDoge executed successfully, Status is \"" +
          $"{response.Payload.Message}\""
        : $"DeleteHookDoge error: {response.ErrorMessage}");
    }
  }
}