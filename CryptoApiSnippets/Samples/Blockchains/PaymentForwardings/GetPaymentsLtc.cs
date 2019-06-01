using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetPaymentsLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.GetPayments(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetPaymentsLtc executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetPaymentsLtc error: {response.ErrorMessage}");
    }
  }
}