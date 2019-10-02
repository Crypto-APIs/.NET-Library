using System;
using System.Threading;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public async void GetAssets()
    {
      var manager = new CryptoManager(ApiKey);
      //var response = manager.Exchanges.GetAssets(skip: 0, limit: 10);
      var response = await manager.Exchanges.GetAssetsAsync(CancellationToken.None, skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetAssets executed successfully, " +
          $"{response.Assets.Count} assets returned"
        : $"GetAssets error: {response.ErrorMessage}");
    }
  }
}