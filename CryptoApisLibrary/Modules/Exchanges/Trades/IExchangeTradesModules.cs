using System;
using System.Threading;
using System.Threading.Tasks;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;

namespace CryptoApisLibrary.Modules.Exchanges.Trades
{
    public interface IExchangeTradesModules
    {
        /// <summary>
        /// Get latest trades from all symbols up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data"/>
        LatestTradesResponse Latest(int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from all symbols up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data"/>
        Task<LatestTradesResponse> LatestAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific symbol up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="symbol">Symbol identifier used to filter response.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data-by-symbol"/>
        LatestTradesResponse Latest(Symbol symbol, int skip = 0, int limit = 50);

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
        Task<LatestTradesResponse> LatestAsync(CancellationToken cancellationToken,
            Symbol symbol, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific exchange up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data-by-exchange"/>
        LatestTradesResponse Latest(Exchange exchange, int skip = 0, int limit = 50);

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
        Task<LatestTradesResponse> LatestAsync(CancellationToken cancellationToken,
            Exchange exchange, int skip = 0, int limit = 50);

        /// <summary>
        /// Get latest trades from a specific base asset up to 1 hour ago. Latest data is always returned in time descending order.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with latest trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-latest-data-by-base-asset"/>
        LatestTradesResponse Latest(Asset baseAsset, int skip = 0, int limit = 50);

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
        Task<LatestTradesResponse> LatestAsync(CancellationToken cancellationToken,
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
        LatestTradesResponse Latest(Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50);

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
        Task<LatestTradesResponse> LatestAsync(CancellationToken cancellationToken,
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
        LatestTradesResponse Latest(Exchange exchange, Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50);

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
        Task<LatestTradesResponse> LatestAsync(CancellationToken cancellationToken,
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
        HistoricalTradesResponse Historical(Symbol symbol, int skip = 0, int limit = 50);

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
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken,
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
        HistoricalTradesResponse Historical(Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50);

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
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken,
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
        HistoricalTradesResponse Historical(Symbol symbol, DateTime startPeriod, DateTime endPeriod,
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
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken,
            Symbol symbol, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific exchange, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-exchange"/>
        HistoricalTradesResponse Historical(Exchange exchange, int skip = 0, int limit = 50);
        
        /// <summary>
        /// Get history transactions from specific exchange, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-exchange"/>
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken,
            Exchange exchange, int skip = 0, int limit = 50);

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
        HistoricalTradesResponse Historical(Exchange exchange, DateTime startPeriod, int skip = 0, int limit = 50);
        
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
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken,
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
        HistoricalTradesResponse Historical(Exchange exchange, DateTime startPeriod, DateTime endPeriod,
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
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken,
            Exchange exchange, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific base asset, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-base-asset"/>
        HistoricalTradesResponse Historical(Asset baseAsset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific base asset, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-base-asset"/>
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken,
            Asset baseAsset, int skip = 0, int limit = 50);

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
        HistoricalTradesResponse Historical(Asset baseAsset, DateTime startPeriod, int skip = 0, int limit = 50);

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
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken,
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
        HistoricalTradesResponse Historical(Asset baseAsset, DateTime startPeriod, DateTime endPeriod,
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
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken,
            Asset baseAsset, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific assets pair (exp. BTC/USD), returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-pair"/>
        HistoricalTradesResponse Historical(Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific base asset, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-base-asset"/>
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50);

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
        HistoricalTradesResponse Historical(Asset baseAsset, Asset quoteAsset, DateTime startPeriod, int skip = 0, int limit = 50);

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
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken,
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
        HistoricalTradesResponse Historical(Asset baseAsset, Asset quoteAsset,
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
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific assets pair (exp. BTC/USD) in a specific exchange, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-exchange-pair"/>
        HistoricalTradesResponse Historical(Exchange exchange, Asset baseAsset, Asset quoteAsset,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get history transactions from specific assets pair (exp. BTC/USD) in a specific exchange, returned in time ascending order.
        /// If no start & end time is defined when calling the endpoint, your data results will be provided 24 hours back, by default.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical trades.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#trades-historical-data-by-exchange-pair"/>
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken, Exchange exchange,
            Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50);

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
        HistoricalTradesResponse Historical(Exchange exchange, Asset baseAsset, Asset quoteAsset,
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
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken, Exchange exchange,
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
        HistoricalTradesResponse Historical(Exchange exchange, Asset baseAsset, Asset quoteAsset,
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
        Task<HistoricalTradesResponse> HistoricalAsync(CancellationToken cancellationToken, Exchange exchange,
            Asset baseAsset, Asset quoteAsset, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);
    }
}