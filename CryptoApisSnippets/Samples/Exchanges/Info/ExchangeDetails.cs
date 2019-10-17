using System;
using CryptoApisLibrary.DataTypes;

namespace CryptoApisSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void ExchangeDetails()
    {
      var exchange = new Exchange("5b1ea9d21090c200146f7366");

      var manager = new CryptoManager(ApiKey);
      var exchangeDetails = manager.Exchanges.Info.ExchangeDetails(exchange);
      Console.WriteLine(string.IsNullOrEmpty(exchangeDetails.ErrorMessage)
        ? "ExchangeDetails executed successfully, " +
          $"a Name of exchange is {exchangeDetails.Exchange.Name}"
        : $"ExchangeDetails error: {exchangeDetails.ErrorMessage}");
    }
  }
}