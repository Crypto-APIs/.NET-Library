using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByTransactionIdLtc()
    {
      var transactionId = "924e34052a093da9c9bb74ff1802034be5c98df811333a5da31437116ab81b5e";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfo<BtcTransactionInfoResponse>(
        NetworkCoin.LtcMainNet, transactionId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoByTransactionIdLtc executed successfully, " +
          $"block hash is {response.Transaction.BlockHash}"
        : $"GetInfoByTransactionIdLtc error: {response.ErrorMessage}");
    }
  }
}