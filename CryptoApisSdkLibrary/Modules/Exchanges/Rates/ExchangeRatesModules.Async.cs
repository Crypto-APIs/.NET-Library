using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Exchanges.Rates
{
    internal partial class ExchangeRatesModules
    {
        public Task<ExchangeRateResponse> ExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset)
        {
            var request = Requests.ExchangeRate(baseAsset, quoteAsset, timeStamp: null);
            return GetAsyncResponse<ExchangeRateResponse>(request, cancellationToken);
        }

        public Task<ExchangeRateResponse> ExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, DateTime timeStamp)
        {
            var request = Requests.ExchangeRate(baseAsset, quoteAsset, timeStamp);
            return GetAsyncResponse<ExchangeRateResponse>(request, cancellationToken);
        }

        public Task<ExchangeRatesResponse> ExchangeRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangeRates(baseAsset, null, skip, limit);
            return GetAsyncResponse<ExchangeRatesResponse>(request, cancellationToken);
        }

        public Task<ExchangeRatesResponse> ExchangeRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangeRates(baseAsset, timeStamp, skip, limit);
            return GetAsyncResponse<ExchangeRatesResponse>(request, cancellationToken);
        }

        public Task<CurrentRateInExchangeResponse> ExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, Exchange exchange)
        {
            var request = Requests.ExchangeRate(baseAsset, quoteAsset, exchange, null);
            return GetAsyncResponse<CurrentRateInExchangeResponse>(request, cancellationToken);
        }

        public Task<CurrentRateInExchangeResponse> ExchangeRateAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, Exchange exchange, DateTime timeStamp)
        {
            var request = Requests.ExchangeRate(baseAsset, quoteAsset, exchange, timeStamp);
            return GetAsyncResponse<CurrentRateInExchangeResponse>(request, cancellationToken);
        }

        public Task<CurrentRatesInExchangeResponse> ExchangeRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, Exchange exchange, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangeRates(baseAsset, exchange, null, skip, limit);
            return GetAsyncResponse<CurrentRatesInExchangeResponse>(request, cancellationToken);
        }

        public Task<CurrentRatesInExchangeResponse> ExchangeRatesAsync(CancellationToken cancellationToken,
            Asset baseAsset, Exchange exchange, DateTime timeStamp, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangeRates(baseAsset, exchange, timeStamp, skip, limit);
            return GetAsyncResponse<CurrentRatesInExchangeResponse>(request, cancellationToken);
        }
    }
}