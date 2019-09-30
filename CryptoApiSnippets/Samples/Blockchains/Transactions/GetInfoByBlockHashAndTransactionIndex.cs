using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByBlockHashAndTransactionIndex()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Mainnet;
      var blockHash = "0x0d13e81c01de31060a2830bb53761ef29ac5c4e5c1d43e309ca9a101140e394c";
      var transactionIndex = 79;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfo(
        coin, network, blockHash, transactionIndex);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoByBlockHashAndTransactionIndex executed successfully, " +
          $"transaction hash is {response.Payload.TransactionHash}"
        : $"GetInfoByBlockHashAndTransactionIndex error: {response.ErrorMessage}");
    }
  }
}