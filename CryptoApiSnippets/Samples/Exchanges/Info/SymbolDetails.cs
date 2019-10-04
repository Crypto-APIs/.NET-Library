using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void SymbolDetails()
    {
      var symbol = new Symbol("5bfc325c9c40a100014db8ff");

      var manager = new CryptoManager(ApiKey);
      var exchangeDetails = manager.Exchanges.Info.SymbolDetails(symbol);
      Console.WriteLine(string.IsNullOrEmpty(exchangeDetails.ErrorMessage)
        ? "SymbolDetails executed successfully, " +
          $"a Name of symbol is {exchangeDetails.Symbol}"
        : $"SymbolDetails error: {exchangeDetails.ErrorMessage}");
    }
  }
}