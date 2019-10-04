using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void Periods()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Ohlcv.Periods();

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "Periods executed successfully, " +
          $"{response.Periods.Count} periods returned"
        : $"Periods error: {response.ErrorMessage}");
    }
  }
}