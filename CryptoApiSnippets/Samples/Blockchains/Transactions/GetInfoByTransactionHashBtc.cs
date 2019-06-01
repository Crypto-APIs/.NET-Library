using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByTransactionHashBtc()
    {
      var coin = BtcSimilarCoin.Bch;
      var network = BtcSimilarNetwork.Mainnet;
      var transactionHash = "5a4ebf66822b0b2d56bd9dc64ece0bc38ee7844a23ff1d7320a88c5fdb2ad3e2";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfo(
        coin, network, transactionHash);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetInfoByTransactionHashBtc executed successfully, " +
          $"block hash is {response.Transaction.BlockHash}"
        : $"GetInfoByTransactionHashBtc error: {response.ErrorMessage}");
    }
  }
}