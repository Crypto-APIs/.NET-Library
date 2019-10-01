using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHookEth(string hookId)
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.Delete<DeleteWebhookResponse>(
        NetworkCoin.EthRopsten, hookId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeleteHookEth executed successfully, Status is \"" +
          $"{response.Payload.Message}\""
        : $"DeleteHookEth error: {response.ErrorMessage}");
    }
  }
}