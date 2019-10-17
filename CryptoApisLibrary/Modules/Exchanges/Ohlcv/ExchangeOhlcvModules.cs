using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Exchanges.Ohlcv
{
    internal partial class ExchangeOhlcvModules : BaseModule, IExchangeOhlcvModules
    {
        public ExchangeOhlcvModules(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}