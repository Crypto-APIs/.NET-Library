using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void Exchanges()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Info.Exchanges(skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "Exchanges executed successfully, " +
          $"{response.Exchanges.Count} exchanges returned"
        : $"Exchanges error: {response.ErrorMessage}");
    }
  }
}