using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.ResponseTypes;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CryptoApisSdkLibrary.Modules
{
    internal class InfoModule : BaseModule, IInfoModule
    {
        public InfoModule(IRestClient client, CryptoApiRequest request) : base(client, request)
        {
        }

        public IEnumerable<Exchange> GetAllExchanges(out string errorMessage, int skip = 0, int limit = 100)
        {
            var request = Request.Get("exchanges");
            request.AddQueryParameter("skip", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            var result = Enumerable.Empty<Exchange>();

            var response = Client.Execute(request);
            if (response.IsSuccessful)
            {
                errorMessage = response.ErrorMessage;
                var responseObject = Client.Deserialize<GetAllExchangesResponse>(response);
                result = responseObject.Data.Exchange;
            }
            else
            {
                var responseObject = Client.Deserialize<ErrorResponse>(response);
                errorMessage = responseObject.Data.Meta.Error.Message;
            }

            return result;
        }

        public IEnumerable<Asset> GetAllAssets(out string errorMessage, int skip = 0, int limit = 100)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Symbol> GetAllSymbols(out string errorMessage, int skip = 0, int limit = 100)
        {
            throw new NotImplementedException();
        }

        public ExchangeRate GetExchangeRate(out string errorMessage, Asset baseAsset, Asset quoteAsset)
        {
            return InternalGetExchangeRate(out errorMessage, baseAsset, quoteAsset);
        }

        public ExchangeRate GetExchangeRate(out string errorMessage, Asset baseAsset, Asset quoteAsset, DateTime timeStamp)
        {
            return InternalGetExchangeRate(out errorMessage, baseAsset, quoteAsset, timeStamp);
        }

        public IEnumerable<ExchangeRate> GetCurrentRates(out string errorMessage, Asset baseAsset, DateTime timeStamp, int skip = 0,
            int limit = 100)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PeriodInfo> GetPeriodsInfo(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OHLCV> GetLatestData(out string errorMessage, Symbol symbol, Period period, int limit = 100)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OHLCV> GetHistoricalData(out string errorMessage, Symbol symbol, Period period, DateTime startPeriod,
            DateTime? endPeriod = null, int limit = 100)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trade> GetAllLatestTrades(out string errorMessage, int limit = 100)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trade> GetLatestTrades(out string errorMessage, Symbol symbol, int limit = 100)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trade> GetHistoricalTrades(out string errorMessage, Symbol symbol)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trade> GetHistoricalTrades(out string errorMessage, Symbol symbol, DateTime startPeriod)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trade> GetHistoricalTrades(out string errorMessage, Symbol symbol, DateTime startPeriod, DateTime endPeriod)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuoteTrade> GetAllLatestQuoteTrades(out string errorMessage, int limit = 100)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuoteTrade> GetHistoricalQuoteTrades(out string errorMessage, Symbol symbol)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuoteTrade> GetHistoricalQuoteTrades(out string errorMessage, Symbol symbol, DateTime startPeriod)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuoteTrade> GetHistoricalQuoteTrades(out string errorMessage, Symbol symbol, DateTime startPeriod, DateTime endPeriod)
        {
            throw new NotImplementedException();
        }

        private ExchangeRate InternalGetExchangeRate(out string errorMessage, Asset baseAsset, Asset quoteAsset,
            DateTime? timeStamp = null)
        {
            var request = Request.Get($"exchange-rates/{baseAsset}/{quoteAsset}");
            if (timeStamp.HasValue)
            {
                var unixTimestamp = (int)timeStamp.Value.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
                var timeStampAsString = unixTimestamp.ToString(CultureInfo.InvariantCulture);
                request.AddQueryParameter("timestamp", timeStampAsString);
            }

            var response = Client.Execute(request);
            if (!response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<ErrorResponse>(response);
                errorMessage = responseObject.Data.Meta.Error.Message;
                return null;
            }
            else
            {
                errorMessage = response.ErrorMessage;
                var responseObject = Client.Deserialize<ExchangeRateResponse>(response);
                return responseObject.Data.ExchangeRate;
            }
        }
    }
}