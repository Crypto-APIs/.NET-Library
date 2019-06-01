using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void DeleteHookEth(string hookId)
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Ropsten;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.Delete(
          coin, network, hookId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"DeleteHookEth executed successfully, Status is \"{response.Payload.Message}\""
        : $"DeleteHookEth error: {response.ErrorMessage}");
    }
  }
}