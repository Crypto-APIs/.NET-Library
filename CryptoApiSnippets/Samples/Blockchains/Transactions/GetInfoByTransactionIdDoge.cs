using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByTransactionIdDoge()
    {
      var transactionId = "512ba78dbe7265f07ebec2297d59e0ddccc884fbf2fdd72cb14f924ffb9aefde";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfo<BtcTransactionInfoResponse>(
        NetworkCoin.DogeTestNet, transactionId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoByTransactionIdDoge executed successfully, " +
          $"block hash is {response.Transaction.BlockHash}"
        : $"GetInfoByTransactionIdDoge error: {response.ErrorMessage}");
    }
  }
}