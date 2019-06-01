using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHooksBtc()
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.WebhookNotification.GetHooks(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHooksBtc executed successfully, {response.Hooks.Count} hooks returned"
        : $"GetHooksBtc error: {response.ErrorMessage}");
    }
  }
}