using CryptoApisSdkLibrary.Modules.Exchanges.Info;
using CryptoApisSdkLibrary.Modules.Exchanges.Ohlcv;
using CryptoApisSdkLibrary.Modules.Exchanges.OrderBook;
using CryptoApisSdkLibrary.Modules.Exchanges.Rates;
using CryptoApisSdkLibrary.Modules.Exchanges.Trades;

namespace CryptoApisSdkLibrary.Modules.Exchanges
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