using System.Threading;
using System.Threading.Tasks;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;

namespace CryptoApisLibrary.Modules.Exchanges.Info
{
    public interface IExchangeInfoModules
    {
        /// <summary>
        /// Get detailed list of all supported exchanges provided by our system.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-exchanges"/>
        ExchangesMetaResponse ExchangesMeta(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all supported exchanges provided by our system.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-exchanges"/>
        Task<ExchangesMetaResponse> ExchangesMetaAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of exchanges and symbols which support the given assets as base/quote or quote/base.
        /// </summary>
        /// <param name="asset">Asset.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with exchange collection by supporting assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-exchanges-by-supporting-assets"/>
        ExchangesSupportingAssetResponse ExchangesSupportingAsset(Asset asset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of exchanges and symbols which support the given assets as base/quote or quote/base.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="asset">Asset.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with exchange collection by supporting assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-exchanges-by-supporting-assets"/>
        Task<ExchangesSupportingAssetResponse> ExchangesSupportingAssetAsync(CancellationToken cancellationToken,
            Asset asset, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of exchanges and symbols which support the given assets as base/quote or quote/base.
        /// </summary>
        /// <param name="asset1">First asset.</param>
        /// <param name="asset2">Second asset.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with exchange collection by supporting pairs.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-exchanges-by-supporting-pairs"/>
        ExchangesAssetsResponse ExchangesSupportingPairs(Asset asset1, Asset asset2, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of exchanges and symbols which support the given assets as base/quote or quote/base.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="asset1">First asset.</param>
        /// <param name="asset2">Second asset.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with exchange collection by supporting pairs.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-exchanges-by-supporting-pairs"/>
        Task<ExchangesAssetsResponse> ExchangesSupportingPairsAsync(CancellationToken cancellationToken,
            Asset asset1, Asset asset2, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of symbols which are supported in the given exchange..
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with symbol collection by supporting exchange.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-symbols-supported-in-exchange"/>
        ExchangesAssetsResponse SymbolsInExchange(Exchange exchange, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of symbols which are supported in the given exchange.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with symbol collection by supporting exchange.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-symbols-supported-in-exchange"/>
        Task<ExchangesAssetsResponse> SymbolsInExchangeAsync(CancellationToken cancellationToken,
            Exchange exchange, int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of all associated assets.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-assets"/>
        AssetsMetaResponse AssetsMeta(int skip = 0, int limit = 50);

        /// <summary>
        /// Get a list of all associated assets.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-assets"/>
        Task<AssetsMetaResponse> AssetsMetaAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all symbol mappings.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported symbols.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-symbols"/>
        SymbolsResponse Symbols(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all symbol mappings.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported symbols.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-symbols"/>
        Task<SymbolsResponse> SymbolsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all supported exchanges provided by our system.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-exchanges-base-data"/>
        ExchangesResponse Exchanges(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all supported exchanges provided by our system.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-exchanges-base-data"/>
        Task<ExchangesResponse> ExchangesAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get a detailed information for a single supported exchange provided by our system by ID.
        /// </summary>
        /// <param name="exchange">Exchange.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-exchange-details"/>
        ExchangeDetailsResponse ExchangeDetails(Exchange exchange);

        /// <summary>
        /// Get a detailed information for a single supported exchange provided by our system by ID.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="exchange">Exchange.</param>
        /// <returns>Response with collection of supported exchanges.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-exchange-details"/>
        Task<ExchangeDetailsResponse> ExchangeDetailsAsync(CancellationToken cancellationToken, Exchange exchange);

        /// <summary>
        /// Get detailed list of all associated assets.
        /// </summary>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-assets-base-data"/>
        AssetsResponse Assets(int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed list of all associated assets.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        /// <returns>Response with collection of supported assets.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#list-all-assets-base-data"/>
        Task<AssetsResponse> AssetsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Get detailed information for a specific asset.
        /// </summary>
        /// <param name="asset">Asset.</param>
        /// <returns>Response with details of asset.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-asset-details"/>
        AssetDetailsResponse AssetDetails(Asset asset);

        /// <summary>
        /// Get detailed information for a specific asset.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="asset">Asset.</param>
        /// <returns>Response with details of asset.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-asset-details"/>
        Task<AssetDetailsResponse> AssetDetailsAsync(CancellationToken cancellationToken, Asset asset);

        /// <summary>
        /// Get detailed information for a specific asset.
        /// </summary>
        /// <param name="symbol">Symbol.</param>
        /// <returns>Response with details of symbol.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-asset-details"/>
        SymbolDetailsResponse SymbolDetails(Symbol symbol);

        /// <summary>
        /// Get detailed information for a specific asset.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="symbol">Symbol.</param>
        /// <returns>Response with details of symbol.</returns>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/crypto-market-data-apis/index#get-asset-details"/>
        Task<SymbolDetailsResponse> SymbolDetailsAsync(CancellationToken cancellationToken, Symbol symbol);
    }
}