using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetInfosByBlockHeightDash()
    {
      var blockHeight = 124403;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Transaction.GetInfos<GetBtcTransactionInfosResponse>(
        NetworkCoin.DashTestNet, blockHeight, skip: 0, limit: 4);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetInfosByBlockHeightDash executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetInfosByBlockHeightDash error: {response.ErrorMessage}");
    }
  }
}