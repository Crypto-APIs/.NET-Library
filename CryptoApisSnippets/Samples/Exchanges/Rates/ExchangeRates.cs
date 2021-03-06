﻿using System;
using CryptoApisLibrary.DataTypes;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void ExchangeRates()
    {
      var baseAsset = new Asset("5b1ea92e584bf50020130615");

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Rates.GetAny(baseAsset, skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "ExchangeRates executed successfully, " +
          $"{response.Rates.Count} rates returned"
        : $"ExchangeRates error: {response.ErrorMessage}");
    }
  }
}