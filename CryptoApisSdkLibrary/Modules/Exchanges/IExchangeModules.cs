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
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-exchanges"/>
        ExchangesMetaResponse ExchangesMeta(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all supported exchanges provided by our system.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-exchanges"/>
        Task<ExchangesMetaResponse> ExchangesMetaAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of exchanges and symbols which support the given assets as base/quote or quote/base.
        /// </summary>
        /// <param name="asset">Asset.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with exchange collection by supporting assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-exchanges-by-supporting-assets"/>
        ExchangesSupportingAssetResponse ExchangesSupportingAsset(Asset asset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of exchanges and symbols which support the given assets as base/quote or quote/base.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="asset">Asset.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with exchange collection by supporting assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-exchanges-by-supporting-assets"/>
        Task<ExchangesSupportingAssetResponse> ExchangesSupportingAssetAsync(CancellationToken cancellationToken,
            Asset asset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of exchanges and symbols which support the given assets as base/quote or quote/base.
        /// </summary>
        /// <param name="asset1">First asset.</param>
        /// <param name="asset2">Second asset.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with exchange collection by supporting pairs.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-exchanges-by-supporting-pairs"/>
        ExchangesAssetsResponse ExchangesSupportingPairs(Asset asset1, Asset asset2, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of exchanges and symbols which support the given assets as base/quote or quote/base.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="asset1">First asset.</param>
        /// <param name="asset2">Second asset.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with exchange collection by supporting pairs.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-exchanges-by-supporting-pairs"/>
        Task<ExchangesAssetsResponse> ExchangesSupportingPairsAsync(CancellationToken cancellationToken,
            Asset asset1, Asset asset2, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of symbols which are supported in the given exchange..
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with symbol collection by supporting exchange.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-symbols-supported-in-exchange"/>
        ExchangesAssetsResponse SymbolsInExchange(Exchange exchange, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of symbols which are supported in the given exchange.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with symbol collection by supporting exchange.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-symbols-supported-in-exchange"/>
        Task<ExchangesAssetsResponse> SymbolsInExchangeAsync(CancellationToken cancellationToken,
            Exchange exchange, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of all associated assets.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-assets"/>
        AssetsMetaResponse AssetsMeta(int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of all associated assets.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-assets"/>
        Task<AssetsMetaResponse> AssetsMetaAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all symbol mappings.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported symbols.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-symbols"/>
        SymbolsResponse Symbols(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all symbol mappings.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported symbols.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-symbols"/>
        Task<SymbolsResponse> SymbolsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all supported exchanges provided by our system.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-exchanges-base-data"/>
        ExchangesResponse Exchanges(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all supported exchanges provided by our system.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-exchanges-base-data"/>
        Task<ExchangesResponse> ExchangesAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get a detailed information for a single supported exchange provided by our system by ID.
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-exchange-details"/>
        ExchangeDetailsResponse ExchangeDetails(Exchange exchange);

        /// <summary>
        /// Get a detailed information for a single supported exchange provided by our system by ID.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-exchange-details"/>
        Task<ExchangeDetailsResponse> ExchangeDetailsAsync(CancellationToken cancellationToken, Exchange exchange);

        /// <summary>
        /// Get detailed list of all associated assets.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-assets-base-data"/>
        AssetsResponse Assets(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all associated assets.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-assets-base-data"/>
        Task<AssetsResponse> AssetsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed information for a specific asset.
        /// </summary>
        /// <param name="asset">Asset.</param>
        /// <returns>Response with details of asset.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-asset-details"/>
        AssetDetailsResponse AssetDetails(Asset asset);

        /// <summary>
        /// Get detailed information for a specific asset.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="asset">Asset.</param>
        /// <returns>Response with details of asset.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-asset-details"/>
        Task<AssetDetailsResponse> AssetDetailsAsync(CancellationToken cancellationToken, Asset asset);

        /// <summary>
        /// Get detailed information for a specific asset.
        /// </summary>
        /// <param name="symbol">Symbol.</param>
        /// <returns>Response with details of symbol.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-asset-details"/>
        SymbolDetailsResponse SymbolDetails(Symbol symbol);

        /// <summary>
        /// Get detailed information for a specific asset.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol.</param>
        /// <returns>Response with details of symbol.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-asset-details"/>
        Task<SymbolDetailsResponse> SymbolDetailsAsync(CancellationToken cancellationToken, Symbol symbol);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a current time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <returns>Response with exchange rate.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate"/>
        ExchangeRateResponse ExchangeRate(Asset baseAsset, Asset quoteAsset);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a current time.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <returns>Response with exchange rate.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate"/>
        Task<ExchangeRateResponse> ExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <returns>Response with exchange rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate"/>
        ExchangeRateResponse ExchangeRate(Asset baseAsset, Asset quoteAsset, DateTime timeStamp);

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
        Task<ExchangeRateResponse> ExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, DateTime timeStamp);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets at a current time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates"/>
        ExchangeRatesResponse ExchangeRates(Asset baseAsset, int skip = 0, int limit = 50);

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
        Task<ExchangeRatesResponse> ExchangeRatesAsync(CancellationToken cancellationToken,
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
        ExchangeRatesResponse ExchangeRates(Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50);

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
        Task<ExchangeRatesResponse> ExchangeRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific or current time in a specific Exchange.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <returns>Response with current rate.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate-in-a-specific-exchange"/>
        CurrentRateInExchangeResponse ExchangeRate(Asset baseAsset, Asset quoteAsset, Exchange exchange);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific or current time in a specific Exchange.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <returns>Response with current rate.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate-in-a-specific-exchange"/>
        Task<CurrentRateInExchangeResponse> ExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, Exchange exchange);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific or current time in a specific Exchange.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <returns>Response with current rate.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate-in-a-specific-exchange"/>
        CurrentRateInExchangeResponse ExchangeRate(Asset baseAsset, Asset quoteAsset, Exchange exchange, DateTime timeStamp);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific or current time in a specific Exchange.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <returns>Response with current rate.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate-in-a-specific-exchange"/>
        Task<CurrentRateInExchangeResponse> ExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, Exchange exchange, DateTime timeStamp);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets in a specific Exchange.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates-in-a-specific-exchange"/>
        CurrentRatesInExchangeResponse ExchangeRates(Asset baseAsset, Exchange exchange, int skip = 0, int limit = 50);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets in a specific Exchange.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates-in-a-specific-exchange"/>
        Task<CurrentRatesInExchangeResponse> ExchangeRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, Exchange exchange, int skip = 0, int limit = 50);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets in a specific Exchange.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates-in-a-specific-exchange"/>
        CurrentRatesInExchangeResponse ExchangeRates(Asset baseAsset, Exchange exchange, DateTime timeStamp, int skip = 0, int limit = 50);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets in a specific Exchange.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates-in-a-specific-exchange"/>
        Task<CurrentRatesInExchangeResponse> ExchangeRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, Exchange exchange, DateTime timeStamp, int skip = 0, int limit = 50);

        /// <summary>
        /// Get full list of, supported by us, time periods available for requesting OHLCV data.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with time-series periods.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-periods"/>
        PeriodsResponse Periods(int skip = 0, int limit = 50);

        /// <summary>
        /// Get full list of, supported by us, time periods available for requesting OHLCV data.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with time-series periods.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-periods"/>
        Task<PeriodsResponse> PeriodsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get OHLCV latest time-series data for requested symbol and period, returned in time descending order.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest time-series data.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#latest-data"/>
        LatestOhlcvResponse LatestOhlcv(Symbol symbol, Period period, int limit = 50);

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
        Task<LatestOhlcvResponse> LatestOhlcvAsync(CancellationToken cancellationToken,
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
        HistoricalOhlcvResponse HistoricalOhlcv(Symbol symbol, Period period, DateTime startPeriod, int limit = 50);

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
        Task<HistoricalOhlcvResponse> HistoricalOhlcvAsync(CancellationToken cancellationToken,
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
        HistoricalOhlcvResponse HistoricalOhlcv(Symbol symbol, Period period, DateTime startPeriod, DateTime endPeriod, int limit = 50);

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
        Task<HistoricalOhlcvResponse> HistoricalOhlcvAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, DateTime startPeriod, DateTime endPeriod, int limit = 50);

        /// <summary>
        /// Get latest trades from all symbols up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data"/>
        LatestTradesResponse LatestTrades(int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from all symbols up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data"/>
        Task<LatestTradesResponse> LatestTradesAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific symbol up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data-by-symbol"/>
        LatestTradesResponse LatestTrades(Symbol symbol, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific symbol up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data-by-symbol"/>
        Task<LatestTradesResponse> LatestTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific exchange up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data-by-exchange"/>
        LatestTradesResponse LatestTrades(Exchange exchange, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific exchange up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data-by-exchange"/>
        Task<LatestTradesResponse> LatestTradesAsync(CancellationToken cancellationToken,
            Exchange exchange, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific base asset up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data-by-base-asset"/>
        LatestTradesResponse LatestTrades(Asset baseAsset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific base asset up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data-by-base-asset"/>
        Task<LatestTradesResponse> LatestTradesAsync(CancellationToken cancellationToken,
            Asset baseAsset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific assets pair (exp. BTC / USD) up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data-by-pair"/>
        LatestTradesResponse LatestTrades(Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific assets pair (exp. BTC / USD) up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data-by-pair"/>
        Task<LatestTradesResponse> LatestTradesAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific assets pair (exp. BTC / USD) in a specific exchange up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data-by-exchange-pair"/>
        LatestTradesResponse LatestTrades(Exchange exchange, Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific assets pair (exp. BTC / USD) in a specific exchange up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data-by-exchange-pair"/>
        Task<LatestTradesResponse> LatestTradesAsync(CancellationToken cancellationToken,
            Exchange exchange, Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific symbol, returned in time ascending order.
        /// Data results will be provided 24 hours back.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data"/>
        HistoricalTradesResponse HistoricalTrades(Symbol symbol, int skip = 0, int limit = 50);

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
        Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
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
        HistoricalTradesResponse HistoricalTrades(Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50);

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
        Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
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
        HistoricalTradesResponse HistoricalTrades(Symbol symbol, DateTime startPeriod, DateTime endPeriod,
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
        Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
            Symbol symbol, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific exchange, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-exchange"/>
        HistoricalTradesResponse HistoricalTrades(Exchange exchange, DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific exchange, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-exchange"/>
        Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
            Exchange exchange, DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific exchange, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="endPeriod">End of the requested period</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-exchange"/>
        HistoricalTradesResponse HistoricalTrades(Exchange exchange, DateTime startPeriod, DateTime endPeriod,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific exchange, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="endPeriod">End of the requested period</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-exchange"/>
        Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
            Exchange exchange, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific base asset, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-base-asset"/>
        HistoricalTradesResponse HistoricalTrades(Asset baseAsset, DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific base asset, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-base-asset"/>
        Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
            Asset baseAsset, DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific base asset, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="endPeriod">End of the requested period</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-base-asset"/>
        HistoricalTradesResponse HistoricalTrades(Asset baseAsset, DateTime startPeriod, DateTime endPeriod,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific base asset, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="endPeriod">End of the requested period</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-base-asset"/>
        Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
            Asset baseAsset, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific assets pair (exp. BTC/USD), returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-pair"/>
        HistoricalTradesResponse HistoricalTrades(Asset baseAsset, Asset quoteAsset, DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific assets pair (exp. BTC/USD), returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-pair"/>
        Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific assets pair (exp. BTC/USD), returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="endPeriod">End of the requested period</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-pair"/>
        HistoricalTradesResponse HistoricalTrades(Asset baseAsset, Asset quoteAsset,
            DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific assets pair (exp. BTC/USD), returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="endPeriod">End of the requested period</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-pair"/>
        Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific assets pair (exp. BTC/USD) in a specific exchange, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-exchange-pair"/>
        HistoricalTradesResponse HistoricalTrades(Exchange exchange, Asset baseAsset, Asset quoteAsset,
            DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific assets pair (exp. BTC/USD) in a specific exchange, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-exchange-pair"/>
        Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken, Exchange exchange,
            Asset baseAsset, Asset quoteAsset, DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific assets pair (exp. BTC/USD) in a specific exchange, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="endPeriod">End of the requested period</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-exchange-pair"/>
        HistoricalTradesResponse HistoricalTrades(Exchange exchange, Asset baseAsset, Asset quoteAsset,
            DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific assets pair (exp. BTC/USD) in a specific exchange, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="startPeriod">Start of the requested period.</param>
        /// <param name="endPeriod">End of the requested period</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-exchange-pair"/>
        Task<HistoricalTradesResponse> HistoricalTradesAsync(CancellationToken cancellationToken, Exchange exchange,
            Asset baseAsset, Asset quoteAsset, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get information about calls related to order book data, also known as books or passive level 2 data.
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <returns>Response with orderbook.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#order-book-snapshot-by-symbol"/>
        OrderBookResponse OrderBook(Exchange exchange, Asset baseAsset, Asset quoteAsset);

        /// <summary>
        /// Get information about calls related to order book data, also known as books or passive level 2 data.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <returns>Response with orderbook.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#order-book-snapshot-by-symbol"/>
        Task<OrderBookResponse> OrderBookAsync(CancellationToken cancellationToken,
            Exchange exchange, Asset baseAsset, Asset quoteAsset);
    }
}