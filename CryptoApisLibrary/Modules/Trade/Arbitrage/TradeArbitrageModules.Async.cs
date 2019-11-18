using System.Threading;
using System.Threading.Tasks;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;

namespace CryptoApisLibrary.Modules.Trade.Arbitrage
{
    internal partial class TradeArbitrageModules
    {
        public Task<OrderBookResponse> GetAsync(CancellationToken cancellationToken,
            Exchange exchange, Asset baseAsset, Asset quoteAsset)
        {
            var request = Requests.OrderBook(exchange, baseAsset, quoteAsset);
            return GetAsyncResponse<OrderBookResponse>(request, cancellationToken);
        }
    }
}