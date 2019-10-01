using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHistoricalPaymentsBtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.
        GetHistoricalPayments<GetBtcHistoricalPaymentsResponse>(
          NetworkCoin.BtcTestNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHistoricalPaymentsBtc executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetHistoricalPaymentsBtc error: {response.ErrorMessage}");
    }
  }
}