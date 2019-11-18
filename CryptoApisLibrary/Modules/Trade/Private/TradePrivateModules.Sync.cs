using System;
using System.Threading;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;

namespace CryptoApisLibrary.Modules.Trade.Private
{
    internal partial class TradePrivateModules
    {
        public PeriodsResponse Periods(int skip = 0, int limit = 50)
        {
            return PeriodsAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public LatestOhlcvResponse Latest(Symbol symbol, Period period, int limit = 50)
        {
            return LatestAsync(CancellationToken.None, symbol, period, limit).GetAwaiter().GetResult();
        }

        public LatestOhlcvResponse Latest(Exchange exchange, Period period, int limit = 50)
        {
            return LatestAsync(CancellationToken.None, exchange, period, limit).GetAwaiter().GetResult();
        }

        public LatestOhlcvResponse Latest(Exchange exchange, Asset asset, Period period, int limit = 50)
        {
            return LatestAsync(CancellationToken.None, exchange, asset, period, limit).GetAwaiter().GetResult();
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

        public HistoricalOhlcvResponse Historical(Exchange exchange, Period period, DateTime startPeriod, int skip = 0,
            int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, exchange, period, startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalOhlcvResponse Historical(Exchange exchange, Period period, DateTime startPeriod, DateTime endPeriod,
            int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, exchange, period, startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalOhlcvResponse Historical(Exchange exchange, Asset asset, Period period, DateTime startPeriod, int skip = 0,
            int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, exchange, asset, period, startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalOhlcvResponse Historical(Exchange exchange, Asset asset, Period period, DateTime startPeriod,
            DateTime endPeriod, int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, exchange, asset, period, startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }
    }
}