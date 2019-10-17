using System;
using CryptoApisLibrary.DataTypes;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void AssetDetails()
    {
      var asset = new Asset("5b755dacd5dd99000b3d92b2");

      var manager = new CryptoManager(ApiKey);
      var exchangeDetails = manager.Exchanges.Info.AssetDetails(asset);
      Console.WriteLine(string.IsNullOrEmpty(exchangeDetails.ErrorMessage)
        ? "AssetDetails executed successfully, " +
          $"a Name of asset is {exchangeDetails.Asset.Name}"
        : $"AssetDetails error: {exchangeDetails.ErrorMessage}");
    }
  }
}