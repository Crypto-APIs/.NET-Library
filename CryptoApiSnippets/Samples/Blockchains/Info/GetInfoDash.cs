using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoDash()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetInfo<GetBtcInfoResponse>(
        NetworkCoin.DashMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoDash executed successfully, " +
          $"difficulty is {response.Info.Difficulty} now"
        : $"GetInfoDash error: {response.ErrorMessage}");
    }
  }
}