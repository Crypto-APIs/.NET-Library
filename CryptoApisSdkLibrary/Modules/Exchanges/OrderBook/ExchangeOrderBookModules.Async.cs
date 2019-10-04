using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Exchanges.OrderBook
{
    internal partial class ExchangeOrderBookModules
    {
        public Task<OrderBookResponse> OrderBookAsync(CancellationToken cancellationToken,
            Exchange exchange, Asset baseAsset, Asset quoteAsset)
        {
            var request = Requests.OrderBook(exchange, baseAsset, quoteAsset);
            return GetAsyncResponse<OrderBookResponse>(request, cancellationToken);
        }
    }
}