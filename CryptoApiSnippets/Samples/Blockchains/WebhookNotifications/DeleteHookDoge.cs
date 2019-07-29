using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHookDoge(string hookId)
    {
      var coin = BtcSimilarCoin.Doge;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.Delete(
          coin, network, hookId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeleteHookDoge executed successfully, Status is \"" +
          $"{response.Payload.Message}\""
        : $"DeleteHookDoge error: {response.ErrorMessage}");
    }
  }
}