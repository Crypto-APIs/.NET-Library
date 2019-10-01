using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoDoge()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetInfo<GetBtcInfoResponse>(
        NetworkCoin.DogeMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoDoge executed successfully, " +
          $"difficulty is {response.Info.Difficulty} now"
        : $"GetInfoDoge error: {response.ErrorMessage}");
    }
  }
}