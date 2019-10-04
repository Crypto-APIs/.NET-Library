using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Exchanges.Ohlcv
{
    internal partial class ExchangeOhlcvModules
    {
        public Task<PeriodsResponse> PeriodsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50)
        {
            var request = Requests.Periods(skip, limit);
            return GetAsyncResponse<PeriodsResponse>(request, cancellationToken);
        }

        public Task<LatestOhlcvResponse> LatestOhlcvAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, int limit = 50)
        {
            var request = Requests.LatestOhlcv(symbol, period, limit);
            return GetAsyncResponse<LatestOhlcvResponse>(request, cancellationToken);
        }

        public Task<HistoricalOhlcvResponse> HistoricalOhlcvAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.HistoricalOhlcv(symbol, period, startPeriod, null, skip, limit);
            return GetAsyncResponse<HistoricalOhlcvResponse>(request, cancellationToken);
        }

        public Task<HistoricalOhlcvResponse> HistoricalOhlcvAsync(CancellationToken cancellationToken,
            Symbol symbol, Period period, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50)
        {
            var request = Requests.HistoricalOhlcv(symbol, period, startPeriod, endPeriod, skip, limit);
            return GetAsyncResponse<HistoricalOhlcvResponse>(request, cancellationToken);
        }
    }
}