using CryptoApisLibrary.Misc;
using CryptoApisLibrary.Modules.Exchanges.Info;
using CryptoApisLibrary.Modules.Exchanges.Ohlcv;
using CryptoApisLibrary.Modules.Exchanges.OrderBook;
using CryptoApisLibrary.Modules.Exchanges.Rates;
using CryptoApisLibrary.Modules.Exchanges.Trades;
using RestSharp;

namespace CryptoApisLibrary.Modules.Exchanges
{
    internal class TradeModules : ITradeModules
    {
        public TradeModules(IRestClient client, CryptoApiRequest request)
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