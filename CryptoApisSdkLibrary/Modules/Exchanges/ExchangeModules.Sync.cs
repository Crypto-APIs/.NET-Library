using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;

namespace CryptoApisSdkLibrary.Modules.Exchanges
{
    internal partial class ExchangeModules
    {
        public ExchangesMetaResponse ExchangesMeta(int skip = 0, int limit = 50)
        {
            return ExchangesMetaAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangesSupportingAssetResponse ExchangesSupportingAsset(Asset asset, int skip = 0, int limit = 50)
        {
            return ExchangesSupportingAssetAsync(CancellationToken.None, asset, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangesAssetsResponse ExchangesSupportingPairs(Asset asset1, Asset asset2, int skip = 0, int limit = 50)
        {
            return ExchangesSupportingPairsAsync(CancellationToken.None, asset1, asset2, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangesAssetsResponse SymbolsInExchange(Exchange exchange, int skip = 0, int limit = 50)
        {
            return SymbolsInExchangeAsync(CancellationToken.None, exchange, skip, limit).GetAwaiter().GetResult();
        }

        public AssetsMetaResponse AssetsMeta(int skip = 0, int limit = 50)
        {
            return AssetsMetaAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public AssetsResponse Assets(int skip = 0, int limit = 50)
        {
            return AssetsAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public AssetDetailsResponse AssetDetails(Asset asset)
        {
            return AssetDetailsAsync(CancellationToken.None, asset).GetAwaiter().GetResult();
        }

        public SymbolDetailsResponse SymbolDetails(Symbol symbol)
        {
            return SymbolDetailsAsync(CancellationToken.None, symbol).GetAwaiter().GetResult();
        }

        public SymbolsResponse Symbols(int skip = 0, int limit = 50)
        {
            return SymbolsAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangesResponse Exchanges(int skip = 0, int limit = 50)
        {
            return ExchangesAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangeDetailsResponse ExchangeDetails(Exchange exchange)
        {
            return ExchangeDetailsAsync(CancellationToken.None, exchange).GetAwaiter().GetResult();
        }

        public PeriodsResponse Periods(int skip = 0, int limit = 50)
        {
            return PeriodsAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangeRateResponse ExchangeRate(Asset baseAsset, Asset quoteAsset)
        {
            return ExchangeRateAsync(CancellationToken.None, baseAsset, quoteAsset).GetAwaiter().GetResult();
        }

        public ExchangeRateResponse ExchangeRate(Asset baseAsset, Asset quoteAsset, DateTime timeStamp)
        {
            return ExchangeRateAsync(CancellationToken.None, baseAsset, quoteAsset, timeStamp).GetAwaiter().GetResult();
        }

        public ExchangeRatesResponse ExchangeRates(Asset baseAsset, int skip = 0, int limit = 50)
        {
            return ExchangeRatesAsync(CancellationToken.None, baseAsset, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangeRatesResponse ExchangeRates(Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50)
        {
            return ExchangeRatesAsync(CancellationToken.None, baseAsset, timeStamp, skip, limit).GetAwaiter().GetResult();
        }

        public CurrentRateInExchangeResponse ExchangeRate(Asset baseAsset, Asset quoteAsset, Exchange exchange)
        {
            return ExchangeRateAsync(CancellationToken.None, baseAsset, quoteAsset, exchange).GetAwaiter().GetResult();
        }

        public CurrentRateInExchangeResponse ExchangeRate(Asset baseAsset, Asset quoteAsset,Exchange exchange, DateTime timeStamp)
        {
            return ExchangeRateAsync(CancellationToken.None, baseAsset, quoteAsset,
                exchange, timeStamp).GetAwaiter().GetResult();
        }

        public CurrentRatesInExchangeResponse ExchangeRates(Asset baseAsset, Exchange exchange,
            int skip = 0, int limit = 50)
        {
            return ExchangeRatesAsync(CancellationToken.None, baseAsset,
                exchange, skip, limit).GetAwaiter().GetResult();
        }

        public CurrentRatesInExchangeResponse ExchangeRates(Asset baseAsset, Exchange exchange,
            DateTime timeStamp, int skip = 0, int limit = 50)
        {
            return ExchangeRatesAsync(CancellationToken.None, baseAsset,
                exchange, timeStamp, skip, limit).GetAwaiter().GetResult();
        }

        public LatestOhlcvResponse LatestOhlcv(Symbol symbol, Period period, int limit = 50)
        {
            return LatestOhlcvAsync(CancellationToken.None, symbol, period, limit).GetAwaiter().GetResult();
        }

        public HistoricalOhlcvResponse HistoricalOhlcv(Symbol symbol, Period period, DateTime startPeriod, int limit = 50)
        {
            return HistoricalOhlcvAsync(CancellationToken.None, symbol, period, startPeriod, limit).GetAwaiter().GetResult();
        }

        public HistoricalOhlcvResponse HistoricalOhlcv(Symbol symbol, Period period,
            DateTime startPeriod, DateTime endPeriod, int limit = 50)
        {
            return HistoricalOhlcvAsync(CancellationToken.None, symbol, period, startPeriod, endPeriod, limit).GetAwaiter().GetResult();
        }

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

        public OrderBookResponse OrderBook(Exchange exchange, Asset baseAsset, Asset quoteAsset)
        {
            return OrderBookAsync(CancellationToken.None, exchange, baseAsset, quoteAsset).GetAwaiter().GetResult();
        }
    }
}