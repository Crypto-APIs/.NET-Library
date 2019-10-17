using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Exchanges.Trades
{
    internal partial class ExchangeTradesModules : BaseModule, IExchangeTradesModules
    {
        public ExchangeTradesModules(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}