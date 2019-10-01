using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetLatestBlockBtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetLatestBlock<GetBtcHashInfoResponse>(
        NetworkCoin.BtcMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetLatestBlockBtc executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetLatestBlockBtc error: {response.ErrorMessage}");
    }
  }
}