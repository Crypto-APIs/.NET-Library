using System;
using CryptoApisLibrary.DataTypes;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void LatestOhlcvByAssetAndExchange()
    {
      var exchange = new Exchange("5b4e131b6ab304000a106945");
      var asset = new Asset("5b1ea92e584bf50020130845");
      var period = new Period("1day");

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Ohlcv.Latest(exchange, asset, period, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "LatestOhlcvByAssetAndExchange executed successfully, " +
          $"{response.Ohlcv.Count} records returned"
        : $"LatestOhlcvByAssetAndExchange error: {response.ErrorMessage}");
    }
  }
}