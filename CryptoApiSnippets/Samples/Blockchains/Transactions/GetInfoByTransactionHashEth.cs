using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByTransactionHashEth()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Mainnet;
      var transactionHash = "0x0d13e81c01de31060a2830bb53761ef29ac5c4e5c1d43e309ca9a101140e394c";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfo(
        coin, network, transactionHash);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetInfoByTransactionHashEth executed successfully, " +
          $"block hash is {response.Payload.BlockHash}"
        : $"GetInfoByTransactionHashEth error: {response.ErrorMessage}");
    }
  }
}