using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.Misc;
using CryptoApisLibrary.RequestTypes;
using RestSharp;
using System;

namespace CryptoApisLibrary.Modules.Blockchains.WebhookNotifications
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest CreateNewBlock(NetworkCoin networkCoin, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/hooks",
                new CreateWebHookRequest("NEW_BLOCK", url));
        }

        public IRestRequest CreateConfirmedTransaction(NetworkCoin networkCoin, string url,
            string transactionHash, int confirmationCount)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrEmpty(transactionHash))
                throw new ArgumentNullException(nameof(transactionHash));
            if (confirmationCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(confirmationCount), confirmationCount, "ConfirmationCount is negative or zero");

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/hooks",
                new CreateConfirmedTransactionRequest("CONFIRMED_TX", url, confirmationCount, transactionHash));
        }

        public IRestRequest CreateAddress(NetworkCoin networkCoin, string url, string address)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/hooks",
                new CreateAddressRequest("ADDRESS", url, address));
        }

        public IRestRequest CreateToken(NetworkCoin networkCoin, string url, string address)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/hooks",
                new CreateAddressRequest("TOKEN", url, address));
        }

        public IRestRequest CreateTransactionPool(NetworkCoin networkCoin, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/hooks",
                new CreateWebHookRequest("TXPOOL", url));
        }

        public IRestRequest GetHooks(NetworkCoin networkCoin)
        {
            return Request.Get($"{Consts.Blockchain}/{networkCoin}/hooks");
        }

        public IRestRequest Delete(NetworkCoin networkCoin, string hookId)
        {
            if (string.IsNullOrEmpty(hookId))
                throw new ArgumentNullException(nameof(hookId));

            return Request.Delete($"{Consts.Blockchain}/{networkCoin}/hooks/{hookId}");
        }

        private CryptoApiRequest Request { get; }
    }
}