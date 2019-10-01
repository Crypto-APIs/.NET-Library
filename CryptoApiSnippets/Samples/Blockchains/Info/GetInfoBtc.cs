using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoBtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetInfo<GetBtcInfoResponse>(
        NetworkCoin.BtcMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoBtc executed successfully, " +
          $"difficulty is {response.Info.Difficulty} now"
        : $"GetInfoBtc error: {response.ErrorMessage}");
    }
  }
}