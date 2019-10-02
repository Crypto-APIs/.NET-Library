using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Exchanges
{
    internal partial class ExchangeModules
    {
        public Task<GetAllExchangesMetaResponse> GetExchangesMetaAsync(CancellationToken cancellationToken, int skip = 0, int limit = 50)
        {
            var request = Requests.GetExchangesMeta(skip, limit);
            return GetAsyncResponse<GetAllExchangesMetaResponse>(request, cancellationToken);
        }

        public Task<GetExchangesSupportingPairsResponse> GetExchangesSupportingPairsAsync(CancellationToken cancellationToken,
            string assetId1, string assetId2, int skip = 0, int limit = 50)
        {
            var request = Requests.GetExchangesSupportingPairs(assetId1, assetId2, skip, limit);
            return GetAsyncResponse<GetExchangesSupportingPairsResponse>(request, cancellationToken);
        }

        public Task<GetExchangesSupportingPairsResponse> GetAllSymbolsInExchangeAsync(CancellationToken cancellationToken,
            string exchangeId, int skip = 0, int limit = 50)
        {
            var request = Requests.GetAllSymbolsInExchange(exchangeId, skip, limit);
            return GetAsyncResponse<GetExchangesSupportingPairsResponse>(request, cancellationToken);
        }

        public Task<GetAssetsMetaResponse> GetAssetsMetaAsync(CancellationToken cancellationToken, int skip = 0, int limit = 50)
        {
            var request = Requests.GetAssetsMeta(skip, limit);
            return GetAsyncResponse<GetAssetsMetaResponse>(request, cancellationToken);
        }


        public Task<GetExchangesSupportingAssetResponse> GetExchangesSupportingAssetAsync(CancellationToken cancellationToken,
            string assetId, int skip = 0, int limit = 50)
        {
            var request = Requests.GetExchangesSupportingAsset(assetId, skip, limit);
            return GetAsyncResponse<GetExchangesSupportingAssetResponse>(request, cancellationToken);
        }

        public Task<GetAllAssetsResponse> GetAssetsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50)
        {
            var request = Requests.GetAssets(skip, limit);
            return GetAsyncResponse<GetAllAssetsResponse>(request, cancellationToken);
        }

        public Task<GetAssetInfoResponse> GetAssetInfoAsync(CancellationToken cancellationToken, string assetId)
        {
            var request = Requests.GetAssetInfo(assetId);
            return GetAsyncResponse<GetAssetInfoResponse>(request, cancellationToken);
        }

        public Task<GetSymbolInfoResponse> GetSymbolInfoAsync(CancellationToken cancellationToken, string symbolId)
        {
            var request = Requests.GetSymbolInfo(symbolId);
            return GetAsyncResponse<GetSymbolInfoResponse>(request, cancellationToken);
        }

        public Task<GetAllSymbolsResponse> GetSymbolsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50)
        {
            var request = Requests.GetSymbols(skip, limit);
            return GetAsyncResponse<GetAllSymbolsResponse>(request, cancellationToken);
        }

        public Task<GetAllExchangesResponse> GetExchangesAsync(
            CancellationToken cancellationToken, int skip = 0, int limit = 50)
        {
            var request = Requests.GetExchanges(skip, limit);
            return GetAsyncResponse<GetAllExchangesResponse>(request, cancellationToken);
        }

        public Task<GetExchangeInfoResponse> GetExchangeInfoAsync(CancellationToken cancellationToken, string exchangeId, int skip = 0, int limit = 50)
        {
            var request = Requests.GetExchangeInfo(exchangeId, skip, limit);
            return GetAsyncResponse<GetExchangeInfoResponse>(request, cancellationToken);
        }

        public Task<GetExchangeRateResponse> GetExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset)
        {
            var request = Requests.GetExchangeRate(baseAsset, quoteAsset, timeStamp: null);
            return GetAsyncResponse<GetExchangeRateResponse>(request, cancellationToken);
        }

        public Task<GetExchangeRateResponse> GetExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, DateTime timeStamp)
        {
            var request = Requests.GetExchangeRate(baseAsset, quoteAsset, timeStamp);
            return GetAsyncResponse<GetExchangeRateResponse>(request, cancellationToken);
        }

        public Task<GetAllCurrentRatesResponse> GetCurrentRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, int skip = 0, int limit = 50)
        {
            var request = Requests.GetCurrentRates(baseAsset, null, skip, limit);
            return GetAsyncResponse<GetAllCurrentRatesResponse>(request, cancellationToken);
        }

        public Task<GetAllCurrentRatesResponse> GetCurrentRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50)
        {
            var request = Requests.GetCurrentRates(baseAsset, timeStamp, skip, limit);
            return GetAsyncResponse<GetAllCurrentRatesResponse>(request, cancellationToken);
        }

        public Task<GetAllPeriodsResponse> GetPeriodsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50)
        {
            var request = Requests.GetSymbols(skip, limit);
            return GetAsyncResponse<GetAllPeriodsResponse>(request, cancellationToken);
        }

        public Task<GetLatestDataResponse> GetLatestDataAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, int limit = 50)
        {
            var request = Requests.GetLatestData(symbol, period, limit);
            return GetAsyncResponse<GetLatestDataResponse>(request, cancellationToken);
        }

        public Task<GetHistoricalDataResponse> GetHistoricalDataAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, DateTime startPeriod, int limit = 50)
        {
            var request = Requests.GetHistoricalData(symbol, period, startPeriod, null, limit);
            return GetAsyncResponse<GetHistoricalDataResponse>(request, cancellationToken);
        }

        public Task<GetHistoricalDataResponse> GetHistoricalDataAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, DateTime startPeriod, DateTime endPeriod, int limit = 50)
        {
            var request = Requests.GetHistoricalData(symbol, period, startPeriod, endPeriod, limit);
            return GetAsyncResponse<GetHistoricalDataResponse>(request, cancellationToken);
        }

        public Task<GetLatestTradesResponse> GetLatestTradesAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50)
        {
            var request = Requests.GetLatestTrades(skip, limit);
            return GetAsyncResponse<GetLatestTradesResponse>(request, cancellationToken);
        }

        public Task<GetLatestTradesResponse> GetLatestTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, int skip = 0, int limit = 50)
        {
            var request = Requests.GetLatestTrades(symbol, skip, limit);
            return GetAsyncResponse<GetLatestTradesResponse>(request, cancellationToken);
        }

        public Task<GetHistoricalTradesResponse> GetHistoricalTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, int skip = 0, int limit = 50)
        {
            var request = Requests.GetHistoricalTrades(
                symbol, skip, limit, startPeriod: null, endPeriod: null);
            return GetAsyncResponse<GetHistoricalTradesResponse>(request, cancellationToken);
        }

        public Task<GetHistoricalTradesResponse> GetHistoricalTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.GetHistoricalTrades(
                symbol, skip, limit, startPeriod, endPeriod: null);
            return GetAsyncResponse<GetHistoricalTradesResponse>(request, cancellationToken);
        }

        public Task<GetHistoricalTradesResponse> GetHistoricalTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.GetHistoricalTrades(symbol, skip, limit, startPeriod, endPeriod);
            return GetAsyncResponse<GetHistoricalTradesResponse>(request, cancellationToken);
        }

        public Task<GetAllLatestQuoteTradesResponse> GetLatestQuoteTradesAsync(CancellationToken cancellationToken,
            int limit = 50)
        {
            var request = Requests.GetLatestQuoteTrades(limit);
            return GetAsyncResponse<GetAllLatestQuoteTradesResponse>(request, cancellationToken);
        }

        public Task<GetHistoricalQuoteTradesResponse> GetHistoricalQuoteTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, int skip = 0, int limit = 50)
        {
            var request = Requests.GetHistoricalQuoteTrades(
                symbol, skip, limit, startPeriod: null, endPeriod: null);
            return GetAsyncResponse<GetHistoricalQuoteTradesResponse>(request, cancellationToken);
        }

        public Task<GetHistoricalQuoteTradesResponse> GetHistoricalQuoteTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.GetHistoricalQuoteTrades(symbol, skip, limit, startPeriod, endPeriod: null);
            return GetAsyncResponse<GetHistoricalQuoteTradesResponse>(request, cancellationToken);
        }

        public Task<GetHistoricalQuoteTradesResponse> GetHistoricalQuoteTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.GetHistoricalQuoteTrades(symbol, skip, limit, startPeriod, endPeriod);
            return GetAsyncResponse<GetHistoricalQuoteTradesResponse>(request, cancellationToken);
        }

        public Task<GetArbitrageInfoResponse> GetArbitrageInfoAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50)
        {
            var request = Requests.GetArbitrageInfo(skip, limit);
            return GetAsyncResponse<GetArbitrageInfoResponse>(request, cancellationToken);
        }
    }
}