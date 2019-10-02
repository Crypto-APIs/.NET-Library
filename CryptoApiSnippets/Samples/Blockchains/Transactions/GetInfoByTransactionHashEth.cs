using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfoByTransactionHashEth()
    {
      var transactionHash = "0x0d13e81c01de31060a2830bb53761ef29ac5c4e5c1d43e309ca9a101140e394c";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfoByBlockHash<EthTransactionInfoResponse>(
        NetworkCoin.EthMainNet, transactionHash);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfoByTransactionHashEth executed successfully, " +
          $"block hash is {response.Payload.BlockHash}"
        : $"GetInfoByTransactionHashEth error: {response.ErrorMessage}");
    }
  }
}