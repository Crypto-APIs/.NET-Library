using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetLatestBlockDash()
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetLatestBlock(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetLatestBlockDash executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetLatestBlockDash error: {response.ErrorMessage}");
    }
  }
}