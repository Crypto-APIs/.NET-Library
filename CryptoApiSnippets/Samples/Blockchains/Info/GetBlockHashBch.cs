using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetBlockHashBch()
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;
      var blockHash = "00000000000000000435d5c48d2c8dd4ca84c4f10a5b6e5a9cd6c81215dbe589";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetBlockHash(coin, network, blockHash);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetBlockHashBch executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetBlockHashBch error: {response.ErrorMessage}");
    }
  }
}