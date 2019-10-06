using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Exchanges.Rates
{
    public interface IExchangeRatesModules
    {
        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a current time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <returns>Response with exchange rate.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate"/>
        ExchangeRateResponse GetOne(Asset baseAsset, Asset quoteAsset);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a current time.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <returns>Response with exchange rate.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate"/>
        Task<ExchangeRateResponse> GetOneAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <returns>Response with exchange rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate"/>
        ExchangeRateResponse GetOne(Asset baseAsset, Asset quoteAsset, DateTime timeStamp);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific time.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <returns>Response with exchange rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate"/>
        Task<ExchangeRateResponse> GetOneAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, DateTime timeStamp);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets at a current time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates"/>
        ExchangeRatesResponse GetAny(Asset baseAsset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets at a current time.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates"/>
        Task<ExchangeRatesResponse> GetAnyAsync(CancellationToken cancellationToken,
            Asset baseAsset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets at a specific time.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates"/>
        ExchangeRatesResponse GetAny(Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets at a specific time.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates"/>
        Task<ExchangeRatesResponse> GetAnyAsync(CancellationToken cancellationToken,
            Asset baseAsset, DateTime timeStamp, int skip = 0, int limit = 50);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific or current time in a specific Exchange.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <returns>Response with current rate.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate-in-a-specific-exchange"/>
        CurrentRateInExchangeResponse GetOne(Asset baseAsset, Asset quoteAsset, Exchange exchange);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific or current time in a specific Exchange.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <returns>Response with current rate.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate-in-a-specific-exchange"/>
        Task<CurrentRateInExchangeResponse> GetOneAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, Exchange exchange);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific or current time in a specific Exchange.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <returns>Response with current rate.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate-in-a-specific-exchange"/>
        CurrentRateInExchangeResponse GetOne(Asset baseAsset, Asset quoteAsset, Exchange exchange, DateTime timeStamp);

        /// <summary>
        /// Get exchange rates between pair of requested assets pointing at a specific or current time in a specific Exchange.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <returns>Response with current rate.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-specific-rate-in-a-specific-exchange"/>
        Task<CurrentRateInExchangeResponse> GetOneAsync(CancellationToken cancellationToken,
            Asset baseAsset, Asset quoteAsset, Exchange exchange, DateTime timeStamp);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets in a specific Exchange.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates-in-a-specific-exchange"/>
        CurrentRatesInExchangeResponse GetAny(Asset baseAsset, Exchange exchange, int skip = 0, int limit = 50);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets in a specific Exchange.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates-in-a-specific-exchange"/>
        Task<CurrentRatesInExchangeResponse> GetAnyAsync(CancellationToken cancellationToken,
            Asset baseAsset, Exchange exchange, int skip = 0, int limit = 50);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets in a specific Exchange.
        /// </summary>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates-in-a-specific-exchange"/>
        CurrentRatesInExchangeResponse GetAny(Asset baseAsset, Exchange exchange, DateTime timeStamp, int skip = 0, int limit = 50);

        /// <summary>
        /// Get the current exchange rate between requested asset and all other assets in a specific Exchange.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="timeStamp">Time (in UNIX Timestamp) of the market data used to calculate exchange rate.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with current rates.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-all-current-rates-in-a-specific-exchange"/>
        Task<CurrentRatesInExchangeResponse> GetAnyAsync(CancellationToken cancellationToken,
            Asset baseAsset, Exchange exchange, DateTime timeStamp, int skip = 0, int limit = 50);
    }
}