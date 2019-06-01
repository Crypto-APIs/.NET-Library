using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetBlockHeightEth()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Rinkeby;
      var blockHeight = 523442;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetBlockHeigh(coin, network, blockHeight);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetBlockHeightEth executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetBlockHeightEth error: {response.ErrorMessage}");
    }
  }
}