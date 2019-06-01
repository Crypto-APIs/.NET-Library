using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetLatestBlockEth()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetLatestBlock(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetLatestBlockEth executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetLatestBlockEth error: {response.ErrorMessage}");
    }
  }
}