using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Exchanges.Info
{
    internal partial class ExchangeInfoModules : BaseModule, IExchangeInfoModules
    {
        public ExchangeInfoModules(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}