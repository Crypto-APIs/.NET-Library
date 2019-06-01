using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Exchanges
{
    internal class ExchangeModules : BaseModule, IExchangeModules
    {
        public ExchangeModules(IRestClient client, CryptoApiRequest request) : base(client, request)
        {
        }

        public GetAllExchangesResponse GetExchanges(int skip = 0, int limit = 50)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get("exchanges");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetAllExchangesResponse>(response);
                return responseObject.Data;
            }

            return MakeErrorMessage<GetAllExchangesResponse>(response);
        }

        public GetAllAssetsResponse GetAssets(int skip = 0, int limit = 50)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get("assets");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetAllAssetsResponse>(response);
                return responseObject.Data;
            }

            return MakeErrorMessage<GetAllAssetsResponse>(response);
        }

        public GetAllSymbolsResponse GetSymbols(int skip = 0, int limit = 50)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get("mappings");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetAllSymbolsResponse>(response);
                return responseObject.Data;
            }

            return MakeErrorMessage<GetAllSymbolsResponse>(response);
        }

        public GetExchangeRateResponse GetExchangeRate(Asset baseAsset, Asset quoteAsset)
        {
            return InternalGetExchangeRate(baseAsset, quoteAsset);
        }

        public GetExchangeRateResponse GetExchangeRate(Asset baseAsset, Asset quoteAsset, DateTime timeStamp)
        {
            return InternalGetExchangeRate(baseAsset, quoteAsset, timeStamp);
        }

        public GetAllCurrentRatesResponse GetCurrentRates(Asset baseAsset, int skip = 0, int limit = 50)
        {
            return InternalGetAllCurrentRates(baseAsset, null, skip, limit);
        }

        public GetAllCurrentRatesResponse GetCurrentRates(Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50)
        {
            return InternalGetAllCurrentRates(baseAsset, timeStamp, skip, limit);
        }

        public GetAllPeriodsResponse GetPeriods(int skip = 0, int limit = 50)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.OHLCVEndPoint}/periods");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetAllPeriodsResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetAllPeriodsResponse>(response);
        }

        public GetLatestDataResponse GetLatestData(Symbol symbol, Period period, int limit = 50)
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

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetLatestDataResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetLatestDataResponse>(response);
        }

        public GetHistoricalDataResponse GetHistoricalData(Symbol symbol, Period period, DateTime startPeriod, int limit = 50)
        {
            return InternalGetHistoricalData(symbol, period, startPeriod, null, limit);
        }

        public GetHistoricalDataResponse GetHistoricalData(Symbol symbol, Period period,
            DateTime startPeriod, DateTime endPeriod, int limit = 50)
        {
            return InternalGetHistoricalData(symbol, period, startPeriod, endPeriod, limit);
        }

        public GetAllLatestTradesResponse GetLatestTrades(int skip = 0, int limit = 50)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.TradesPoint}/latest");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetAllLatestTradesResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetAllLatestTradesResponse>(response);
        }

        public GetLatestTradesResponse GetLatestTrades(Symbol symbol, int skip = 0, int limit = 50)
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

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetLatestTradesResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetLatestTradesResponse>(response);
        }

        public GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, int skip = 0, int limit = 50)
        {
            return InternalGetHistoricalTrades(symbol, startPeriod: null, endPeriod: null, skip: skip, limit: limit);
        }

        public GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            return InternalGetHistoricalTrades(symbol, startPeriod, endPeriod: null, skip: skip, limit: limit);
        }

        public GetHistoricalTradesResponse GetHistoricalTrades(Symbol symbol, DateTime startPeriod, DateTime endPeriod,
            int skip = 0, int limit = 50)
        {
            return InternalGetHistoricalTrades(symbol, startPeriod, endPeriod, skip, limit);
        }

        public GetAllLatestQuoteTradesResponse GetLatestQuoteTrades(int limit = 50)
        {
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.QuoteTradesPoint}/latest");
            request.AddQueryParameter("limit", limit.ToString());

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetAllLatestQuoteTradesResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetAllLatestQuoteTradesResponse>(response);
        }

        public GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(Symbol symbol, int skip = 0, int limit = 50)
        {
            return InternalGetHistoricalQuoteTrades(symbol, skip, limit, startPeriod: null, endPeriod: null);
        }

        public GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(Symbol symbol, DateTime startPeriod, int skip = 0, int limit = 50)
        {
            return InternalGetHistoricalQuoteTrades(symbol, skip, limit, startPeriod, endPeriod: null);
        }

        public GetHistoricalQuoteTradesResponse GetHistoricalQuoteTrades(
            Symbol symbol, DateTime startPeriod, DateTime endPeriod, int skip = 0, int limit = 50)
        {
            return InternalGetHistoricalQuoteTrades(symbol, skip, limit, startPeriod, endPeriod);
        }

        public GetArbitrageInfoResponse GetArbitrageInfo(int skip = 0, int limit = 50)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.Arbitrage}");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetArbitrageInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetArbitrageInfoResponse>(response);
        }

        private GetExchangeRateResponse InternalGetExchangeRate(Asset baseAsset, Asset quoteAsset, DateTime? timeStamp = null)
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

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetExchangeRateResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetExchangeRateResponse>(response);
        }

        private GetAllCurrentRatesResponse InternalGetAllCurrentRates(
            Asset baseAsset, DateTime? timeStamp = null, int skip = 0, int limit = 100)
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

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetAllCurrentRatesResponse>(response);
                return responseObject.Data;
            }

            return MakeErrorMessage<GetAllCurrentRatesResponse>(response);
        }

        private GetHistoricalDataResponse InternalGetHistoricalData(
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

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetHistoricalDataResponse>(response);
                return responseObject.Data;
            }

            return MakeErrorMessage<GetHistoricalDataResponse>(response);
        }

        private GetHistoricalTradesResponse InternalGetHistoricalTrades(Symbol symbol, DateTime? startPeriod, DateTime? endPeriod,
            int skip, int limit)
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

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetHistoricalTradesResponse>(response);
                return responseObject.Data;
            }

            return MakeErrorMessage<GetHistoricalTradesResponse>(response);
        }

        private GetHistoricalQuoteTradesResponse InternalGetHistoricalQuoteTrades(
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

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetHistoricalQuoteTradesResponse>(response);
                return responseObject.Data;
            }

            return MakeErrorMessage<GetHistoricalQuoteTradesResponse>(response);
        }
    }
}