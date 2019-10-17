using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;

namespace CryptoApisLibrary.Modules.Exchanges.Ohlcv
{
    internal partial class ExchangeOhlcvModules
    {
        public PeriodsResponse Periods(int skip = 0, int limit = 50)
        {
            return PeriodsAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public LatestOhlcvResponse Latest(Symbol symbol, Period period, int limit = 50)
        {
            return LatestAsync(CancellationToken.None, symbol, period, limit).GetAwaiter().GetResult();
        }

        public HistoricalOhlcvResponse Historical(Symbol symbol, Period period, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, symbol, period, startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalOhlcvResponse Historical(Symbol symbol, Period period,
            DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, symbol, period, startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }
    }
}