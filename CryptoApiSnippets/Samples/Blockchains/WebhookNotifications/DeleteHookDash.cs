using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHookDash(string hookId)
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.Delete(
          coin, network, hookId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "DeleteHookDash executed successfully, Status is \"" +
          $"{response.Payload.Message}\""
        : $"DeleteHookDash error: {response.ErrorMessage}");
    }
  }
}