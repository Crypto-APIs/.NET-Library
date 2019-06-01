using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetLatestBlockBch()
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetLatestBlock(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetLatestBlockBch executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetLatestBlockBch error: {response.ErrorMessage}");
    }
  }
}