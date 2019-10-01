using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetBlockHashDoge()
    {
      var blockHash = "f21dc70cb44c180261e31a222202678602d605e7697332cb2395386fa309ad3b";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Info.GetBlockHash<GetBtcHashInfoResponse>(
        NetworkCoin.DogeMainNet, blockHash);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetBlockHashDoge executed successfully, " +
          $"difficulty is {response.HashInfo.Difficulty} now"
        : $"GetBlockHashDoge error: {response.ErrorMessage}");
    }
  }
}