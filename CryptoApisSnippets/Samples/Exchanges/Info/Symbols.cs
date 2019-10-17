using System;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void Symbols()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Info.Symbols(skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "Symbols executed successfully, " +
          $"{response.Symbols.Count} symbols returned"
        : $"Symbols error: {response.ErrorMessage}");
    }
  }
}