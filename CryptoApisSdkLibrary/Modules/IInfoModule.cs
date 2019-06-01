using CryptoApisSdkLibrary.DataTypes;
using System;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.Modules
{
    public interface IInfoModule
    {
        IEnumerable<Exchange> GetAllExchanges(out string errorMessage, int skip = 0, int limit = 100);

        IEnumerable<Asset> GetAllAssets(out string errorMessage, int skip = 0, int limit = 100);

        IEnumerable<Symbol> GetAllSymbols(out string errorMessage, int skip = 0, int limit = 100);

        ExchangeRate GetExchangeRate(out string errorMessage, Asset baseAsset, Asset quoteAsset);
        ExchangeRate GetExchangeRate(out string errorMessage, Asset baseAsset, Asset quoteAsset, DateTime timeStamp);

        IEnumerable<ExchangeRate> GetCurrentRates(out string errorMessage, Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 100);

        IEnumerable<PeriodInfo> GetPeriodsInfo(out string errorMessage);

        IEnumerable<OHLCV> GetLatestData(out string errorMessage, Symbol symbol, Period period, int limit = 100);

        IEnumerable<OHLCV> GetHistoricalData(out string errorMessage, Symbol symbol, Period period, DateTime startPeriod, DateTime? endPeriod = null, int limit = 100);

        IEnumerable<Trade> GetAllLatestTrades(out string errorMessage, int limit = 100);

        IEnumerable<Trade> GetLatestTrades(out string errorMessage, Symbol symbol, int limit = 100);

        IEnumerable<Trade> GetHistoricalTrades(out string errorMessage, Symbol symbol);

        IEnumerable<Trade> GetHistoricalTrades(out string errorMessage, Symbol symbol, DateTime startPeriod);

        IEnumerable<Trade> GetHistoricalTrades(out string errorMessage, Symbol symbol, DateTime startPeriod, DateTime endPeriod);

        IEnumerable<QuoteTrade> GetAllLatestQuoteTrades(out string errorMessage, int limit = 100);

        IEnumerable<QuoteTrade> GetHistoricalQuoteTrades(out string errorMessage, Symbol symbol);

        IEnumerable<QuoteTrade> GetHistoricalQuoteTrades(out string errorMessage, Symbol symbol, DateTime startPeriod);

        IEnumerable<QuoteTrade> GetHistoricalQuoteTrades(out string errorMessage, Symbol symbol, DateTime startPeriod, DateTime endPeriod);
    }
}