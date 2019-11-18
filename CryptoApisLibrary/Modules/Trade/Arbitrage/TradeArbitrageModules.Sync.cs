using System.Threading;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;

namespace CryptoApisLibrary.Modules.Trade.Arbitrage
{
    internal partial class TradeArbitrageModules
    {
        public OrderBookResponse Get(Exchange exchange, Asset baseAsset, Asset quoteAsset)
        {
            return GetAsync(CancellationToken.None, exchange, baseAsset, quoteAsset).GetAwaiter().GetResult();
        }
    }
}