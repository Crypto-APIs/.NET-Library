using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Trades;
using System.Threading;

namespace CryptoApisLibrary.Modules.Trade.Accounts
{
    internal partial class TradeAccountsModules
    {
        public CreateAccountResponse Create(Exchange exchange, string apiKey, string secret, string password, string uid)
        {
            return CreateAsync(CancellationToken.None, exchange, apiKey, secret, password, uid).GetAwaiter().GetResult();
        }

        public GetAccountResponse GetOne(Account account)
        {
            return GetOneAsync(CancellationToken.None, account).GetAwaiter().GetResult();
        }
    }
}