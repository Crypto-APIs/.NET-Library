using System;
using CryptoApisLibrary.DataTypes;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void HistoricalTrades()
    {
      var symbol = new Symbol { Id = "5b3a4d323d8cea0001653bb0" };
      var startPeriod = new DateTime(2019, 02, 04);
      var endPeriod = new DateTime(2019, 02, 05);

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Trades.Historical(
        symbol, startPeriod, endPeriod);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "HistoricalTrades executed successfully, " +
          $"{response.Trades.Count} trades returned"
        : $"HistoricalTrades error: {response.ErrorMessage}");
    }
  }
}