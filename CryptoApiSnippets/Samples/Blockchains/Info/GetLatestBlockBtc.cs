using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetLatestBlockBtc()
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetLatestBlock(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetLatestBlockBtc executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetLatestBlockBtc error: {response.ErrorMessage}");
    }
  }
}