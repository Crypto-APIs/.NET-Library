using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByBlockHeightAndTransactionIndex()
    {
      var coin = EthSimilarCoin.Eth;
      var network = EthSimilarNetwork.Mainnet;
      var blockHeight = 6530876;
      var transactionIndex = 79;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfo(
        coin, network, blockHeight, transactionIndex);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoByBlockHeightAndTransactionIndex executed successfully, " +
          $"transaction hash is {response.Payload.TransactionHash}"
        : $"GetInfoByBlockHeightAndTransactionIndex error: {response.ErrorMessage}");
    }
  }
}