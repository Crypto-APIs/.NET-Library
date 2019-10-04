using CryptoApisSdkLibrary.Misc;
using RestSharp;

namespace CryptoApisSdkLibrary.Modules.Exchanges.Trades
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