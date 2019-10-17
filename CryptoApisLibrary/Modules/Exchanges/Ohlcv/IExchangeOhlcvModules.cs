using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Exchanges.Ohlcv
{
    public interface IExchangeOhlcvModules
    {
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
        LatestOhlcvResponse Latest(Symbol symbol, Period period, int limit = 50);

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
        Task<LatestOhlcvResponse> LatestAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, int limit = 50);

        /// <summary>
        /// Get OHLCV time-series data for requested symbol and period. Returned in time ascending order.
        /// The data is returned to the end or when count of result elements reaches the limit.
        /// </summary>
        /// <param name="symbol">Symbol used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="startPeriod">Time period starting time.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical time-series data.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#historical-data"/>
        HistoricalOhlcvResponse Historical(Symbol symbol, Period period,
            DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get OHLCV time-series data for requested symbol and period. Returned in time ascending order.
        /// The data is returned to the end or when count of result elements reaches the limit.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="startPeriod">Time period starting time.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical time-series data.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#historical-data"/>
        Task<HistoricalOhlcvResponse> HistoricalAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, DateTime startPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get OHLCV time-series data for requested symbol and period within the specified time interval. Returned in time ascending order.
        /// </summary>
        /// <param name="symbol">Symbol used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="startPeriod">Time period starting time.</param>
        /// <param name="endPeriod">Time period ending time</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical time-series data.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#historical-data"/>
        HistoricalOhlcvResponse Historical(Symbol symbol, Period period,
            DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);

        /// <summary>
        /// Get OHLCV time-series data for requested symbol and period within the specified time interval. Returned in time ascending order.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol used to filter response.</param>
        /// <param name="period">Identifier of requested time period.</param>
        /// <param name="startPeriod">Time period starting time.</param>
        /// <param name="endPeriod">Time period ending time</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with historical time-series data.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#historical-data"/>
        Task<HistoricalOhlcvResponse> HistoricalAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50);
    }
}