using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByTransactionHashLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;
      var transactionHash = "d77cb6b67f4d559d1e74ef400c6f540c90ca89e9abe4efb497fd0e62c5f8e0aa";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfo(
        coin, network, transactionHash);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetInfoByTransactionHashLtc executed successfully, " +
          $"block hash is {response.Transaction.BlockHash}"
        : $"GetInfoByTransactionHashLtc error: {response.ErrorMessage}");
    }
  }
}