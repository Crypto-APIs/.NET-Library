using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Exchanges.Rates
{
    internal partial class ExchangeRatesModules : BaseModule, IExchangeRatesModules
    {
        public ExchangeRatesModules(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}