using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Exchanges
{
    internal partial class ExchangeModules
    {
        public Task<GetAllExchangesResponse> GetExchangesAsync(
            CancellationToken cancellationToken, int skip = 0, int limit = 50)
        {
            var request = Requests.GetExchanges(skip, limit);
            return GetAsyncResponse<GetAllExchangesResponse>(request, cancellationToken);
        }

        public Task<GetAllAssetsResponse> GetAssetsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50)
        {
            var request = Requests.GetAssets(skip, limit);
            return GetAsyncResponse<GetAllAssetsResponse>(request, cancellationToken);
        }

        public Task<GetAllSymbolsResponse> GetSymbolsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50)
        {
            var request = Requests.GetSymbols(skip, limit);
            return GetAsyncResponse<GetAllSymbolsResponse>(request, cancellationToken);
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