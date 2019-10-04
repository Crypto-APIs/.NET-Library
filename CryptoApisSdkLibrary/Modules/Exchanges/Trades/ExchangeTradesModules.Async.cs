using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Exchanges.Trades
{
    internal partial class ExchangeTradesModules
    {
        public Task<LatestTradesResponse> LatestTradesAsync(CancellationToken cancellationToken,
    int skip = 0, int limit = 50)
        {
            var request = Requests.LatestTrades(skip, limit);
            return GetAsyncResponse<LatestTradesResponse>(request, cancellationToken);
        }

        public Task<LatestTradesResponse> LatestTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, int skip = 0, int limit = 50)
        {
            var request = Requests.LatestTrades(symbol, skip, limit);
            return GetAsyncResponse<LatestTradesResponse>(request, cancellationToken);
        }

        public Task<LatestTradesResponse> LatestTradesAsync(CancellationToken cancellationToken,
            Exchange exchange, int skip = 0, int limit = 50)
        {
            var request = Requests.LatestTrades(exchange, skip, limit);
            return GetAsyncResponse<LatestTradesResponse>(request, cancellationToken);
        }

        public Task<LatestTradesResponse> LatestTradesAsync(CancellationToken cancellationToken,
            Asset baseAsset, int skip = 0, int limit = 50)
        {
            var request = Requests.LatestTrades(baseAsset, skip, limit);
            return GetAsyncResponse<LatestTradesResponse>(request, cancellationToken);
        }

        public Task<LatestTradesResponse> LatestTradesAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50)
        {
            var request = Requests.LatestTrades(baseAsset, quoteAsset, skip, limit);
            return GetAsyncResponse<LatestTradesResponse>(request, cancellationToken);
        }

        public Task<LatestTradesResponse> LatestTradesAsync(CancellationToken cancellationToken,
            Exchange exchange, Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50)
        {
            var request = Requests.LatestTrades(exchange, baseAsset, quoteAsset, skip, limit);
            return GetAsyncResponse<LatestTradesResponse>(request, cancellationToken);
        }

        public Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, int skip = 0, int limit = 50)
        {
            var request = Requests.HistoricalTrades(
                symbol, skip, limit, startPeriod: null, endPeriod: null);
            return GetAsyncResponse<HistoricalTradesResponse>(request, cancellationToken);
        }

        public Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.HistoricalTrades(
                symbol, skip, limit, startPeriod, endPeriod: null);
            return GetAsyncResponse<HistoricalTradesResponse>(request, cancellationToken);
        }

        public Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.HistoricalTrades(symbol, skip, limit, startPeriod, endPeriod);
            return GetAsyncResponse<HistoricalTradesResponse>(request, cancellationToken);
        }

        public Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
            Exchange exchange, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.HistoricalTrades(exchange, skip, limit, startPeriod, null);
            return GetAsyncResponse<HistoricalTradesResponse>(request, cancellationToken);
        }

        public Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
            Exchange exchange, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.HistoricalTrades(exchange, skip, limit, startPeriod, endPeriod);
            return GetAsyncResponse<HistoricalTradesResponse>(request, cancellationToken);
        }

        public Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
            Asset baseAsset, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.HistoricalTrades(baseAsset, skip, limit, startPeriod, null);
            return GetAsyncResponse<HistoricalTradesResponse>(request, cancellationToken);
        }

        public Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken, Asset baseAsset, DateTime startPeriod,
            DateTime endPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.HistoricalTrades(baseAsset, skip, limit, startPeriod, endPeriod);
            return GetAsyncResponse<HistoricalTradesResponse>(request, cancellationToken);
        }

        public Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken, Asset baseAsset, Asset quoteAsset, DateTime startPeriod,
            int skip = 0, int limit = 50)
        {
            var request = Requests.HistoricalTrades(baseAsset, quoteAsset, skip, limit, startPeriod, null);
            return GetAsyncResponse<HistoricalTradesResponse>(request, cancellationToken);
        }

        public Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken, Asset baseAsset, Asset quoteAsset, DateTime startPeriod,
            DateTime endPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.HistoricalTrades(baseAsset, quoteAsset, skip, limit, startPeriod, endPeriod);
            return GetAsyncResponse<HistoricalTradesResponse>(request, cancellationToken);
        }

        public Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken, Exchange exchange, Asset baseAsset, Asset quoteAsset,
            DateTime startPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.HistoricalTrades(exchange, baseAsset, quoteAsset, skip, limit, startPeriod, null);
            return GetAsyncResponse<HistoricalTradesResponse>(request, cancellationToken);
        }

        public Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken, Exchange exchange, Asset baseAsset, Asset quoteAsset,
            DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.HistoricalTrades(exchange, baseAsset, quoteAsset, skip, limit, startPeriod, endPeriod);
            return GetAsyncResponse<HistoricalTradesResponse>(request, cancellationToken);
        }
    }
}