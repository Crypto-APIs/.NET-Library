using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHistoricalPaymentsDash()
    {
      var coin = BtcSimilarCoin.Dash;
      var network = BtcSimilarNetwork.Testnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.GetHistoricalPayments(
        coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHistoricalPaymentsDash executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetHistoricalPaymentsDash error: {response.ErrorMessage}");
    }
  }
}