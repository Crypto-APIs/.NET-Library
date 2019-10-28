using System;
using CryptoApisLibrary.DataTypes;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void LatestOhlcvByExchange()
    {
      var exchange = new Exchange("5b4e131b6ab304000a106945");
      var period = new Period("1day");

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Ohlcv.Latest(exchange, period, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "LatestOhlcvByExchange executed successfully, " +
          $"{response.Ohlcv.Count} records returned"
        : $"LatestOhlcvByExchange error: {response.ErrorMessage}");
    }
  }
}