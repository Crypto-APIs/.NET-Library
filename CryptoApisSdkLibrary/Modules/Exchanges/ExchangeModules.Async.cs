using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Exchanges
{
    internal partial class ExchangeModules
    {
        public Task<ExchangesMetaResponse> ExchangesMetaAsync(CancellationToken cancellationToken, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangesMeta(skip, limit);
            return GetAsyncResponse<ExchangesMetaResponse>(request, cancellationToken);
        }

        public Task<ExchangesAssetsResponse> ExchangesSupportingPairsAsync(CancellationToken cancellationToken,
            Asset asset1, Asset asset2, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangesSupportingPairs(asset1, asset2, skip, limit);
            return GetAsyncResponse<ExchangesAssetsResponse>(request, cancellationToken);
        }

        public Task<ExchangesAssetsResponse> SymbolsInExchangeAsync(CancellationToken cancellationToken,
            Exchange exchange, int skip = 0, int limit = 50)
        {
            var request = Requests.AllSymbolsInExchange(exchange, skip, limit);
            return GetAsyncResponse<ExchangesAssetsResponse>(request, cancellationToken);
        }

        public Task<AssetsMetaResponse> AssetsMetaAsync(CancellationToken cancellationToken, int skip = 0, int limit = 50)
        {
            var request = Requests.AssetsMeta(skip, limit);
            return GetAsyncResponse<AssetsMetaResponse>(request, cancellationToken);
        }

        public Task<ExchangesSupportingAssetResponse> ExchangesSupportingAssetAsync(CancellationToken cancellationToken,
            Asset asset, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangesSupportingAsset(asset, skip, limit);
            return GetAsyncResponse<ExchangesSupportingAssetResponse>(request, cancellationToken);
        }

        public Task<AssetsResponse> AssetsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50)
        {
            var request = Requests.Assets(skip, limit);
            return GetAsyncResponse<AssetsResponse>(request, cancellationToken);
        }

        public Task<AssetDetailsResponse> AssetDetailsAsync(CancellationToken cancellationToken, Asset asset)
        {
            var request = Requests.AssetDetails(asset);
            return GetAsyncResponse<AssetDetailsResponse>(request, cancellationToken);
        }

        public Task<SymbolDetailsResponse> SymbolDetailsAsync(CancellationToken cancellationToken, Symbol symbol)
        {
            var request = Requests.SymbolDetails(symbol);
            return GetAsyncResponse<SymbolDetailsResponse>(request, cancellationToken);
        }

        public Task<SymbolsResponse> SymbolsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50)
        {
            var request = Requests.Symbols(skip, limit);
            return GetAsyncResponse<SymbolsResponse>(request, cancellationToken);
        }

        public Task<ExchangesResponse> ExchangesAsync(
            CancellationToken cancellationToken, int skip = 0, int limit = 50)
        {
            var request = Requests.Exchanges(skip, limit);
            return GetAsyncResponse<ExchangesResponse>(request, cancellationToken);
        }

        public Task<ExchangeDetailsResponse> ExchangeDetailsAsync(CancellationToken cancellationToken, Exchange exchange)
        {
            var request = Requests.ExchangeDetails(exchange);
            return GetAsyncResponse<ExchangeDetailsResponse>(request, cancellationToken);
        }

        public Task<ExchangeRateResponse> ExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset)
        {
            var request = Requests.ExchangeRate(baseAsset, quoteAsset, timeStamp: null);
            return GetAsyncResponse<ExchangeRateResponse>(request, cancellationToken);
        }

        public Task<ExchangeRateResponse> ExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, DateTime timeStamp)
        {
            var request = Requests.ExchangeRate(baseAsset, quoteAsset, timeStamp);
            return GetAsyncResponse<ExchangeRateResponse>(request, cancellationToken);
        }

        public Task<ExchangeRatesResponse> ExchangeRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangeRates(baseAsset, null, skip, limit);
            return GetAsyncResponse<ExchangeRatesResponse>(request, cancellationToken);
        }

        public Task<ExchangeRatesResponse> ExchangeRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangeRates(baseAsset, timeStamp, skip, limit);
            return GetAsyncResponse<ExchangeRatesResponse>(request, cancellationToken);
        }

        public Task<CurrentRateInExchangeResponse> ExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, Exchange exchange)
        {
            var request = Requests.ExchangeRate(baseAsset, quoteAsset, exchange, null);
            return GetAsyncResponse<CurrentRateInExchangeResponse>(request, cancellationToken);
        }

        public Task<CurrentRateInExchangeResponse> ExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, Exchange exchange, DateTime timeStamp)
        {
            var request = Requests.ExchangeRate(baseAsset, quoteAsset, exchange, timeStamp);
            return GetAsyncResponse<CurrentRateInExchangeResponse>(request, cancellationToken);
        }

        public Task<CurrentRatesInExchangeResponse> ExchangeRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, Exchange exchange, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangeRates(baseAsset, exchange, null, skip, limit);
            return GetAsyncResponse<CurrentRatesInExchangeResponse>(request, cancellationToken);
        }

        public Task<CurrentRatesInExchangeResponse> ExchangeRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, Exchange exchange, DateTime timeStamp, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangeRates(baseAsset, exchange, timeStamp, skip, limit);
            return GetAsyncResponse<CurrentRatesInExchangeResponse>(request, cancellationToken);
        }

        public Task<PeriodsResponse> PeriodsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50)
        {
            var request = Requests.Periods(skip, limit);
            return GetAsyncResponse<PeriodsResponse>(request, cancellationToken);
        }

        public Task<LatestOhlcvResponse> LatestOhlcvAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, int limit = 50)
        {
            var request = Requests.LatestOhlcv(symbol, period, limit);
            return GetAsyncResponse<LatestOhlcvResponse>(request, cancellationToken);
        }

        public Task<HistoricalOhlcvResponse> HistoricalOhlcvAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, DateTime startPeriod, int limit = 50)
        {
            var request = Requests.HistoricalOhlcv(symbol, period, startPeriod, null, limit);
            return GetAsyncResponse<HistoricalOhlcvResponse>(request, cancellationToken);
        }

        public Task<HistoricalOhlcvResponse> HistoricalOhlcvAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, DateTime startPeriod, DateTime endPeriod, int limit = 50)
        {
            var request = Requests.HistoricalOhlcv(symbol, period, startPeriod, endPeriod, limit);
            return GetAsyncResponse<HistoricalOhlcvResponse>(request, cancellationToken);
        }

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

        public Task<OrderBookResponse> OrderBookAsync(CancellationToken cancellationToken,
            Exchange exchange, Asset baseAsset, Asset quoteAsset)
        {
            var request = Requests.OrderBook(exchange, baseAsset, quoteAsset);
            return GetAsyncResponse<OrderBookResponse>(request, cancellationToken);
        }
    }
}