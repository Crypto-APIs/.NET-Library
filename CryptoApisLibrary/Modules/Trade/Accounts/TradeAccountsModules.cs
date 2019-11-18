using CryptoApisLibrary.Misc;
using RestSharp;

namespace CryptoApisLibrary.Modules.Trade.Accounts
{
    internal partial class TradeAccountsModules : BaseModule, ITradeAccountsModules
    {
        public TradeAccountsModules(IRestClient client, CryptoApiRequest request)
            : base(client, request)
        {
            Requests = new Requests(Request);
        }

        private Requests Requests { get; }
    }
}