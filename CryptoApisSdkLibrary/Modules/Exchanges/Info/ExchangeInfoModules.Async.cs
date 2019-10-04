using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Exchanges;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Exchanges.Info
{
    internal partial class ExchangeInfoModules
    {
        public Task<ExchangesMetaResponse> ExchangesMetaAsync(CancellationToken cancellationToken, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangesMeta(skip, limit);
            return GetAsyncResponse<ExchangesMetaResponse>(request, cancellationToken);
        }

        public Task<ExchangesAssetsResponse> ExchangesSupportingPairsAsync(CancellationToken cancellationToken,
            Asset asset1, Asset asset2, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangesSupportingPairs(asset1, asset2, skip, limit);
            return GetAsyncResponse<ExchangesAssetsResponse>(request, cancellationToken);
        }

        public Task<ExchangesAssetsResponse> SymbolsInExchangeAsync(CancellationToken cancellationToken,
            Exchange exchange, int skip = 0, int limit = 50)
        {
            var request = Requests.AllSymbolsInExchange(exchange, skip, limit);
            return GetAsyncResponse<ExchangesAssetsResponse>(request, cancellationToken);
        }

        public Task<AssetsMetaResponse> AssetsMetaAsync(CancellationToken cancellationToken, int skip = 0, int limit = 50)
        {
            var request = Requests.AssetsMeta(skip, limit);
            return GetAsyncResponse<AssetsMetaResponse>(request, cancellationToken);
        }

        public Task<ExchangesSupportingAssetResponse> ExchangesSupportingAssetAsync(CancellationToken cancellationToken,
            Asset asset, int skip = 0, int limit = 50)
        {
            var request = Requests.ExchangesSupportingAsset(asset, skip, limit);
            return GetAsyncResponse<ExchangesSupportingAssetResponse>(request, cancellationToken);
        }

        public Task<AssetsResponse> AssetsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50)
        {
            var request = Requests.Assets(skip, limit);
            return GetAsyncResponse<AssetsResponse>(request, cancellationToken);
        }

        public Task<AssetDetailsResponse> AssetDetailsAsync(CancellationToken cancellationToken, Asset asset)
        {
            var request = Requests.AssetDetails(asset);
            return GetAsyncResponse<AssetDetailsResponse>(request, cancellationToken);
        }

        public Task<SymbolDetailsResponse> SymbolDetailsAsync(CancellationToken cancellationToken, Symbol symbol)
        {
            var request = Requests.SymbolDetails(symbol);
            return GetAsyncResponse<SymbolDetailsResponse>(request, cancellationToken);
        }

        public Task<SymbolsResponse> SymbolsAsync(CancellationToken cancellationToken,
            int skip = 0, int limit = 50)
        {
            var request = Requests.Symbols(skip, limit);
            return GetAsyncResponse<SymbolsResponse>(request, cancellationToken);
        }

        public Task<ExchangesResponse> ExchangesAsync(
            CancellationToken cancellationToken, int skip = 0, int limit = 50)
        {
            var request = Requests.Exchanges(skip, limit);
            return GetAsyncResponse<ExchangesResponse>(request, cancellationToken);
        }

        public Task<ExchangeDetailsResponse> ExchangeDetailsAsync(CancellationToken cancellationToken, Exchange exchange)
        {
            var request = Requests.ExchangeDetails(exchange);
            return GetAsyncResponse<ExchangeDetailsResponse>(request, cancellationToken);
        }
    }
}