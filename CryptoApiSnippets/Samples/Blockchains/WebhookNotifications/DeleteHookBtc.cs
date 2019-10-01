using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHookBtc(string hookId)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(
        NetworkCoin.BtcMainNet, hookId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeleteHookBtc executed successfully, Status is \"" +
          $"{response.Payload.Message}\""
        : $"DeleteHookBtc error: {response.ErrorMessage}");
    }
  }
}