using System;
using CryptoApisLibrary.DataTypes;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void SymbolsInExchange()
    {
      var exchange = new Exchange("5b1ea9d21090c200146f7366");

      var manager = new CryptoManager(ApiKey);
      var response = manager.Exchanges.Info.SymbolsInExchange(exchange, skip: 0, limit: 10);

      Console.WriteLine(string.IsNullOrEmpty(response.ErrorMessage)
        ? "SymbolsInExchange executed successfully, " +
          $"{response.Infos.Count} symbols returned"
        : $"SymbolsInExchange error: {response.ErrorMessage}");
    }
  }
}