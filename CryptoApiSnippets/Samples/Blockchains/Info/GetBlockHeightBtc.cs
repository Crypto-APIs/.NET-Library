using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetBlockHeightBtc()
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;
      var blockHeight = 546903;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetBlockHeigh(coin, network, blockHeight);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetBlockHeightBtc executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetBlockHeightBtc error: {response.ErrorMessage}");
    }
  }
}