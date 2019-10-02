using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;

namespace CryptoApisSdkLibrary.Modules.Exchanges
{
    internal partial class ExchangeModules
    {
        public GetAllExchangesMetaResponse GetExchangesMeta(int skip = 0, int limit = 50)
        {
            return GetExchangesMetaAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public GetExchangesSupportingAssetResponse GetExchangesSupportingAsset(string assetId, int skip = 0, int limit = 50)
        {
            return GetExchangesSupportingAssetAsync(CancellationToken.None, assetId, skip, limit).GetAwaiter().GetResult();
        }

        public GetExchangesSupportingPairsResponse GetExchangesSupportingPairs(string assetId1, string assetId2, int skip = 0, int limit = 50)
        {
            return GetExchangesSupportingPairsAsync(CancellationToken.None, assetId1, assetId2, skip, limit).GetAwaiter().GetResult();
        }

        public GetExchangesSupportingPairsResponse GetAllSymbolsInExchange(string exchangeId, int skip = 0, int limit = 50)
        {
            return GetAllSymbolsInExchangeAsync(CancellationToken.None, exchangeId, skip, limit).GetAwaiter().GetResult();
        }

        public GetAssetsMetaResponse GetAssetsMeta(int skip = 0, int limit = 50)
        {
            return GetAssetsMetaAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public GetAllAssetsResponse GetAssets(int skip = 0, int limit = 50)
        {
            return GetAssetsAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public GetAssetInfoResponse GetAssetInfo(string assetId)
        {
            return GetAssetInfoAsync(CancellationToken.None, assetId).GetAwaiter().GetResult();
        }

        public GetSymbolInfoResponse GetSymbolInfo(string symbolId)
        {
            return GetSymbolInfoAsync(CancellationToken.None, symbolId).GetAwaiter().GetResult();
        }

        public GetAllSymbolsResponse GetSymbols(int skip = 0, int limit = 50)
        {
            return GetSymbolsAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public GetAllExchangesResponse GetExchanges(int skip = 0, int limit = 50)
        {
            return GetExchangesAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public GetExchangeInfoResponse GetExchangeInfo(string exchangeId, int skip = 0, int limit = 50)
        {
            return GetExchangeInfoAsync(CancellationToken.None, exchangeId, skip, limit).GetAwaiter().GetResult();
        }

        public GetAllPeriodsResponse GetPeriods(int skip = 0, int limit = 50)
        {
            return GetPeriodsAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public GetExchangeRateResponse GetExchangeRate(Asset baseAsset, Asset quoteAsset)
        {
            return GetExchangeRateAsync(CancellationToken.None, baseAsset, quoteAsset).GetAwaiter().GetResult();
        }

        public GetExchangeRateResponse GetExchangeRate(
            Asset baseAsset, Asset quoteAsset, DateTime timeStamp)
        {
            return GetExchangeRateAsync(CancellationToken.None, baseAsset, quoteAsset, timeStamp).GetAwaiter().GetResult();
        }

        public GetAllCurrentRatesResponse GetCurrentRates(Asset baseAsset, int skip = 0, int limit = 50)
        {
            return GetCurrentRatesAsync(CancellationToken.None, baseAsset, skip, limit).GetAwaiter().GetResult();
        }

        public GetAllCurrentRatesResponse GetCurrentRates(Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50)
        {
            return GetCurrentRatesAsync(CancellationToken.None, baseAsset, timeStamp, skip, limit).GetAwaiter().GetResult();
        }

        public GetLatestDataResponse GetLatestData(Symbol symbol, Period period, int limit = 50)
        {
            return GetLatestDataAsync(CancellationToken.None, symbol, period, limit).GetAwaiter().GetResult();
        }

        public GetHistoricalDataResponse GetHistoricalData(Symbol symbol, Period period, DateTime startPeriod, int limit = 50)
        {
            return GetHistoricalDataAsync(CancellationToken.None, symbol, period, startPeriod, limit).GetAwaiter().GetResult();
        }

        public GetHistoricalDataResponse GetHistoricalData(Symbol symbol, Period period,
            DateTime startPeriod, DateTime endPeriod, int limit = 50)
        {
            return GetHistoricalDataAsync(CancellationToken.None, symbol, period, startPeriod, endPeriod, limit).GetAwaiter().GetResult();
        }

        public GetLatestTradesResponse GetLatestTrades(int skip = 0, int limit = 50)
        {
            return GetLatestTradesAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public GetLatestTradesResponse GetLatestTrades(Symbol symbol, int skip = 0, int limit = 50)
        {
            return GetLatestTradesAsync(CancellationToken.None, symbol, skip, limit).GetAwaiter().GetResult();
        }

        public GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, int skip = 0, int limit = 50)
        {
            return GetHistoricalTradesAsync(CancellationToken.None, symbol, skip, limit).GetAwaiter().GetResult();
        }

        public GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            return GetHistoricalTradesAsync(CancellationToken.None, symbol, startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, DateTime startPeriod, DateTime endPeriod,
            int skip = 0, int limit = 50)
        {
            return GetHistoricalTradesAsync(CancellationToken.None, symbol, startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public GetAllLatestQuoteTradesResponse GetLatestQuoteTrades(int limit = 50)
        {
            return GetLatestQuoteTradesAsync(CancellationToken.None, limit).GetAwaiter().GetResult();
        }

        public GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(Symbol symbol, int skip = 0, int limit = 50)
        {
            return GetHistoricalQuoteTradesAsync(CancellationToken.None, symbol, skip, limit).GetAwaiter().GetResult();
        }

        public GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(
            Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            return GetHistoricalQuoteTradesAsync(CancellationToken.None, symbol, startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(
            Symbol symbol, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50)
        {
            return GetHistoricalQuoteTradesAsync(CancellationToken.None, symbol, startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public GetArbitrageInfoResponse GetArbitrageInfo(int skip = 0, int limit = 50)
        {
            return GetArbitrageInfoAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }
    }
}