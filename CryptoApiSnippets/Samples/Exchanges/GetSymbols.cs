using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void GetSymbols()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.GetSymbols(skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetSymbols executed successfully, " +
          $"{response.Symbols.Count} symbols returned"
        : $"GetSymbols error: {response.ErrorMessage}");
    }
  }
}