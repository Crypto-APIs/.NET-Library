using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetAddressTransactionsBtc()
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;
      var address = "3DrVotri9Rq2xcHqCMKpVUoyU6pvoWRtY3";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GetAddressTransactions(
        coin, network, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAddressTransactionsBtc executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetAddressTransactionsBtc error: {response.ErrorMessage}");
    }
  }
}