using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Trade.Arbitrage
{
    internal partial class TradeArbitrageModules : BaseModule, ITradeArbitrageModules
    {
        public TradeArbitrageModules(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}