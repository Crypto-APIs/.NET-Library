using CryptoApisSdkLibrary.Misc;
using RestSharp;

namespace CryptoApisSdkLibrary.Modules.Exchanges.Ohlcv
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