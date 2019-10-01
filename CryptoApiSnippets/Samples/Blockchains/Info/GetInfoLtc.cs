using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoLtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetInfo<GetBtcInfoResponse>(
        NetworkCoin.LtcMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoLtc executed successfully, " +
          $"difficulty is {response.Info.Difficulty} now"
        : $"GetInfoLtc error: {response.ErrorMessage}");
    }
  }
}