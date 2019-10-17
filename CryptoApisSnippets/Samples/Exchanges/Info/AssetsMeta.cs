using System;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void AssetsMeta()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Info.AssetsMeta(skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "AssetsMeta executed successfully, " +
          $"{response.Assets.Count} assets returned"
        : $"AssetsMeta error: {response.ErrorMessage}");
    }
  }
}