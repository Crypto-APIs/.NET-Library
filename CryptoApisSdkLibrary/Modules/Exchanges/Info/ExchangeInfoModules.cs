using CryptoApisSdkLibrary.Misc;
using RestSharp;

namespace CryptoApisSdkLibrary.Modules.Exchanges.Info
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