using System;
using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System.Threading;

namespace CryptoApisSdkLibrary.Modules.Exchanges.Trades
{
    internal partial class ExchangeTradesModules
    {
        public LatestTradesResponse Latest(int skip = 0, int limit = 50)
        {
            return LatestAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public LatestTradesResponse Latest(Symbol symbol, int skip = 0, int limit = 50)
        {
            return LatestAsync(CancellationToken.None, symbol, skip, limit).GetAwaiter().GetResult();
        }

        public LatestTradesResponse Latest(Exchange exchange, int skip = 0, int limit = 50)
        {
            return LatestAsync(CancellationToken.None, exchange, skip, limit).GetAwaiter().GetResult();
        }

        public LatestTradesResponse Latest(Asset baseAsset, int skip = 0, int limit = 50)
        {
            return LatestAsync(CancellationToken.None, baseAsset, skip, limit).GetAwaiter().GetResult();
        }

        public LatestTradesResponse Latest(Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50)
        {
            return LatestAsync(CancellationToken.None, baseAsset, quoteAsset, skip, limit).GetAwaiter().GetResult();
        }

        public LatestTradesResponse Latest(Exchange exchange, Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50)
        {
            return LatestAsync(CancellationToken.None, exchange,
                baseAsset, quoteAsset, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Symbol symbol, int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, symbol, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, symbol,
                startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Symbol symbol, DateTime startPeriod, DateTime endPeriod,
            int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, symbol,
                startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Exchange exchange, int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, exchange, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Exchange exchange, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, exchange,
                startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Exchange exchange, DateTime startPeriod, DateTime endPeriod, int skip = 0,
            int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, exchange,
                startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Asset baseAsset, int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, baseAsset, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Asset baseAsset, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, baseAsset,
                startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Asset baseAsset, DateTime startPeriod, DateTime endPeriod, int skip = 0,
            int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, baseAsset,
                startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, baseAsset, quoteAsset, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Asset baseAsset, Asset quoteAsset, DateTime startPeriod, int skip = 0,
            int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, baseAsset, quoteAsset,
                startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Asset baseAsset, Asset quoteAsset, DateTime startPeriod, DateTime endPeriod,
            int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, baseAsset, quoteAsset,
                startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Exchange exchange, Asset baseAsset, Asset quoteAsset, int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, exchange, baseAsset, quoteAsset, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Exchange exchange, Asset baseAsset, Asset quoteAsset, DateTime startPeriod,
            int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, exchange, baseAsset, quoteAsset,
                startPeriod, skip, limit).GetAwaiter().GetResult();
        }

        public HistoricalTradesResponse Historical(Exchange exchange, Asset baseAsset, Asset quoteAsset, DateTime startPeriod,
            DateTime endPeriod, int skip = 0, int limit = 50)
        {
            return HistoricalAsync(CancellationToken.None, exchange, baseAsset, quoteAsset,
                startPeriod, endPeriod, skip, limit).GetAwaiter().GetResult();
        }
    }
}