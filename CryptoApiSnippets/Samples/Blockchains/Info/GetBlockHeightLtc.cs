using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetBlockHeightLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;
      var blockHeight = 1354896;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetBlockHeigh(coin, network, blockHeight);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetBlockHeightLtc executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetBlockHeightLtc error: {response.ErrorMessage}");
    }
  }
}