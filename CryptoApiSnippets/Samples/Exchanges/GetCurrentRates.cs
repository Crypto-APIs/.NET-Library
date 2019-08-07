using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void GetCurrentRates()
    {
      var asset = new Asset("USD");

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.GetCurrentRates(asset, skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetCurrentRates executed successfully, " +
          $"{response.Rates.Count} rates returned"
        : $"GetCurrentRates error: {response.ErrorMessage}");
    }
  }
}