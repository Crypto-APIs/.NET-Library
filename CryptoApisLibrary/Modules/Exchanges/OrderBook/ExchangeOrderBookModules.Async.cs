using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Exchanges.OrderBook
{
    internal partial class ExchangeOrderBookModules
    {
        public Task<OrderBookResponse> GetAsync(CancellationToken cancellationToken,
            Exchange exchange, Asset baseAsset, Asset quoteAsset)
        {
            var request = Requests.OrderBook(exchange, baseAsset, quoteAsset);
            return GetAsyncResponse<OrderBookResponse>(request, cancellationToken);
        }
    }
}