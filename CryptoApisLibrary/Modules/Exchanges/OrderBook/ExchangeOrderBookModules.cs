using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Exchanges.OrderBook
{
    internal partial class ExchangeOrderBookModules : BaseModule, IExchangeOrderBookModules
    {
        public ExchangeOrderBookModules(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}