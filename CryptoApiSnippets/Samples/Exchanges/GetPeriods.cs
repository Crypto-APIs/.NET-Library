using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void GetPeriods()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.GetPeriods();

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetPeriods executed successfully, " +
          $"{response.Periods.Count} periods returned"
        : $"GetPeriods error: {response.ErrorMessage}");
    }
  }
}