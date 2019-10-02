using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByBlockHeightAndTransactionIndex()
    {
      var blockHeight = 6530876;
      var transactionIndex = 79;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfo<EthTransactionInfoResponse>(
        NetworkCoin.EthMainNet, blockHeight, transactionIndex);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoByBlockHeightAndTransactionIndex executed successfully, " +
          $"transaction hash is {response.Payload.TransactionHash}"
        : $"GetInfoByBlockHeightAndTransactionIndex error: {response.ErrorMessage}");
    }
  }
}