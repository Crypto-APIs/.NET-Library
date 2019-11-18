using System.Threading;
using System.Threading.Tasks;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;

namespace CryptoApisLibrary.Modules.Trade.Arbitrage
{
    public interface ITradeArbitrageModules
    {
        /// <summary>
        /// Get information about calls related to order book data, also known as books or passive level 2 data.
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <returns>Response with orderbook.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#order-book-snapshot-by-symbol"/>
        OrderBookResponse Get(Exchange exchange, Asset baseAsset, Asset quoteAsset);

        /// <summary>
        /// Get information about calls related to order book data, also known as books or passive level 2 data.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="baseAsset">FX Spot base asset identifier, for derivatives it’s contact underlying (e.g. Btc for Btc/USD).</param>
        /// <param name="quoteAsset">FX Spot quote asset identifier, for derivatives it’s contract underlying (e.g. USD for Btc/USD).</param>
        /// <returns>Response with orderbook.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#order-book-snapshot-by-symbol"/>
        Task<OrderBookResponse> GetAsync(CancellationToken cancellationToken,
            Exchange exchange, Asset baseAsset, Asset quoteAsset);
    }
}