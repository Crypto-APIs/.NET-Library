using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.Exceptions;
using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Trade.Private
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
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

        public IRestRequest LatestOhlcv(Symbol symbol, Period period, int limit)
        {
            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(symbol.Id))
                throw new ArgumentNullException($"{nameof(symbol)}.{nameof(symbol.Id)}");

            return InternalLatestOhlcv(period, limit, () =>
                $"{Consts.OHLCVEndPoint}/latest/{symbol.Id}");
        }

        public IRestRequest LatestOhlcv(Exchange exchange, Period period, int limit)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");

            return InternalLatestOhlcv(period, limit, () =>
                $"{Consts.OHLCVEndPoint}/latest/by-exchange/{exchange.Id}");
        }

        public IRestRequest LatestOhlcv(Exchange exchange, Asset asset, Period period, int limit)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");
            if (asset == null)
                throw new ArgumentNullException(nameof(asset));
            if (string.IsNullOrEmpty(asset.Id))
                throw new ArgumentNullException($"{nameof(asset)}.{nameof(asset.Id)}");

            return InternalLatestOhlcv(period, limit, () =>
                $"{Consts.OHLCVEndPoint}/latest/by-exchange-and-asset/{exchange.Id}/{asset.Id}");
        }

        private IRestRequest InternalLatestOhlcv(Period period, int limit, Func<string> getUrl)
        {
            if (period == null)
                throw new ArgumentNullException(nameof(period));
            if (string.IsNullOrEmpty(period.Id))
                throw new ArgumentNullException($"{nameof(period)}.{nameof(period.Id)}");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get(getUrl.Invoke());
            request.AddQueryParameter("period", period.Id);
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest HistoricalOhlcv(Symbol symbol, Period period,
            DateTime startPeriod, DateTime? endPeriod, int skip, int limit)
        {
            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(symbol.Id))
                throw new ArgumentNullException($"{nameof(symbol)}.{nameof(symbol.Id)}");

            return InternalHistoricalOhlcv(period, startPeriod, endPeriod, skip, limit,
                () => $"{Consts.OHLCVEndPoint}/history/{symbol.Id}");
        }

        public IRestRequest HistoricalOhlcv(Exchange exchange, Period period,
            DateTime startPeriod, DateTime? endPeriod, int skip, int limit)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");

            return InternalHistoricalOhlcv(period, startPeriod, endPeriod, skip, limit,
                () => $"{Consts.OHLCVEndPoint}/history/by-exchange/{exchange.Id}");
        }

        public IRestRequest HistoricalOhlcv(Exchange exchange, Asset asset, Period period,
            DateTime startPeriod, DateTime? endPeriod, int skip, int limit)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");
            if (asset == null)
                throw new ArgumentNullException(nameof(asset));
            if (string.IsNullOrEmpty(asset.Id))
                throw new ArgumentNullException($"{nameof(asset)}.{nameof(asset.Id)}");

            return InternalHistoricalOhlcv(period, startPeriod, endPeriod, skip, limit,
                () => $"{Consts.OHLCVEndPoint}/history/by-exchange-and-asset/{exchange.Id}/{asset.Id}");
        }

        private IRestRequest InternalHistoricalOhlcv(Period period,
            DateTime startPeriod, DateTime? endPeriod, int skip, int limit, Func<string> getUrl)
        {
            if (period == null)
                throw new ArgumentNullException(nameof(period));
            if (string.IsNullOrEmpty(period.Id))
                throw new ArgumentNullException($"{nameof(period)}.{nameof(period.Id)}");
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");
            if (endPeriod.HasValue && startPeriod >= endPeriod)
                throw new RequestException("StartPeriod is more than EndPeriod");

            var request = Request.Get(getUrl.Invoke());
            request.AddQueryParameter("period", period.ToString());
            request.AddQueryParameter("timePeriodStart", Tools.ToUnixTimestamp(startPeriod));
            if (endPeriod.HasValue)
            {
                request.AddQueryParameter("timePeriodEnd", Tools.ToUnixTimestamp(endPeriod.Value));
            }
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        private CryptoApiRequest Request { get; }
    }
}