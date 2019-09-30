using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void GetAssets()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.GetAssets(skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAssets executed successfully, " +
          $"{response.Assets.Count} assets returned"
        : $"GetAssets error: {response.ErrorMessage}");
    }
  }
}