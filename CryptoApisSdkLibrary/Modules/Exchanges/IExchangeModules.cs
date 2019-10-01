using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;
using System.Threading.Tasks;

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
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-exchanges-base-data"/>
        GetAllExchangesMetaResponse GetExchangesMeta(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all supported exchanges provided by our system.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-exchanges-base-data"/>
        Task<GetAllExchangesMetaResponse> GetExchangesMetaAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of exchanges and symbols which support the given assets as base/quote or quote/base.
        /// </summary>
        /// <param name="assetId">Our identifier (UID) of the asset.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-exchanges-by-supporting-assets"/>
        GetExchangesSupportingAssetResponse GetExchangesSupportingAsset(string assetId, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of exchanges and symbols which support the given assets as base/quote or quote/base.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="assetId">Our identifier (UID) of the asset.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-exchanges-by-supporting-assets"/>
        Task<GetExchangesSupportingAssetResponse> GetExchangesSupportingAssetAsync(CancellationToken cancellationToken,
            string assetId, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of exchanges and symbols which support the given assets as base/quote or quote/base.
        /// </summary>
        /// <param name="assetId1">Our identifier (UID) of the asset 1.</param>
        /// <param name="assetId2">Our identifier (UID) of the asset 2.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-exchanges-by-supporting-pairs"/>
        GetExchangesSupportingPairsResponse GetExchangesSupportingPairs(string assetId1, string assetId2, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of exchanges and symbols which support the given assets as base/quote or quote/base.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="assetId1">Our identifier (UID) of the asset 1.</param>
        /// <param name="assetId2">Our identifier (UID) of the asset 2.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-exchanges-by-supporting-pairs"/>
        Task<GetExchangesSupportingPairsResponse> GetExchangesSupportingPairsAsync(CancellationToken cancellationToken,
            string assetId1, string assetId2, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of symbols which are supported in the given exchange..
        /// </summary>
        /// <param name="exchangeId">Our identifier (UID) of the exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-symbols-supported-in-exchange"/>
        GetExchangesSupportingPairsResponse GetAllSymbolsInExchange(string exchangeId, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of symbols which are supported in the given exchange.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchangeId">Our identifier (UID) of the exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-symbols-supported-in-exchange"/>
        Task<GetExchangesSupportingPairsResponse> GetAllSymbolsInExchangeAsync(CancellationToken cancellationToken,
            string exchangeId, int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all associated assets.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-assets"/>
        GetAllAssetsResponse GetAssets(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all associated assets.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-assets"/>
        Task<GetAllAssetsResponse> GetAssetsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all symbol mappings.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported symbols.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-symbols"/>
        GetAllSymbolsResponse GetSymbols(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all symbol mappings.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported symbols.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-symbols"/>
        Task<GetAllSymbolsResponse> GetSymbolsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all supported exchanges provided by our system.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-exchanges-base-data"/>
        GetAllExchangesResponse GetExchanges(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all supported exchanges provided by our system.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-exchanges-base-data"/>
        Task<GetAllExchangesResponse> GetExchangesAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get a detailed information for a single supported exchange provided by our system by ID.
        /// </summary>
        /// <param name="exchangeId">Our identifier (UID) of the exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-exchange-details"/>
        GetExchangeInfoResponse GetExchangeInfo(string exchangeId, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a detailed information for a single supported exchange provided by our system by ID.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchangeId">Our identifier (UID) of the exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-exchange-details"/>
        Task<GetExchangeInfoResponse> GetExchangeInfo(CancellationToken cancellationToken,
            string exchangeId, int skip = 0, int limit = 50);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a current time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <returns>Response with exchange rates.</returns>
        /// <see cref=""/>
        GetExchangeRateResponse GetExchangeRate(Asset baseAsset, Asset quoteAsset);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a current time.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <returns>Response with exchange rates.</returns>
        /// <see cref=""/>
        Task<GetExchangeRateResponse> GetExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <returns>Response with exchange rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate"/>
        GetExchangeRateResponse GetExchangeRate(Asset baseAsset, Asset quoteAsset, DateTime timeStamp);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific time.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <returns>Response with exchange rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate"/>
        Task<GetExchangeRateResponse> GetExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, DateTime timeStamp);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets at a current time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates"/>
        GetAllCurrentRatesResponse GetCurrentRates(Asset baseAsset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets at a current time.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates"/>
        Task<GetAllCurrentRatesResponse> GetCurrentRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets at a specific time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates"/>
        GetAllCurrentRatesResponse GetCurrentRates(Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets at a specific time.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates"/>
        Task<GetAllCurrentRatesResponse> GetCurrentRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50);

        /// <summary>
        /// Get full list of, supported by us, time periods available for requesting OHLCV data.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with time-series periods.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-periods"/>
        GetAllPeriodsResponse GetPeriods(int skip = 0, int limit = 50);

        /// <summary>
        /// Get full list of, supported by us, time periods available for requesting OHLCV data.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with time-series periods.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-periods"/>
        Task<GetAllPeriodsResponse> GetPeriodsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get OHLCV latest time-series data for requested symbol and period, returned in time descending order.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest time-series data.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#latest-data"/>
        GetLatestDataResponse GetLatestData(Symbol symbol, Period period, int limit = 50);

        /// <summary>
        /// Get OHLCV latest time-series data for requested symbol and period, returned in time descending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest time-series data.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#latest-data"/>
        Task<GetLatestDataResponse> GetLatestDataAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, int limit = 50);

        /// <summary>
        /// Get OHLCV time-series data for requested symbol and period. Returned in time ascending order.
        /// The data is returned to the end or when count of result elements reaches the limit.
        /// </summary>
        /// <param name="symbol">Symbol used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="startPeriod">Time period starting time.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical time-series data.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#historical-data"/>
        GetHistoricalDataResponse GetHistoricalData(Symbol symbol, Period period, DateTime startPeriod, int limit = 50);

        /// <summary>
        /// Get OHLCV time-series data for requested symbol and period. Returned in time ascending order.
        /// The data is returned to the end or when count of result elements reaches the limit.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="startPeriod">Time period starting time.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical time-series data.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#historical-data"/>
        Task<GetHistoricalDataResponse> GetHistoricalDataAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, DateTime startPeriod, int limit = 50);

        /// <summary>
        /// Get OHLCV time-series data for requested symbol and period within the specified time interval. Returned in time ascending order.
        /// </summary>
        /// <param name="symbol">Symbol used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="startPeriod">Time period starting time.</param>
        /// <param name="endPeriod">Time period ending time</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical time-series data.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#historical-data"/>
        GetHistoricalDataResponse GetHistoricalData(Symbol symbol, Period period, DateTime startPeriod, DateTime endPeriod, int limit = 50);

        /// <summary>
        /// Get OHLCV time-series data for requested symbol and period within the specified time interval. Returned in time ascending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="startPeriod">Time period starting time.</param>
        /// <param name="endPeriod">Time period ending time</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical time-series data.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#historical-data"/>
        Task<GetHistoricalDataResponse> GetHistoricalDataAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, DateTime startPeriod, DateTime endPeriod, int limit = 50);

        /// <summary>
        /// Get latest trades from all symbols up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref=""/>
        GetLatestTradesResponse GetLatestTrades(int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from all symbols up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref=""/>
        Task<GetLatestTradesResponse> GetLatestTradesAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific symbol up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data"/>
        GetLatestTradesResponse GetLatestTrades(Symbol symbol, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific symbol up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data"/>
        Task<GetLatestTradesResponse> GetLatestTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific symbol, returned in time ascending order.
        /// Data results will be provided 24 hours back.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data"/>
        GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific symbol, returned in time ascending order.
        /// Data results will be provided 24 hours back.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data"/>
        Task<GetHistoricalTradesResponse> GetHistoricalTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific symbol, returned in time ascending order.
        /// Data results will be start at specific time and finish at current time.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data"/>
        GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific symbol, returned in time ascending order.
        /// Data results will be start at specific time and finish at current time.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data"/>
        Task<GetHistoricalTradesResponse> GetHistoricalTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50);

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
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data"/>
        GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, DateTime startPeriod, DateTime endPeriod,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific symbol, returned in time ascending order.
        /// Data results will be start and finish at specific time.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="endPeriod">End of the requested period</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data"/>
        Task<GetHistoricalTradesResponse> GetHistoricalTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest quote updates for up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest quote trades.</returns>
        /// <see cref=""/>
        GetAllLatestQuoteTradesResponse GetLatestQuoteTrades(int limit = 50);

        /// <summary>
        /// Get latest quote updates for up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest quote trades.</returns>
        /// <see cref=""/>
        Task<GetAllLatestQuoteTradesResponse> GetLatestQuoteTradesAsync(CancellationToken cancellationToken,
            int limit = 50);

        /// <summary>
        /// Get historical quote updates within requested time range, returned in time ascending order.
        /// Data results will be provided 24 hours back.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical quote trades.</returns>
        /// <see cref=""/>
        GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(Symbol symbol, int skip = 0, int limit = 50);

        /// <summary>
        /// Get historical quote updates within requested time range, returned in time ascending order.
        /// Data results will be provided 24 hours back.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical quote trades.</returns>
        /// <see cref=""/>
        Task<GetHistoricalQuoteTradesResponse> GetHistoricalQuoteTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, int skip = 0, int limit = 50);

        /// <summary>
        /// Get historical quote updates within requested time range, returned in time ascending order.
        /// Data results will be start at specific time and finish at current time.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical quote trades.</returns>
        /// <see cref=""/>
        GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get historical quote updates within requested time range, returned in time ascending order.
        /// Data results will be start at specific time and finish at current time.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical quote trades.</returns>
        /// <see cref=""/>
        Task<GetHistoricalQuoteTradesResponse> GetHistoricalQuoteTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50);

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
        /// <see cref=""/>
        GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(
            Symbol symbol, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get historical quote updates within requested time range, returned in time ascending order.
        /// Data results will be start and finish at specific time.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="endPeriod">End of the requested period</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical quote trades.</returns>
        /// <see cref=""/>
        Task<GetHistoricalQuoteTradesResponse> GetHistoricalQuoteTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest quote updates for up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with arbitrage info.</returns>
        /// <see cref=""/>
        GetArbitrageInfoResponse GetArbitrageInfo(int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest quote updates for up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with arbitrage info.</returns>
        /// <see cref=""/>
        Task<GetArbitrageInfoResponse> GetArbitrageInfoAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);
    }
}