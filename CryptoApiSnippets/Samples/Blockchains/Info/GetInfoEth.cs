using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoEth()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetInfo<GetEthInfoResponse>(
        NetworkCoin.EthMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoEth executed successfully, " +
          $"difficulty is {response.Info.Difficulty} now"
        : $"GetInfoEth error: {response.ErrorMessage}");
    }
  }
}