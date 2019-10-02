using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfosByBlockHashBtc()
    {
      var blockHash = "00000000000000000008b7233b8abb1519d0a1bc6579e209955539c303f3e6b1";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(
        NetworkCoin.BtcMainNet, blockHash, skip: 0, limit: 4);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfosByBlockHashBtc executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetInfosByBlockHashBtc error: {response.ErrorMessage}");
    }
  }
}