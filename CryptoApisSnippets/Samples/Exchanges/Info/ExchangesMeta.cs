using System;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void ExchangesMeta()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Info.ExchangesMeta(skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "ExchangesMeta executed successfully, " +
          $"{response.Exchanges.Count} exchanges returned"
        : $"ExchangesMeta error: {response.ErrorMessage}");
    }
  }
}