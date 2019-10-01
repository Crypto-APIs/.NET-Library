using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetLatestBlockDoge()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetLatestBlock<GetBtcHashInfoResponse>(
        NetworkCoin.DogeMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetLatestBlockDoge executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetLatestBlockDoge error: {response.ErrorMessage}");
    }
  }
}