using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Trade.Private
{
    internal partial class TradePrivateModules : BaseModule, ITradePrivateModules
    {
        public TradePrivateModules(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}