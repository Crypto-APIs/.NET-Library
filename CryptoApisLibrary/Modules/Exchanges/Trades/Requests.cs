using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.DataTypes.Exceptions;
using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Exchanges.Trades
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
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
                throw new ArgumentNullException($"{nameof(symbol)}.{nameof(symbol.Id)}");

            return LatestTrades(skip, limit,
                () => $"{Consts.TradesPoint}/{symbol.Id}/latest");
        }

        public IRestRequest LatestTrades(Exchange exchange, int skip, int limit)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");

            return LatestTrades(skip, limit,
                () => $"{Consts.TradesPoint}/exchange/{exchange.Id}/latest");
        }

        public IRestRequest LatestTrades(Asset baseAsset, int skip, int limit)
        {
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException($"{nameof(baseAsset)}.{nameof(baseAsset.Id)}");

            return LatestTrades(skip, limit,
                () => $"{Consts.TradesPoint}/baseAsset/{baseAsset.Id}/latest");
        }

        public IRestRequest LatestTrades(Asset baseAsset, Asset quoteAsset, int skip, int limit)
        {
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException($"{nameof(baseAsset)}.{nameof(baseAsset.Id)}");
            if (quoteAsset == null)
                throw new ArgumentNullException(nameof(quoteAsset));
            if (string.IsNullOrEmpty(quoteAsset.Id))
                throw new ArgumentNullException($"{nameof(quoteAsset)}.{nameof(quoteAsset.Id)}");

            return LatestTrades(skip, limit,
                () => $"{Consts.TradesPoint}/baseAsset/{baseAsset.Id}/quoteAsset/{quoteAsset.Id}/latest");
        }

        public IRestRequest LatestTrades(Exchange exchange, Asset baseAsset, Asset quoteAsset, int skip, int limit)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException($"{nameof(baseAsset)}.{nameof(baseAsset.Id)}");
            if (quoteAsset == null)
                throw new ArgumentNullException(nameof(quoteAsset));
            if (string.IsNullOrEmpty(quoteAsset.Id))
                throw new ArgumentNullException($"{nameof(quoteAsset)}.{nameof(quoteAsset.Id)}");

            return LatestTrades(skip, limit,
                () => $"{Consts.TradesPoint}/exchange/{exchange.Id}/baseAsset/{baseAsset.Id}/quoteAsset/{quoteAsset.Id}/latest");
        }

        public IRestRequest HistoricalTrades(Symbol symbol,
            int skip, int limit, DateTime? startPeriod, DateTime? endPeriod)
        {
            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(symbol.Id))
                throw new ArgumentNullException($"{nameof(symbol)}.{nameof(symbol.Id)}");
            return HistoricalTrades(skip, limit, startPeriod, endPeriod,
                () => $"{Consts.TradesPoint}/{symbol.Id}/history");
        }

        public IRestRequest HistoricalTrades(Exchange exchange,
            int skip, int limit, DateTime? startPeriod, DateTime? endPeriod)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");

            return HistoricalTrades(skip, limit, startPeriod, endPeriod,
                () => $"{Consts.TradesPoint}/exchange/{exchange.Id}/history");
        }

        public IRestRequest HistoricalTrades(Asset baseAsset,
            int skip, int limit, DateTime? startPeriod, DateTime? endPeriod)
        {
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException($"{nameof(baseAsset)}.{nameof(baseAsset.Id)}");

            return HistoricalTrades(skip, limit, startPeriod, endPeriod,
                () => $"{Consts.TradesPoint}/baseAsset/{baseAsset.Id}/history");
        }

        public IRestRequest HistoricalTrades(Asset baseAsset, Asset quoteAsset,
            int skip, int limit, DateTime? startPeriod, DateTime? endPeriod)
        {
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException($"{nameof(baseAsset)}.{nameof(baseAsset.Id)}");
            if (quoteAsset == null)
                throw new ArgumentNullException(nameof(quoteAsset));
            if (string.IsNullOrEmpty(quoteAsset.Id))
                throw new ArgumentNullException($"{nameof(quoteAsset)}.{nameof(quoteAsset.Id)}");

            return HistoricalTrades(skip, limit, startPeriod, endPeriod,
                () => $"{Consts.TradesPoint}/baseAsset/{baseAsset.Id}/quoteAsset/{quoteAsset.Id}/history");
        }

        public IRestRequest HistoricalTrades(Exchange exchange, Asset baseAsset, Asset quoteAsset,
            int skip, int limit, DateTime? startPeriod, DateTime? endPeriod)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException($"{nameof(baseAsset)}.{nameof(baseAsset.Id)}");
            if (quoteAsset == null)
                throw new ArgumentNullException(nameof(quoteAsset));
            if (string.IsNullOrEmpty(quoteAsset.Id))
                throw new ArgumentNullException($"{nameof(quoteAsset)}.{nameof(quoteAsset.Id)}");

            return HistoricalTrades(skip, limit, startPeriod, endPeriod,
                () => $"{Consts.TradesPoint}/exchange/{exchange.Id}/baseAsset/{baseAsset.Id}/quoteAsset/{quoteAsset.Id}/history");
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