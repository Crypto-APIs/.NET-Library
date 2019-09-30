using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetLatestBlockLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetLatestBlock(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetLatestBlockLtc executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetLatestBlockLtc error: {response.ErrorMessage}");
    }
  }
}