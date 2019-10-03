using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using CryptoApisSdkLibrary.Misc;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Exchanges
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest ExchangesMeta(int skip, int limit)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get("exchanges/meta");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest ExchangesSupportingAsset(Asset asset, int skip, int limit)
        {
            if (asset == null)
                throw new ArgumentNullException(nameof(asset));
            if (string.IsNullOrEmpty(asset.Id))
                throw new ArgumentNullException(nameof(asset.Id));
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"exchanges/asset/{asset.Id}");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest ExchangesSupportingPairs(Asset asset1, Asset asset2, int skip, int limit)
        {
            if (asset1 == null)
                throw new ArgumentNullException(nameof(asset1));
            if (string.IsNullOrEmpty(asset1.Id))
                throw new ArgumentNullException(nameof(asset1.Id));
            if (asset2 == null)
                throw new ArgumentNullException(nameof(asset2));
            if (string.IsNullOrEmpty(asset2.Id))
                throw new ArgumentNullException(nameof(asset2.Id));
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"exchanges/pair/{asset1.Id}/{asset2.Id}");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest AllSymbolsInExchange(Exchange exchange, int skip, int limit)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException(nameof(exchange.Id));
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"exchanges/{exchange.Id}/pairs");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest AssetsMeta(int skip, int limit)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get("assets/meta");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest Assets(int skip, int limit)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get("assets");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest AssetDetails(Asset asset)
        {
            if (asset == null)
                throw new ArgumentNullException(nameof(asset));
            if (string.IsNullOrEmpty(asset.Id))
                throw new ArgumentNullException(nameof(asset.Id));

            var request = Request.Get($"assets/{asset.Id}");

            return request;
        }

        public IRestRequest SymbolDetails(Symbol symbol)
        {
            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(symbol.Id))
                throw new ArgumentNullException(nameof(symbol.Id));

            var request = Request.Get($"mappings/{symbol.Id}");

            return request;
        }

        public IRestRequest Symbols(int skip, int limit)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get("mappings");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest Exchanges(int skip, int limit)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get("exchanges");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest ExchangeDetails(Exchange exchange)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException(nameof(exchange.Id));

            var request = Request.Get($"exchanges/{exchange.Id}");

            return request;
        }

        public IRestRequest Periods(int skip, int limit)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.OHLCVEndPoint}/periods");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest ExchangeRate(Asset baseAsset, Asset quoteAsset, DateTime? timeStamp)
        {
            return ExchangeRate(baseAsset, quoteAsset, timeStamp,
                () => $"exchange-rates/{baseAsset.Id}/{quoteAsset.Id}");
        }

        public IRestRequest ExchangeRate(Asset baseAsset, Asset quoteAsset, Exchange exchange, DateTime? timeStamp)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException(nameof(exchange.Id));

            return ExchangeRate(baseAsset, quoteAsset, timeStamp,
                () => $"exchange-rates/exchange/{exchange.Id}/{baseAsset.Id}/{quoteAsset.Id}");
        }

        public IRestRequest ExchangeRates(Asset baseAsset, DateTime? timeStamp, int skip, int limit)
        {
            return ExchangeRates(baseAsset, timeStamp, skip, limit,
                () => $"exchange-rates/{baseAsset.Id}");
        }

        public IRestRequest ExchangeRates(Asset baseAsset, Exchange exchange, DateTime? timeStamp, int skip, int limit)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException(nameof(exchange.Id));
            return ExchangeRates(baseAsset, timeStamp, skip, limit,
                () => $"exchange-rates/exchange/{exchange.Id}/{baseAsset.Id}");
        }

        public IRestRequest LatestOhlcv(Symbol symbol, Period period, int limit)
        {
            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(symbol.Id))
                throw new ArgumentNullException(nameof(symbol.Id));
            if (period == null)
                throw new ArgumentNullException(nameof(period));
            if (string.IsNullOrEmpty(period.Id))
                throw new ArgumentNullException(nameof(period.Id));
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.OHLCVEndPoint}/latest/{symbol.Id}");
            request.AddQueryParameter("period", period.Id);
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest HistoricalOhlcv(
            Symbol symbol, Period period, DateTime startPeriod, DateTime? endPeriod, int limit)
        {
            if (symbol == null)
                throw new RequestException("Symbol is null");
            if (string.IsNullOrEmpty(symbol.Id))
                throw new ArgumentNullException(nameof(symbol.Id));
            if (period == null)
                throw new RequestException("Period is null");
            if (string.IsNullOrEmpty(period.Id))
                throw new ArgumentNullException(nameof(period.Id));
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.OHLCVEndPoint}/history/{symbol.Id}");
            request.AddQueryParameter("period", period.ToString());
            request.AddQueryParameter("timePeriodStart", Tools.ToUnixTimestamp(startPeriod));
            if (endPeriod.HasValue)
            {
                request.AddQueryParameter("timePeriodEnd", Tools.ToUnixTimestamp(endPeriod.Value));
            }
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest LatestTrades(int skip, int limit)
        {
            return LatestTrades(skip, limit,
                () => $"{Consts.TradesPoint}/latest");
        }

        public IRestRequest LatestTrades(Symbol symbol, int skip, int limit)
        {
            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(symbol.Id))
                throw new ArgumentNullException(nameof(symbol.Id));

            return LatestTrades(skip, limit,
                () => $"{Consts.TradesPoint}/{symbol.Id}/latest");
        }

        public IRestRequest LatestTrades(Exchange exchange, int skip, int limit)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException(nameof(exchange.Id));

            return LatestTrades(skip, limit,
                () => $"{Consts.TradesPoint}/exchange/{exchange.Id}/latest");
        }

        public IRestRequest LatestTrades(Asset baseAsset, int skip, int limit)
        {
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException(nameof(baseAsset.Id));

            return LatestTrades(skip, limit,
                () => $"{Consts.TradesPoint}/baseAsset/{baseAsset.Id}/latest");
        }

        public IRestRequest LatestTrades(Asset baseAsset, Asset quoteAsset, int skip, int limit)
        {
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException(nameof(baseAsset.Id));
            if (quoteAsset == null)
                throw new ArgumentNullException(nameof(quoteAsset));
            if (string.IsNullOrEmpty(quoteAsset.Id))
                throw new ArgumentNullException(nameof(quoteAsset.Id));

            return LatestTrades(skip, limit,
                () => $"{Consts.TradesPoint}/baseAsset/{baseAsset.Id}/quoteAsset/{quoteAsset.Id}/latest");
        }

        public IRestRequest LatestTrades(Exchange exchange, Asset baseAsset, Asset quoteAsset, int skip, int limit)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException(nameof(exchange.Id));
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException(nameof(baseAsset.Id));
            if (quoteAsset == null)
                throw new ArgumentNullException(nameof(quoteAsset));
            if (string.IsNullOrEmpty(quoteAsset.Id))
                throw new ArgumentNullException(nameof(quoteAsset.Id));

            return LatestTrades(skip, limit,
                () => $"{Consts.TradesPoint}/exchange/{exchange.Id}/baseAsset/{baseAsset.Id}/quoteAsset/{quoteAsset.Id}/latest");
        }

        public IRestRequest HistoricalTrades(Symbol symbol,
            int skip, int limit, DateTime? startPeriod, DateTime? endPeriod)
        {
            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(symbol.Id))
                throw new ArgumentNullException(nameof(symbol.Id));
            return HistoricalTrades(skip, limit, startPeriod, endPeriod,
                () => $"{Consts.TradesPoint}/{symbol.Id}/history");
        }

        public IRestRequest HistoricalTrades(Exchange exchange,
            int skip, int limit, DateTime? startPeriod, DateTime? endPeriod)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException(nameof(exchange.Id));

            return HistoricalTrades(skip, limit, startPeriod, endPeriod,
                () => $"{Consts.TradesPoint}/exchange/{exchange.Id}/history");
        }

        public IRestRequest HistoricalTrades(Asset baseAsset,
            int skip, int limit, DateTime? startPeriod, DateTime? endPeriod)
        {
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException(nameof(baseAsset.Id));

            return HistoricalTrades(skip, limit, startPeriod, endPeriod,
                () => $"{Consts.TradesPoint}/baseAsset/{baseAsset.Id}/history");
        }

        public IRestRequest HistoricalTrades(Asset baseAsset, Asset quoteAsset,
            int skip, int limit, DateTime? startPeriod, DateTime? endPeriod)
        {
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException(nameof(baseAsset.Id));
            if (quoteAsset == null)
                throw new ArgumentNullException(nameof(quoteAsset));
            if (string.IsNullOrEmpty(quoteAsset.Id))
                throw new ArgumentNullException(nameof(quoteAsset.Id));

            return HistoricalTrades(skip, limit, startPeriod, endPeriod,
                () => $"{Consts.TradesPoint}/baseAsset/{baseAsset.Id}/quoteAsset/{quoteAsset}/history");
        }

        public IRestRequest HistoricalTrades(Exchange exchange, Asset baseAsset, Asset quoteAsset,
            int skip, int limit, DateTime? startPeriod, DateTime? endPeriod)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException(nameof(exchange.Id));
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException(nameof(baseAsset.Id));
            if (quoteAsset == null)
                throw new ArgumentNullException(nameof(quoteAsset));
            if (string.IsNullOrEmpty(quoteAsset.Id))
                throw new ArgumentNullException(nameof(quoteAsset.Id));

            return HistoricalTrades(skip, limit, startPeriod, endPeriod,
                () => $"{Consts.TradesPoint}/exchange/{exchange.Id}/baseAsset/{baseAsset.Id}/quoteAsset/{quoteAsset}/history");
        }

        public IRestRequest OrderBook(Exchange exchange, Asset baseAsset, Asset quoteAsset)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.ExchangeId))
                throw new ArgumentNullException(nameof(exchange.ExchangeId));
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.AssetId))
                throw new ArgumentNullException(nameof(baseAsset.AssetId));
            if (quoteAsset == null)
                throw new ArgumentNullException(nameof(quoteAsset));
            if (string.IsNullOrEmpty(quoteAsset.AssetId))
                throw new ArgumentNullException(nameof(quoteAsset.AssetId));

            var request = Request.Get($"{Consts.OrderBook}/{exchange.ExchangeId}_SPOT_{baseAsset.AssetId}_{quoteAsset.AssetId}");

            return request;
        }

        private IRestRequest ExchangeRates(Asset baseAsset, DateTime? timeStamp, int skip, int limit, Func<string> url)
        {
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException(nameof(baseAsset.Id));
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get(url.Invoke());
            if (timeStamp.HasValue)
            {
                request.AddQueryParameter("timestamp", Tools.ToUnixTimestamp(timeStamp.Value));
            }
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        private IRestRequest ExchangeRate(Asset baseAsset, Asset quoteAsset, DateTime? timeStamp, Func<string> url)
        {
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException(nameof(baseAsset.Id));
            if (quoteAsset == null)
                throw new ArgumentNullException(nameof(quoteAsset));
            if (string.IsNullOrEmpty(quoteAsset.Id))
                throw new ArgumentNullException(nameof(quoteAsset.Id));

            var request = Request.Get(url.Invoke());
            if (timeStamp.HasValue)
            {
                request.AddQueryParameter("timestamp", Tools.ToUnixTimestamp(timeStamp.Value));
            }

            return request;
        }

        private IRestRequest LatestTrades(int skip, int limit, Func<string> url)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get(url.Invoke());
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        private IRestRequest HistoricalTrades(int skip, int limit, DateTime? startPeriod, DateTime? endPeriod, Func<string> url)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get(url.Invoke());
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            if (startPeriod.HasValue)
            {
                if (startPeriod > DateTime.Now)
                {
                    throw new RequestException("StartPeriod is from future.");
                }
                request.AddQueryParameter("timeStart", Tools.ToUnixTimestamp(startPeriod.Value));
            }
            if (endPeriod.HasValue)
            {
                if (endPeriod < startPeriod)
                {
                    throw new RequestException("EndPeriod is less than StartPeriod");
                }
                request.AddQueryParameter("timeEnd", Tools.ToUnixTimestamp(endPeriod.Value));
            }

            return request;
        }

        private CryptoApiRequest Request { get; }
    }
}