using CryptoApisSdkLibrary.DataTypes;
using System;

namespace CryptoApiSnippets.Samples.Exchanges
{
  partial class ExchangeSnippets
  {
    public void OrderBook()
    {
      var exchange = new Exchange("5bfc325c9c40a100014db8ff");
      var baseAsset = new Asset(); // todo: сделать реальный id (BITFINEX_SPOT_EOS_BTC)
            var quoteAsset = new Asset();

      var manager = new CryptoManager(ApiKey);
      var orderBook = manager.Exchanges.OrderBook.OrderBook(
          exchange, baseAsset, quoteAsset);
      Console.WriteLine(string.IsNullOrEmpty(orderBook.ErrorMessage)
        ? "OrderBook executed successfully, " +
          $"asks count is {orderBook.OrderBook.Depth.Asks.Count}, " +
          $"bids count is {orderBook.OrderBook.Depth.Bids.Count}."
        : $"OrderBook error: {orderBook.ErrorMessage}");
    }
  }
}