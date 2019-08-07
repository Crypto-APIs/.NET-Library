using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;

namespace CryptoApisSdkLibrary.Modules.Exchanges
{
    internal partial class ExchangeModules
    {
        public GetAllExchangesResponse GetExchanges(int skip = 0, int limit = 50)
        {
            var request = Requests.GetExchanges(skip, limit);
            return GetSync<GetAllExchangesResponse>(request);
        }

        public GetAllAssetsResponse GetAssets(int skip = 0, int limit = 50)
        {
            var request = Requests.GetAssets(skip, limit);
            return GetSync<GetAllAssetsResponse>(request);
        }

        public GetAllSymbolsResponse GetSymbols(int skip = 0, int limit = 50)
        {
            var request = Requests.GetSymbols(skip, limit);
            return GetSync<GetAllSymbolsResponse>(request);
        }

        public GetAllPeriodsResponse GetPeriods(int skip = 0, int limit = 50)
        {
            var request = Requests.GetPeriods(skip, limit);
            return GetSync<GetAllPeriodsResponse>(request);
        }

        public GetExchangeRateResponse GetExchangeRate(Asset baseAsset, Asset quoteAsset)
        {
            var request = Requests.GetExchangeRate(baseAsset, quoteAsset, timeStamp: null);
            return GetSync<GetExchangeRateResponse>(request);
        }

        public GetExchangeRateResponse GetExchangeRate(
            Asset baseAsset, Asset quoteAsset, DateTime timeStamp)
        {
            var request = Requests.GetExchangeRate(baseAsset, quoteAsset, timeStamp);
            return GetSync<GetExchangeRateResponse>(request);
        }

        public GetAllCurrentRatesResponse GetCurrentRates(Asset baseAsset, int skip = 0, int limit = 50)
        {
            var request = Requests.GetCurrentRates(baseAsset, null, skip, limit);
            return GetSync<GetAllCurrentRatesResponse>(request);
        }

        public GetAllCurrentRatesResponse GetCurrentRates(Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50)
        {
            var request = Requests.GetCurrentRates(baseAsset, timeStamp, skip, limit);
            return GetSync<GetAllCurrentRatesResponse>(request);
        }

        public GetLatestDataResponse GetLatestData(Symbol symbol, Period period, int limit = 50)
        {
            var request = Requests.GetLatestData(symbol, period, limit);
            return GetSync<GetLatestDataResponse>(request);
        }

        public GetHistoricalDataResponse GetHistoricalData(Symbol symbol, Period period, DateTime startPeriod, int limit = 50)
        {
            var request = Requests.GetHistoricalData(symbol, period, startPeriod, null, limit);
            return GetSync<GetHistoricalDataResponse>(request);
        }

        public GetHistoricalDataResponse GetHistoricalData(Symbol symbol, Period period,
            DateTime startPeriod, DateTime endPeriod, int limit = 50)
        {
            var request = Requests.GetHistoricalData(symbol, period, startPeriod, endPeriod, limit);
            return GetSync<GetHistoricalDataResponse>(request);
        }

        public GetLatestTradesResponse GetLatestTrades(int skip = 0, int limit = 50)
        {
            var request = Requests.GetLatestTrades(skip, limit);
            return GetSync<GetLatestTradesResponse>(request);
        }

        public GetLatestTradesResponse GetLatestTrades(Symbol symbol, int skip = 0, int limit = 50)
        {
            var request = Requests.GetLatestTrades(symbol, skip, limit);
            return GetSync<GetLatestTradesResponse>(request);
        }

        public GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, int skip = 0, int limit = 50)
        {
            var request = Requests.GetHistoricalTrades(symbol, skip, limit, startPeriod: null, endPeriod: null);
            return GetSync<GetHistoricalTradesResponse>(request);
        }

        public GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.GetHistoricalTrades(symbol, skip, limit, startPeriod, endPeriod: null);
            return GetSync<GetHistoricalTradesResponse>(request);
        }

        public GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, DateTime startPeriod, DateTime endPeriod,
            int skip = 0, int limit = 50)
        {
            var request = Requests.GetHistoricalTrades(symbol, skip, limit, startPeriod, endPeriod);
            return GetSync<GetHistoricalTradesResponse>(request);
        }

        public GetAllLatestQuoteTradesResponse GetLatestQuoteTrades(int limit = 50)
        {
            var request = Requests.GetLatestQuoteTrades(limit);
            return GetSync<GetAllLatestQuoteTradesResponse>(request);
        }

        public GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(Symbol symbol, int skip = 0, int limit = 50)
        {
            var request = Requests.GetHistoricalQuoteTrades(symbol, skip, limit, startPeriod: null, endPeriod: null);
            return GetSync<GetHistoricalQuoteTradesResponse>(request);
        }

        public GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(
            Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.GetHistoricalQuoteTrades(symbol, skip, limit, startPeriod, endPeriod: null);
            return GetSync<GetHistoricalQuoteTradesResponse>(request);
        }

        public GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(
            Symbol symbol, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.GetHistoricalQuoteTrades(symbol, skip, limit, startPeriod, endPeriod);
            return GetSync<GetHistoricalQuoteTradesResponse>(request);
        }

        public GetArbitrageInfoResponse GetArbitrageInfo(int skip = 0, int limit = 50)
        {
            var request = Requests.GetArbitrageInfo(skip, limit);
            return GetSync<GetArbitrageInfoResponse>(request);
        }
    }
}