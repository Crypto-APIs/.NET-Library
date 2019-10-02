﻿using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System;

namespace CryptoApiSnippets.Samples.Blockchains
{
  partial class BlockchainSnippets
  {
    public void GetHistoricalPaymentsBch()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Blockchains.PaymentForwarding.
        GetHistoricalPayments<GetBtcHistoricalPaymentsResponse>(
          NetworkCoin.BchTestNet);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetHistoricalPaymentsBch executed successfully, " +
          $"{response.Payments.Count} payments returned"
        : $"GetHistoricalPaymentsBch error: {response.ErrorMessage}");
    }
  }
}