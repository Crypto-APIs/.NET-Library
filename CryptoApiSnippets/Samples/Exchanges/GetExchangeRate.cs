using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void GetExchangeRate()
    {
      var baseAsset = new Asset("BTC");
      var quoteAsset = new Asset("USD");

      var manager = new CryptoManager(ApiKey);
      var exchangeRate = manager.Exchanges.GetExchangeRate(baseAsset, quoteAsset);
      Console.WriteLine(string.IsNullOrEmpty(exchangeRate.ErrorMessage)
        ? $"GetExchangeRate executed successfully, a MedianPrice for " +
          $"{exchangeRate.ExchangeRate.BaseAssetId}/{exchangeRate.ExchangeRate.QuoteAssetId} " +
          $"is {exchangeRate.ExchangeRate.MedianPrice}"
        : $"GetExchangeRate error: {exchangeRate.ErrorMessage}");
    }
  }
}