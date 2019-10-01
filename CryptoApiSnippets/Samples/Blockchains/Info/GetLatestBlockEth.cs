using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetLatestBlockEth()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetLatestBlock<GetEthHashInfoResponse>(
        NetworkCoin.EthMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetLatestBlockEth executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetLatestBlockEth error: {response.ErrorMessage}");
    }
  }
}