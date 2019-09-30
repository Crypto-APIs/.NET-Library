using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetBlockHeightBch()
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;
      var blockHeight = 548249;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetBlockHeigh(coin, network, blockHeight);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetBlockHeightBch executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetBlockHeightBch error: {response.ErrorMessage}");
    }
  }
}