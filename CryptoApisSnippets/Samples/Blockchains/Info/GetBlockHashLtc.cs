using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetBlockHashLtc()
    {
      var blockHash = "f69e755922153ae0fa017322a3ee3463558f74b03dc2aed6261ae6f3dcd3dc53";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetBlockHash<GetBtcHashInfoResponse>(
        NetworkCoin.LtcMainNet, blockHash);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetBlockHashLtc executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetBlockHashLtc error: {response.ErrorMessage}");
    }
  }
}