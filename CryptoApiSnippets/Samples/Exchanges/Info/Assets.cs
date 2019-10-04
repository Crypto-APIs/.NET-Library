using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void Assets()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Info.Assets(skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "Assets executed successfully, " +
          $"{response.Assets.Count} assets returned"
        : $"Assets error: {response.ErrorMessage}");
    }
  }
}