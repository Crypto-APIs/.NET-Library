using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void GetLatestQuoteTrades()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.GetLatestQuoteTrades(limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetLatestQuoteTrades executed successfully, " +
          $"{response.QuoteTrades.Count} trades returned"
        : $"GetLatestQuoteTrades error: {response.ErrorMessage}");
    }
  }
}