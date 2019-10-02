using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByTransactionIdBch()
    {
      var transactionId = "066100ef7304e0467aeac07b8f8866ddb30e6a0b8c935bc79f0870a081a88977";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfo<BtcTransactionInfoResponse>(
        NetworkCoin.BchTestNet, transactionId);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoByTransactionIdBch executed successfully, " +
          $"block hash is {response.Transaction.BlockHash}"
        : $"GetInfoByTransactionIdBch error: {response.ErrorMessage}");
    }
  }
}