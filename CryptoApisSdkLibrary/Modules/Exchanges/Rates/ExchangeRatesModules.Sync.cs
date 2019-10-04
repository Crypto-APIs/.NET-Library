using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;

namespace CryptoApisSdkLibrary.Modules.Exchanges.Rates
{
    internal partial class ExchangeRatesModules
    {
        public ExchangeRateResponse ExchangeRate(Asset baseAsset, Asset quoteAsset)
        {
            return ExchangeRateAsync(CancellationToken.None, baseAsset, quoteAsset).GetAwaiter().GetResult();
        }

        public ExchangeRateResponse ExchangeRate(Asset baseAsset, Asset quoteAsset, DateTime timeStamp)
        {
            return ExchangeRateAsync(CancellationToken.None, baseAsset, quoteAsset, timeStamp).GetAwaiter().GetResult();
        }

        public ExchangeRatesResponse ExchangeRates(Asset baseAsset, int skip = 0, int limit = 50)
        {
            return ExchangeRatesAsync(CancellationToken.None, baseAsset, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangeRatesResponse ExchangeRates(Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50)
        {
            return ExchangeRatesAsync(CancellationToken.None, baseAsset, timeStamp, skip, limit).GetAwaiter().GetResult();
        }

        public CurrentRateInExchangeResponse ExchangeRate(Asset baseAsset, Asset quoteAsset, Exchange exchange)
        {
            return ExchangeRateAsync(CancellationToken.None, baseAsset, quoteAsset, exchange).GetAwaiter().GetResult();
        }

        public CurrentRateInExchangeResponse ExchangeRate(Asset baseAsset, Asset quoteAsset, Exchange exchange, DateTime timeStamp)
        {
            return ExchangeRateAsync(CancellationToken.None, baseAsset, quoteAsset,
                exchange, timeStamp).GetAwaiter().GetResult();
        }

        public CurrentRatesInExchangeResponse ExchangeRates(Asset baseAsset, Exchange exchange,
            int skip = 0, int limit = 50)
        {
            return ExchangeRatesAsync(CancellationToken.None, baseAsset,
                exchange, skip, limit).GetAwaiter().GetResult();
        }

        public CurrentRatesInExchangeResponse ExchangeRates(Asset baseAsset, Exchange exchange,
            DateTime timeStamp, int skip = 0, int limit = 50)
        {
            return ExchangeRatesAsync(CancellationToken.None, baseAsset,
                exchange, timeStamp, skip, limit).GetAwaiter().GetResult();
        }
    }
}