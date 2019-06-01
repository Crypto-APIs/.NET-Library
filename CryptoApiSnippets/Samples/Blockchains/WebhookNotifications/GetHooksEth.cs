using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHooksEth()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Ropsten;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.GetHooks(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHooksEth executed successfully, {response.Hooks.Count} hooks returned"
        : $"GetHooksEth error: {response.ErrorMessage}");
    }
  }
}