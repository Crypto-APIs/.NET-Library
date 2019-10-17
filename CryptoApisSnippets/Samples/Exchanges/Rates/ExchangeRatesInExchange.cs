using System;
using CryptoApisLibrary.DataTypes;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void ExchangeRatesInExchange()
    {
      var baseAsset = new Asset("5b1ea92e584bf50020130615");
      var exchange = new Exchange("5b4366dab98b280001540e16");

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Rates.GetAny(baseAsset, exchange, skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "ExchangeRatesInExchange executed successfully, " +
          $"{response.Rates.Count} rates returned"
        : $"ExchangeRatesInExchange error: {response.ErrorMessage}");
    }
  }
}