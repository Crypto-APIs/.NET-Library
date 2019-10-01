using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetPaymentsBtc()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.
        GetPayments<GetBtcPaymentsResponse>(NetworkCoin.BtcMainNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetPaymentsBtc executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetPaymentsBtc error: {response.ErrorMessage}");
    }
  }
}