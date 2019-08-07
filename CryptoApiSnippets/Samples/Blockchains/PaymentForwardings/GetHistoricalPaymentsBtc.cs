using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHistoricalPaymentsBtc()
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Testnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.GetHistoricalPayments(
        coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHistoricalPaymentsBtc executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetHistoricalPaymentsBtc error: {response.ErrorMessage}");
    }
  }
}