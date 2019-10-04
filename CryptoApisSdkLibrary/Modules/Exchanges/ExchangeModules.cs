using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.Modules.Exchanges.Info;
using CryptoApisSdkLibrary.Modules.Exchanges.Ohlcv;
using CryptoApisSdkLibrary.Modules.Exchanges.OrderBook;
using CryptoApisSdkLibrary.Modules.Exchanges.Rates;
using CryptoApisSdkLibrary.Modules.Exchanges.Trades;
using RestSharp;

namespace CryptoApisSdkLibrary.Modules.Exchanges
{
    internal class ExchangeModules : BaseModule, IExchangeModules
    {
        public ExchangeModules(IRestClient client, CryptoApiRequest request) : base(client, request)
        {
            Info = new ExchangeInfoModules(client, request);
            Rates = new ExchangeRatesModules(client, request);
            Ohlcv = new ExchangeOhlcvModules(client, request);
            Trades = new ExchangeTradesModules(client, request);
            OrderBook = new ExchangeOrderBookModules(client, request);
        }

        public IExchangeInfoModules Info { get; }
        public IExchangeRatesModules Rates { get; }
        public IExchangeOhlcvModules Ohlcv { get; }
        public IExchangeTradesModules Trades { get; }
        public IExchangeOrderBookModules OrderBook { get; }
    }
}