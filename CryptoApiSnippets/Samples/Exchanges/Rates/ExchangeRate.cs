using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void ExchangeRate()
    {
      var baseAsset = new Asset("5b1ea92e584bf50020130612");
      var quoteAsset = new Asset("5b1ea92e584bf50020130615");

      var manager = new CryptoManager(ApiKey);
      var exchangeRate = manager.Exchanges.Rates.GetOne(baseAsset, quoteAsset);
      Console.WriteLine(string.IsNullOrEmpty(exchangeRate.ErrorMessage)
        ? "ExchangeRate executed successfully, a MedianPrice for " +
          $"{exchangeRate.ExchangeRate.BaseAssetId}/{exchangeRate.ExchangeRate.QuoteAssetId} " +
          $"is {exchangeRate.ExchangeRate.MedianPrice}"
        : $"ExchangeRate error: {exchangeRate.ErrorMessage}");
    }
  }
}