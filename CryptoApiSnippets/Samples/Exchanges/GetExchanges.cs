using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void GetExchanges()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.GetExchanges(skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? $"GetExchanges executed successfully, " +
          $"{response.Exchanges.Count} exchanges returned"
        : $"GetExchanges error: {response.ErrorMessage}");
    }
  }
}