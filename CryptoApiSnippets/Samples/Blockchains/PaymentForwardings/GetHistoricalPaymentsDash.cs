using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHistoricalPaymentsDash()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.
        GetHistoricalPayments<GetBtcHistoricalPaymentsResponse>(
          NetworkCoin.DashTestNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHistoricalPaymentsDash executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetHistoricalPaymentsDash error: {response.ErrorMessage}");
    }
  }
}