using System;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void LatestTrades()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Trades.Latest(limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "LatestTrades executed successfully, " +
          $"{response.Trades.Count} trades returned"
        : $"LatestTrades error: {response.ErrorMessage}");
    }
  }
}