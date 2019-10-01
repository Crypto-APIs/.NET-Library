using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHistoricalPaymentsDoge()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.
        GetHistoricalPayments<GetBtcHistoricalPaymentsResponse>(
          NetworkCoin.DogeTestNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHistoricalPaymentsDoge executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetHistoricalPaymentsDoge error: {response.ErrorMessage}");
    }
  }
}