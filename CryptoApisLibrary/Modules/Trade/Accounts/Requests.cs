using System;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.Misc;
using CryptoApisLibrary.RequestTypes;
using RestSharp;

namespace CryptoApisLibrary.Modules.Trade.Accounts
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest Create(Exchange exchange, string apiKey, string secret, string password, string uid)
        {
            if (exchange == null)
                throw new ArgumentNullException(nameof(exchange));
            if (string.IsNullOrEmpty(exchange.Id))
                throw new ArgumentNullException($"{nameof(exchange)}.{nameof(exchange.Id)}");
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException($"{nameof(apiKey)}");
            if (string.IsNullOrEmpty(secret))
                throw new ArgumentNullException($"{nameof(secret)}");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException($"{nameof(password)}");
            if (string.IsNullOrEmpty(uid))
                throw new ArgumentNullException($"{nameof(uid)}");

            var request = Request.Post("trading/exchange-accounts",
                new CreateAccountRequest(exchange.Id, apiKey, secret, password, uid));

            return request;
        }

        public IRestRequest GetOne(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));
            if (string.IsNullOrEmpty(account.Id))
                throw new ArgumentNullException($"{nameof(account)}.{nameof(account.Id)}");

            var request = Request.Get($"trading/exchange-accounts/{account.Id}");

            return request;
        }

        private CryptoApiRequest Request { get; }
    }
}