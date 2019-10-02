using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByBlockHashAndTransactionIndex()
    {
      var blockHash = "0x0d13e81c01de31060a2830bb53761ef29ac5c4e5c1d43e309ca9a101140e394c";
      var transactionIndex = 79;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfo<EthTransactionInfoResponse>(
        NetworkCoin.EthMainNet, blockHash, transactionIndex);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoByBlockHashAndTransactionIndex executed successfully, " +
          $"transaction hash is {response.Payload.TransactionHash}"
        : $"GetInfoByBlockHashAndTransactionIndex error: {response.ErrorMessage}");
    }
  }
}