using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Trades;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Trade.Accounts
{
    internal partial class TradeAccountsModules
    {
        public Task<CreateAccountResponse> CreateAsync(CancellationToken cancellationToken,
            Exchange exchange, string apiKey, string secret, string password, string uid)
        {
            var request = Requests.Create(exchange, apiKey, secret, password, uid);
            return GetAsyncResponse<CreateAccountResponse>(request, cancellationToken);
        }

        public Task<GetAccountResponse> GetOneAsync(CancellationToken cancellationToken, Account account)
        {
            var request = Requests.GetOne(account);
            return GetAsyncResponse<GetAccountResponse>(request, cancellationToken);
        }
    }
}