using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetAddressTransactionsBtc()
    {
      var address = "3DrVotri9Rq2xcHqCMKpVUoyU6pvoWRtY3";

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.Address.GetAddressTransactions<GetBtcAddressTransactionsResponse>(
        NetworkCoin.BtcMainNet, address);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAddressTransactionsBtc executed successfully, " +
          $"{response.Transactions.Count} transactions returned"
        : $"GetAddressTransactionsBtc error: {response.ErrorMessage}");
    }
  }
}