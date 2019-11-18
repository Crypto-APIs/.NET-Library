using CryptoApisLibrary.Misc;
using CryptoApisLibrary.Modules.Trade.Accounts;
using CryptoApisLibrary.Modules.Trade.Arbitrage;
using CryptoApisLibrary.Modules.Trade.Private;
using RestSharp;

namespace CryptoApisLibrary.Modules.Trade
{
    internal class TradeModules : ITradeModules
    {
        public TradeModules(IRestClient client, CryptoApiRequest request)
        {
            _accounts = new TradeAccountsModules(client, request);
            _private = new TradePrivateModules(client, request);
            _arbitrage = new TradeArbitrageModules(client, request);
        }

        public void SetResponseRequestLogger(IResponseRequestLogger logger)
        {
            _accounts.SetResponseRequestLogger(logger);
            _private.SetResponseRequestLogger(logger);
            _arbitrage.SetResponseRequestLogger(logger);
        }

        public ITradeAccountsModules Accounts => _accounts;
        public ITradePrivateModules Private => _private;
        public ITradeArbitrageModules Arbitrage => _arbitrage;

        private readonly TradeAccountsModules _accounts;
        private readonly TradePrivateModules _private;
        private readonly TradeArbitrageModules _arbitrage;
    }
}