using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Exchanges.Rates
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
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
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");

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
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");
            return ExchangeRates(baseAsset, timeStamp, skip, limit,
                () => $"exchange-rates/exchange/{exchange.Id}/{baseAsset.Id}");
        }

        private IRestRequest ExchangeRates(Asset baseAsset, DateTime? timeStamp, int skip, int limit, Func<string> url)
        {
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.Id))
                throw new ArgumentNullException($"{nameof(baseAsset)}.{nameof(baseAsset.Id)}");
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
                throw new ArgumentNullException($"{nameof(baseAsset)}.{nameof(baseAsset.Id)}");
            if (quoteAsset == null)
                throw new ArgumentNullException(nameof(quoteAsset));
            if (string.IsNullOrEmpty(quoteAsset.Id))
                throw new ArgumentNullException($"{nameof(quoteAsset)}.{nameof(quoteAsset.Id)}");

            var request = Request.Get(url.Invoke());
            if (timeStamp.HasValue)
            {
                request.AddQueryParameter("timestamp", Tools.ToUnixTimestamp(timeStamp.Value));
            }

            return request;
        }


        private CryptoApiRequest Request { get; }
    }
}