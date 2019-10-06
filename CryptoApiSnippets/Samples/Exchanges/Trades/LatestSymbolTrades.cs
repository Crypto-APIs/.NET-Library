using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void LatestSymbolTrades()
    {
      var symbol = new Symbol("5b3a4d343d8cea0001653d1d");

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Trades.Latest(symbol, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetLatestSymbolTrades executed successfully, " +
          $"{response.Trades.Count} trades returned"
        : $"GetLatestSymbolTrades error: {response.ErrorMessage}");
    }
  }
}