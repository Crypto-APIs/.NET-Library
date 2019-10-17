using System;
using CryptoApisLibrary.DataTypes;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void ExchangesSupportingAsset()
    {
      var asset = new Asset("5b1ea92e584bf50020130612");

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Info.ExchangesSupportingAsset(asset, skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "ExchangesSupportingAsset executed successfully, " +
          $"{response.Infos.Count} exchanges returned"
        : $"ExchangesSupportingAsset error: {response.ErrorMessage}");
    }
  }
}