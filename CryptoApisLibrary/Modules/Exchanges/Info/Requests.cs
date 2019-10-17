using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.Misc;
using RestSharp;
using System;

namespace CryptoApisLibrary.Modules.Exchanges.Info
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
                throw new ArgumentNullException($"{nameof(asset)}.{nameof(asset.Id)}");
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
                throw new ArgumentNullException($"{nameof(asset1)}.{nameof(asset1.Id)}");
            if (asset2 == null)
                throw new ArgumentNullException(nameof(asset2));
            if (string.IsNullOrEmpty(asset2.Id))
                throw new ArgumentNullException($"{nameof(asset2)}.{nameof(asset2.Id)}");
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
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");
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
                throw new ArgumentNullException($"{nameof(asset)}.{nameof(asset.Id)}");

            var request = Request.Get($"assets/{asset.Id}");

            return request;
        }

        public IRestRequest SymbolDetails(Symbol symbol)
        {
            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(symbol.Id))
                throw new ArgumentNullException($"{nameof(symbol)}.{nameof(symbol.Id)}");

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
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");

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

        private CryptoApiRequest Request { get; }
    }
}