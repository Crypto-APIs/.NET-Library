using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHistoricalPaymentsLtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.
        GetHistoricalPayments<GetBtcHistoricalPaymentsResponse>(
          NetworkCoin.LtcTestNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHistoricalPaymentsLtc executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetHistoricalPaymentsLtc error: {response.ErrorMessage}");
    }
  }
}