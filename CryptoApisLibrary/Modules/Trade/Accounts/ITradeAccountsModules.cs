using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Trades;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Trade.Accounts
{
    public interface ITradeAccountsModules
    {
        /// <summary>
        /// Create an account for Trading APIs.
        /// </summary>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/trading-apis/exchange-accounts/index#create-account"/>
        CreateAccountResponse Create(Exchange exchange, string apiKey, string secret, string password, string uid);

        /// <summary>
        /// Create an account for Trading APIs.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/trading-apis/exchange-accounts/index#create-account"/>
        Task<CreateAccountResponse> CreateAsync(CancellationToken cancellationToken,
            Exchange exchange, string apiKey, string secret, string password, string uid);

        /// <summary>
        /// Show account balance for a given exchange.
        /// </summary>
        /// <param name="account">Account.</param>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/trading-apis/exchange-accounts/index#get-account"/>
        GetAccountResponse GetOne(Account account);

        /// <summary>
        /// Show account balance for a given exchange.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="account">Account.</param>
        /// <see cref="http://docs.cryptoapis.io/rest-apis/trading-apis/exchange-accounts/index#get-account"/>
        Task<GetAccountResponse> GetOneAsync(CancellationToken cancellationToken, Account account);
    }
}