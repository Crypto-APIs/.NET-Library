using System;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System.Threading;

namespace CryptoApisSdkLibrary.Modules.Exchanges.Trades
{
    internal partial class ExchangeTradesModules
    {
        public LatestTradesResponse LatestTrades(int skip = 0, int limit = 50)
        {
            return LatestTradesAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public LatestTradesResponse LatestTrades(Symbol symbol, int skip = 0, int limit = 50)
        {
            return LatestTradesAsync(CancellationToken.None, symbol, skip, limit).GetAwaiter().GetResult();
        }

        public LatestTradesResponse LatestTrades(Exchange exchange, int skip = 0, int limit = 50)
        {
            return LatestTradesAsync(CancellationToken.None, exchange, skip, limit).GetAwaiter().GetResult();
        }

        public LatestTradesResponse LatestTrades(Asset baseAsset, int skip = 0, int limit = 50)
        {
            return LatestTradesAsync(CancellationToken.None, baseAsset, skip, limit).GetAwaiter().GetResult();
        }

        public LatestTradesResponse LatestTrades(Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50)
        {
            return LatestTradesAsync(CancellationToken.None, baseAsset, quoteAsset, skip, limit).GetAwaiter().GetResult();
        }

        public LatestTradesResponse LatestTrades(Exchange exchange, Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50)
        {
            return LatestTradesAsync(CancellationToken.None, exchange,
                baseAsset, quoteAsset, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse HistoricalTrades(Symbol symbol, int skip = 0, int limit = 50)
        {
            return HistoricalTradesAsync(CancellationToken.None, symbol, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse HistoricalTrades(Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            return HistoricalTradesAsync(CancellationToken.None, symbol,
                startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse HistoricalTrades(Symbol symbol, DateTime startPeriod, DateTime endPeriod,
            int skip = 0, int limit = 50)
        {
            return HistoricalTradesAsync(CancellationToken.None, symbol,
                startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse HistoricalTrades(Exchange exchange, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            return HistoricalTradesAsync(CancellationToken.None, exchange,
                startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse HistoricalTrades(Exchange exchange, DateTime startPeriod, DateTime endPeriod, int skip = 0,
            int limit = 50)
        {
            return HistoricalTradesAsync(CancellationToken.None, exchange,
                startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse HistoricalTrades(Asset baseAsset, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            return HistoricalTradesAsync(CancellationToken.None, baseAsset,
                startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse HistoricalTrades(Asset baseAsset, DateTime startPeriod, DateTime endPeriod, int skip = 0,
            int limit = 50)
        {
            return HistoricalTradesAsync(CancellationToken.None, baseAsset,
                startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse HistoricalTrades(Asset baseAsset, Asset quoteAsset, DateTime startPeriod, int skip = 0,
            int limit = 50)
        {
            return HistoricalTradesAsync(CancellationToken.None, baseAsset, quoteAsset,
                startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse HistoricalTrades(Asset baseAsset, Asset quoteAsset, DateTime startPeriod, DateTime endPeriod,
            int skip = 0, int limit = 50)
        {
            return HistoricalTradesAsync(CancellationToken.None, baseAsset, quoteAsset,
                startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse HistoricalTrades(Exchange exchange, Asset baseAsset, Asset quoteAsset, DateTime startPeriod,
            int skip = 0, int limit = 50)
        {
            return HistoricalTradesAsync(CancellationToken.None, exchange, baseAsset, quoteAsset,
                startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse HistoricalTrades(Exchange exchange, Asset baseAsset, Asset quoteAsset, DateTime startPeriod,
            DateTime endPeriod, int skip = 0, int limit = 50)
        {
            return HistoricalTradesAsync(CancellationToken.None, exchange, baseAsset, quoteAsset,
                startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }
    }
}