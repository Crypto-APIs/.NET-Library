using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;
using System.Threading;

namespace CryptoApisLibrary.Modules.Exchanges.Info
{
    internal partial class ExchangeInfoModules
    {
        public ExchangesMetaResponse ExchangesMeta(int skip = 0, int limit = 50)
        {
            return ExchangesMetaAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangesSupportingAssetResponse ExchangesSupportingAsset(Asset asset, int skip = 0, int limit = 50)
        {
            return ExchangesSupportingAssetAsync(CancellationToken.None, asset, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangesAssetsResponse ExchangesSupportingPairs(Asset asset1, Asset asset2, int skip = 0, int limit = 50)
        {
            return ExchangesSupportingPairsAsync(CancellationToken.None, asset1, asset2, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangesAssetsResponse SymbolsInExchange(Exchange exchange, int skip = 0, int limit = 50)
        {
            return SymbolsInExchangeAsync(CancellationToken.None, exchange, skip, limit).GetAwaiter().GetResult();
        }

        public AssetsMetaResponse AssetsMeta(int skip = 0, int limit = 50)
        {
            return AssetsMetaAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public AssetsResponse Assets(int skip = 0, int limit = 50)
        {
            return AssetsAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public AssetDetailsResponse AssetDetails(Asset asset)
        {
            return AssetDetailsAsync(CancellationToken.None, asset).GetAwaiter().GetResult();
        }

        public SymbolDetailsResponse SymbolDetails(Symbol symbol)
        {
            return SymbolDetailsAsync(CancellationToken.None, symbol).GetAwaiter().GetResult();
        }

        public SymbolsResponse Symbols(int skip = 0, int limit = 50)
        {
            return SymbolsAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangesResponse Exchanges(int skip = 0, int limit = 50)
        {
            return ExchangesAsync(CancellationToken.None, skip, limit).GetAwaiter().GetResult();
        }

        public ExchangeDetailsResponse ExchangeDetails(Exchange exchange)
        {
            return ExchangeDetailsAsync(CancellationToken.None, exchange).GetAwaiter().GetResult();
        }
    }
}