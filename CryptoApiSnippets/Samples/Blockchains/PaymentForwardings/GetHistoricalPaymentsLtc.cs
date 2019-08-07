using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHistoricalPaymentsLtc()
    {
      var coin = BtcSimilarCoin.Ltc;
      var network = BtcSimilarNetwork.Testnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.GetHistoricalPayments(
        coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHistoricalPaymentsLtc executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetHistoricalPaymentsLtc error: {response.ErrorMessage}");
    }
  }
}