using CryptoApisSdkLibrary.Misc;
using RestSharp;

namespace CryptoApisSdkLibrary.Modules.Exchanges.OrderBook
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