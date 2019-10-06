using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System.Threading;

namespace CryptoApisSdkLibrary.Modules.Exchanges.OrderBook
{
    internal partial class ExchangeOrderBookModules
    {
        public OrderBookResponse Get(Exchange exchange, Asset baseAsset, Asset quoteAsset)
        {
            return GetAsync(CancellationToken.None, exchange, baseAsset, quoteAsset).GetAwaiter().GetResult();
        }
    }
}