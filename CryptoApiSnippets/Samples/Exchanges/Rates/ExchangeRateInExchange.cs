using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void ExchangeRateInExchange()
    {
      var baseAsset = new Asset("5b1ea92e584bf50020130612");
      var quoteAsset = new Asset("5b1ea92e584bf50020130615");
      var exchange = new Exchange("5b4366dab98b280001540e16");

            var manager = new CryptoManager(ApiKey);
      var exchangeRate = manager.Exchanges.Rates.ExchangeRate(baseAsset, quoteAsset, exchange);
      Console.WriteLine(string.IsNullOrEmpty(exchangeRate.ErrorMessage)
        ? "ExchangeRateInExchange executed successfully, a MedianPrice for " +
          $"{exchangeRate.Rate.BaseAssetId}/{exchangeRate.Rate.QuoteAssetId} " +
          $"is {exchangeRate.Rate.MedianPrice}"
        : $"ExchangeRateInExchange error: {exchangeRate.ErrorMessage}");
    }
  }
}