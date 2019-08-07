using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void GetArbitrageInfo()
    {
      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.GetArbitrageInfo(limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "GetArbitrageInfo executed successfully, " +
          $"{response.Trades.Count} trades returned"
        : $"GetArbitrageInfo error: {response.ErrorMessage}");
    }
  }
}