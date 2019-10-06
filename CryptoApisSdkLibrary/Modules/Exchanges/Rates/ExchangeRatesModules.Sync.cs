using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;

namespace CryptoApisSdkLibrary.Modules.Exchanges.Rates
{
    internal partial class ExchangeRatesModules
    {
        public ExchangeRateResponse GetOne(Asset baseAsset, Asset quoteAsset)
        {
            return GetOneAsync(CancellationToken.None, baseAsset, quoteAsset).GetAwaiter().GetResult();
        }

        public ExchangeRateResponse GetOne(Asset baseAsset, Asset quoteAsset, DateTime timeStamp)
        {
            return GetOneAsync(CancellationToken.None, baseAsset, quoteAsset, timeStamp).GetAwaiter().GetResult();
        }

        public ExchangeRatesResponse GetAny(Asset baseAsset, int skip = 0, int limit = 50)
        {
            return GetAnyAsync(CancellationToken.None, baseAsset, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangeRatesResponse GetAny(Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50)
        {
            return GetAnyAsync(CancellationToken.None, baseAsset, timeStamp, skip, limit).GetAwaiter().GetResult();
        }

        public CurrentRateInExchangeResponse GetOne(Asset baseAsset, Asset quoteAsset, Exchange exchange)
        {
            return GetOneAsync(CancellationToken.None, baseAsset, quoteAsset, exchange).GetAwaiter().GetResult();
        }

        public CurrentRateInExchangeResponse GetOne(Asset baseAsset, Asset quoteAsset, Exchange exchange, DateTime timeStamp)
        {
            return GetOneAsync(CancellationToken.None, baseAsset, quoteAsset,
                exchange, timeStamp).GetAwaiter().GetResult();
        }

        public CurrentRatesInExchangeResponse GetAny(Asset baseAsset, Exchange exchange,
            int skip = 0, int limit = 50)
        {
            return GetAnyAsync(CancellationToken.None, baseAsset,
                exchange, skip, limit).GetAwaiter().GetResult();
        }

        public CurrentRatesInExchangeResponse GetAny(Asset baseAsset, Exchange exchange,
            DateTime timeStamp, int skip = 0, int limit = 50)
        {
            return GetAnyAsync(CancellationToken.None, baseAsset,
                exchange, timeStamp, skip, limit).GetAwaiter().GetResult();
        }
    }
}