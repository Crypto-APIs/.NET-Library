using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void LatestOhlcv()
    {
      var symbol = new Symbol("5b3a4d323d8cea0001653bb0");
      var period = new Period("1day");

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Ohlcv.Latest(symbol, period, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "LatestOhlcv executed successfully, " +
          $"{response.Ohlcv.Count} records returned"
        : $"LatestOhlcv error: {response.ErrorMessage}");
    }
  }
}