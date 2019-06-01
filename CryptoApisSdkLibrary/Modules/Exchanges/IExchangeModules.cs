using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;

namespace CryptoApisSdkLibrary.Modules.Exchanges
{
    public interface IExchangeModules
    {
        /// <summary>
        /// Get detailed list of all supported exchanges provided by our system.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        GetAllExchangesResponse GetExchanges(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all associated assets.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        GetAllAssetsResponse GetAssets(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all symbol mappings.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported symbols.</returns>
        GetAllSymbolsResponse GetSymbols(int skip = 0, int limit = 50);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a current time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <returns>Response with exchange rates.</returns>
        GetExchangeRateResponse GetExchangeRate(Asset baseAsset, Asset quoteAsset);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <returns>Response with exchange rates.</returns>
        GetExchangeRateResponse GetExchangeRate(Asset baseAsset, Asset quoteAsset, DateTime timeStamp);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets at a current time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        GetAllCurrentRatesResponse GetCurrentRates(Asset baseAsset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets at a specific time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        GetAllCurrentRatesResponse GetCurrentRates(Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50);

        /// <summary>
        /// Get full list of, supported by us, time periods available for requesting OHLCV data.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with time-series periods.</returns>
        GetAllPeriodsResponse GetPeriods(int skip = 0, int limit = 50);

        /// <summary>
        /// Get OHLCV latest time-series data for requested symbol and period, returned in time descending order.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest time-series data.</returns>
        GetLatestDataResponse GetLatestData(Symbol symbol, Period period, int limit = 50);

        /// <summary>
        /// Get OHLCV time-series data for requested symbol and period. Returned in time ascending order.
        /// The data is returned to the end or when count of result elements reaches the limit.
        /// </summary>
        /// <param name="symbol">Symbol used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="startPeriod">Time period starting time.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical time-series data.</returns>
        GetHistoricalDataResponse GetHistoricalData(Symbol symbol, Period period, DateTime startPeriod, int limit = 50);

        /// <summary>
        /// Get OHLCV time-series data for requested symbol and period within the specified time interval. Returned in time ascending order.
        /// </summary>
        /// <param name="symbol">Symbol used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="startPeriod">Time period starting time.</param>
        /// <param name="endPeriod">Time period ending time</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical time-series data.</returns>
        GetHistoricalDataResponse GetHistoricalData(Symbol symbol, Period period, DateTime startPeriod, DateTime endPeriod, int limit = 50);

        /// <summary>
        /// Get latest trades from all symbols up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        GetAllLatestTradesResponse GetLatestTrades(int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific symbol up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        GetLatestTradesResponse GetLatestTrades(Symbol symbol, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific symbol, returned in time ascending order.
        /// Data results will be provided 24 hours back.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific symbol, returned in time ascending order.
        /// Data results will be start at specific time and finish at current time.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific symbol, returned in time ascending order.
        /// Data results will be start and finish at specific time.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="endPeriod">End of the requested period</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, DateTime startPeriod, DateTime endPeriod,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest quote updates for up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest quote trades.</returns>
        GetAllLatestQuoteTradesResponse GetLatestQuoteTrades(int limit = 50);

        /// <summary>
        /// Get historical quote updates within requested time range, returned in time ascending order.
        /// Data results will be provided 24 hours back.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical quote trades.</returns>
        GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(Symbol symbol, int skip = 0, int limit = 50);

        /// <summary>
        /// Get historical quote updates within requested time range, returned in time ascending order.
        /// Data results will be start at specific time and finish at current time.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical quote trades.</returns>
        GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get historical quote updates within requested time range, returned in time ascending order.
        /// Data results will be start and finish at specific time.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="endPeriod">End of the requested period</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical quote trades.</returns>
        GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(
            Symbol symbol, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest quote updates for up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with arbitrage info.</returns>
        GetArbitrageInfoResponse GetArbitrageInfo(int skip = 0, int limit = 50);
    }
}