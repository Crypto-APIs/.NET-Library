using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void GetHistoricalData()
    {
      var symbol = new Symbol("5b3a4d323d8cea0001653bb0");
      var period = new Period("6hrs");
      var startPeriod = new DateTime(2019, 02, 04);
      var endPeriod = new DateTime(2019, 02, 05);

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.GetHistoricalData(
        symbol, period, startPeriod, endPeriod, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetHistoricalData executed successfully, " +
          $"{response.Ohlcv.Count} records returned"
        : $"GetHistoricalData error: {response.ErrorMessage}");
    }
  }
}