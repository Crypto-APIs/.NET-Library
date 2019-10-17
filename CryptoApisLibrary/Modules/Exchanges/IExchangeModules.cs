using CryptoApisLibrary.Modules.Exchanges.Info;
using CryptoApisLibrary.Modules.Exchanges.Ohlcv;
using CryptoApisLibrary.Modules.Exchanges.OrderBook;
using CryptoApisLibrary.Modules.Exchanges.Rates;
using CryptoApisLibrary.Modules.Exchanges.Trades;

namespace CryptoApisLibrary.Modules.Exchanges
{
    public interface IExchangeModules
    {
        IExchangeInfoModules Info { get; }
        IExchangeRatesModules Rates { get; }
        IExchangeOhlcvModules Ohlcv { get; }
        IExchangeTradesModules Trades { get; }
        IExchangeOrderBookModules OrderBook { get; }
    }
}