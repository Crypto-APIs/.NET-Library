using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetBlockHashLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;
      var blockHash = "f69e755922153ae0fa017322a3ee3463558f74b03dc2aed6261ae6f3dcd3dc53";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetBlockHash(coin, network, blockHash);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetBlockHashLtc executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetBlockHashLtc error: {response.ErrorMessage}");
    }
  }
}