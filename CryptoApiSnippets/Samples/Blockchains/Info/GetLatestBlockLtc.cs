using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetLatestBlockLtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetLatestBlock<GetBtcHashInfoResponse>(
        NetworkCoin.LtcMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetLatestBlockLtc executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetLatestBlockLtc error: {response.ErrorMessage}");
    }
  }
}