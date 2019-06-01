using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void GetHistoricalTrades()
    {
      var symbol = new Symbol("5b3a4d323d8cea0001653bb0");
      var startPeriod = new DateTime(2019, 02, 04);
      var endPeriod = new DateTime(2019, 02, 05);

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.GetHistoricalTrades(
        symbol, startPeriod, endPeriod);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHistoricalTrades executed successfully, " +
          $"{response.Trades.Count} trades returned"
        : $"GetHistoricalTrades error: {response.ErrorMessage}");
    }
  }
}