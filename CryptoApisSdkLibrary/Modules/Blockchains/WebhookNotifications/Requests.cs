using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.RequestTypes;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Blockchains.WebhookNotifications
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest CreateNewBlock(BtcSimilarCoin coin, BtcSimilarNetwork network, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateWebHookRequest("NEW_BLOCK", url));
        }

        public IRestRequest CreateNewBlock(EthSimilarCoin coin, EthSimilarNetwork network, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateWebHookRequest("NEW_BLOCK", url));
        }

        public IRestRequest CreateConfirmedTransaction(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string url,
            string transactionHash, int confirmationCount)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrEmpty(transactionHash))
                throw new ArgumentNullException(nameof(transactionHash));
            if (confirmationCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(confirmationCount), confirmationCount, "ConfirmationCount is negative or zero");

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateConfirmedTransactionRequest("CONFIRMED_TX", url, confirmationCount, transactionHash));
        }

        public IRestRequest CreateConfirmedTransaction(
            EthSimilarCoin coin, EthSimilarNetwork network, string url, string transactionHash, int confirmationCount)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrEmpty(transactionHash))
                throw new ArgumentNullException(nameof(transactionHash));
            if (confirmationCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(confirmationCount), confirmationCount, "ConfirmationCount is negative or zero");

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateConfirmedTransactionRequest("CONFIRMED_TX", url, confirmationCount, transactionHash));
        }

        public IRestRequest CreateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string url, string address)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateAddressRequest("ADDRESS", url, address));
        }

        public IRestRequest CreateAddress(EthSimilarCoin coin, EthSimilarNetwork network, string url, string address)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateAddressRequest("ADDRESS", url, address));
        }

        public IRestRequest CreateToken(EthSimilarCoin coin, EthSimilarNetwork network, string url, string address)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateAddressRequest("TOKEN", url, address));
        }

        public IRestRequest CreateTransactionPool(EthSimilarCoin coin, EthSimilarNetwork network, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateWebHookRequest("TXPOOL", url));
        }

        public IRestRequest GetHooks(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/hooks");
        }

        public IRestRequest GetHooks(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/hooks");
        }

        public IRestRequest Delete(BtcSimilarCoin coin, BtcSimilarNetwork network, string hookId)
        {
            if (string.IsNullOrEmpty(hookId))
                throw new ArgumentNullException(nameof(hookId));

            return Request.Delete($"{Consts.Blockchain}/{coin}/{network}/hooks/{hookId}");
        }

        public IRestRequest Delete(EthSimilarCoin coin, EthSimilarNetwork network, string hookId)
        {
            if (string.IsNullOrEmpty(hookId))
                throw new ArgumentNullException(nameof(hookId));

            return Request.Delete($"{Consts.Blockchain}/{coin}/{network}/hooks/{hookId}");
        }

        private CryptoApiRequest Request { get; }
    }
}