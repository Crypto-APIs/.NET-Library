using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.Modules.Exchanges.Info;
using CryptoApisSdkLibrary.Modules.Exchanges.Ohlcv;
using CryptoApisSdkLibrary.Modules.Exchanges.OrderBook;
using CryptoApisSdkLibrary.Modules.Exchanges.Rates;
using CryptoApisSdkLibrary.Modules.Exchanges.Trades;
using RestSharp;

namespace CryptoApisSdkLibrary.Modules.Exchanges
{
    internal class ExchangeModules : IExchangeModules
    {
        public ExchangeModules(IRestClient client, CryptoApiRequest request)
        {
            _info = new ExchangeInfoModules(client, request);
            _rates = new ExchangeRatesModules(client, request);
            _ohlcv = new ExchangeOhlcvModules(client, request);
            _trades = new ExchangeTradesModules(client, request);
            _orderBook = new ExchangeOrderBookModules(client, request);
        }

        public void SetResponseRequestLogger(IResponseRequestLogger logger)
        {
            _info.SetResponseRequestLogger(logger);
            _rates.SetResponseRequestLogger(logger);
            _ohlcv.SetResponseRequestLogger(logger);
            _trades.SetResponseRequestLogger(logger);
            _orderBook.SetResponseRequestLogger(logger);
        }

        public IExchangeInfoModules Info => _info;
        public IExchangeRatesModules Rates => _rates;
        public IExchangeOhlcvModules Ohlcv => _ohlcv;
        public IExchangeTradesModules Trades => _trades;
        public IExchangeOrderBookModules OrderBook => _orderBook;

        private readonly ExchangeInfoModules _info;
        private readonly ExchangeRatesModules _rates;
        private readonly ExchangeOhlcvModules _ohlcv;
        private readonly ExchangeTradesModules _trades;
        private readonly ExchangeOrderBookModules _orderBook;
    }
}