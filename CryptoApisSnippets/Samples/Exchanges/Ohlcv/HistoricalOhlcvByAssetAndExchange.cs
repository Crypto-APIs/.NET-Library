using CryptoApisLibrary.DataTypes;
using System;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void HistoricalOhlcvByAssetAndExchange()
    {
      var exchange = new Exchange("5b3a4d323d8cea0001653bb0");
      var asset = new Asset("5b1ea92e584bf50020130845");
      var period = new Period("6hrs");
      var startPeriod = new DateTime(2019, 02, 04);
      var endPeriod = new DateTime(2019, 02, 05);

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Ohlcv.Historical(
        exchange, asset, period, startPeriod, endPeriod, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "HistoricalOhlcvByAssetAndExchange executed successfully, " +
          $"{response.Ohlcv.Count} records returned"
        : $"HistoricalOhlcvByAssetAndExchange error: {response.ErrorMessage}");
    }
  }
}