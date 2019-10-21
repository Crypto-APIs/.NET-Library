using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.Misc;
using RestSharp;
using System;
using CryptoApisLibrary.Exceptions;

namespace CryptoApisLibrary.Modules.Exchanges.Ohlcv
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
            if (period == null)
                throw new ArgumentNullException(nameof(period));
            if (string.IsNullOrEmpty(period.Id))
                throw new ArgumentNullException($"{nameof(period)}.{nameof(period.Id)}");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.OHLCVEndPoint}/latest/{symbol.Id}");
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

            var request = Request.Get($"{Consts.OHLCVEndPoint}/history/{symbol.Id}");
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