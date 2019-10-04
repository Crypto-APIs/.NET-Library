using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.DataTypes.Exceptions;
using CryptoApisSdkLibrary.Misc;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Exchanges.OrderBook
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest OrderBook(Exchange exchange, Asset baseAsset, Asset quoteAsset)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.ExchangeId))
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");
            if (baseAsset == null)
                throw new ArgumentNullException(nameof(baseAsset));
            if (string.IsNullOrEmpty(baseAsset.AssetId))
                throw new ArgumentNullException($"{nameof(baseAsset)}.{nameof(baseAsset.Id)}");
            if (quoteAsset == null)
                throw new ArgumentNullException(nameof(quoteAsset));
            if (string.IsNullOrEmpty(quoteAsset.AssetId))
                throw new ArgumentNullException($"{nameof(quoteAsset)}.{nameof(quoteAsset.Id)}");

            var request = Request.Get($"{Consts.OrderBook}/{exchange.ExchangeId}_SPOT_{baseAsset.AssetId}_{quoteAsset.AssetId}");

            return request;
        }


        private CryptoApiRequest Request { get; }
    }
}