using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetLatestBlockBch()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetLatestBlock<GetBtcHashInfoResponse>(
        NetworkCoin.BchMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetLatestBlockBch executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetLatestBlockBch error: {response.ErrorMessage}");
    }
  }
}