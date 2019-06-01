using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetPaymentsBtc()
    {
      var coin = BtcSimilarCoin.Btc;
      var network = BtcSimilarNetwork.Mainnet;

      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.GetPayments(coin, network);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetPaymentsBtc executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetPaymentsBtc error: {response.ErrorMessage}");
    }
  }
}