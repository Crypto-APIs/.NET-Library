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

        public IRestRequest GetExchanges(int skip, int limit)
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

        public IRestRequest GetAssets(int skip, int limit)
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

        public IRestRequest GetSymbols(int skip = 0, int limit = 50)
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

        public IRestRequest GetPeriods(int skip = 0, int limit = 50)
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

        public IRestRequest GetExchangeRate(Asset baseAsset, Asset quoteAsset,
            DateTime? timeStamp = null)
        {
            if (baseAsset == null)
                throw new RequestException("BaseAsset is null");
            if (quoteAsset == null)
                throw new RequestException("QuoteAsset is null");

            var request = Request.Get($"exchange-rates/{baseAsset}/{quoteAsset}");
            if (timeStamp.HasValue)
            {
                request.AddQueryParameter("timestamp", Tools.ToUnixTimestamp(timeStamp.Value));
            }

            return request;
        }

        public IRestRequest GetCurrentRates(Asset baseAsset,
            DateTime? timeStamp = null, int skip = 0, int limit = 100)
        {
            if (baseAsset == null)
                throw new RequestException("BaseAsset is null");
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"exchange-rates/{baseAsset}");
            if (timeStamp.HasValue)
            {
                request.AddQueryParameter("timestamp", Tools.ToUnixTimestamp(timeStamp.Value));
            }
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest GetLatestData(Symbol symbol, Period period, int limit = 50)
        {
            if (symbol == null)
                throw new RequestException("Symbol is null");
            if (period == null)
                throw new RequestException("Period is null");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.OHLCVEndPoint}/latest/{symbol.Id}");
            request.AddQueryParameter("period", period.Id);
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest GetHistoricalData(
            Symbol symbol, Period period, DateTime startPeriod, DateTime? endPeriod, int limit)
        {
            if (symbol == null)
                throw new RequestException("Symbol is null");
            if (period == null)
                throw new RequestException("Period is null");
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

        public IRestRequest GetLatestTrades(Symbol symbol, int skip = 0, int limit = 50)
        {
            if (symbol == null)
                throw new RequestException("Symbol is null");
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.TradesPoint}/{symbol.Id}/latest");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest GetLatestTrades(int skip = 0, int limit = 50)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.TradesPoint}/latest");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest GetHistoricalTrades(Symbol symbol,
            int skip, int limit, DateTime? startPeriod, DateTime? endPeriod)
        {
            if (symbol == null)
                throw new RequestException("Symbol is null");
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.TradesPoint}/{symbol.Id}/history");
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

        public IRestRequest GetLatestQuoteTrades(int limit = 50)
        {
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.QuoteTradesPoint}/latest");
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest GetHistoricalQuoteTrades(
            Symbol symbol, int skip, int limit, DateTime? startPeriod, DateTime? endPeriod)
        {
            if (symbol == null)
                throw new RequestException("Symbol is null");
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.QuoteTradesPoint}/{symbol.Id}/history");
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

        public IRestRequest GetArbitrageInfo(int skip = 0, int limit = 50)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.Arbitrage}");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        private CryptoApiRequest Request { get; }
    }
}