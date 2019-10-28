using CryptoApisLibrary.DataTypes;
using System;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void HistoricalOhlcvByExchange()
    {
      var exchange = new Exchange("5b4e131b6ab304000a106945");
      var period = new Period("6hrs");
      var startPeriod = new DateTime(2019, 02, 04);
      var endPeriod = new DateTime(2019, 02, 05);

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Ohlcv.Historical(
        exchange, period, startPeriod, endPeriod, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "HistoricalOhlcvByExchange executed successfully, " +
          $"{response.Ohlcv.Count} records returned"
        : $"HistoricalOhlcvByExchange error: {response.ErrorMessage}");
    }
  }
}