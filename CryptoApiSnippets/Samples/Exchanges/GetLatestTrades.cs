using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void GetLatestTrades()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.GetLatestTrades(limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetLatestTrades executed successfully, " +
          $"{response.Trades.Count} trades returned"
        : $"GetLatestTrades error: {response.ErrorMessage}");
    }
  }
}