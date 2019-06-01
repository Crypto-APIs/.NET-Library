using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.RequestTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using RestSharp;
using System;

namespace CryptoApisSdkLibrary.Modules.Blockchains.WebhookNotifications
{
    internal class BlockchainWebhookNotificationModule : BaseModule, IBlockchainWebhookNotificationModule
    {
        public BlockchainWebhookNotificationModule(IRestClient client, CryptoApiRequest request) : base(client, request)
        {
        }

        public CreateBtcNewBlockWebHookResponse CreateNewBlock(BtcSimilarCoin coin, BtcSimilarNetwork network, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            var response = Client.Execute(Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateWebHookRequest("NEW_BLOCK", url)));

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateBtcNewBlockWebHookResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateBtcNewBlockWebHookResponse>(response);
        }

        public CreateEthWebHookResponse CreateNewBlock(EthSimilarCoin coin, EthSimilarNetwork network, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            var response = Client.Execute(Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateWebHookRequest("NEW_BLOCK", url)));

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateEthWebHookResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateEthWebHookResponse>(response);
        }

        public CreateBtcConfirmedTransactionWebHookResponse CreateConfirmedTransaction(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string url,
            string transactionHash, int confirmationCount)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrEmpty(transactionHash))
                throw new ArgumentNullException(nameof(transactionHash));
            if (confirmationCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(confirmationCount), confirmationCount, "ConfirmationCount is negative or zero");

            var response = Client.Execute(Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateConfirmedTransactionRequest("CONFIRMED_TX", url, confirmationCount, transactionHash)));

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateBtcConfirmedTransactionWebHookResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateBtcConfirmedTransactionWebHookResponse>(response);
        }

        public CreateEthConfirmedTransactionWebHookResponse CreateConfirmedTransaction(
            EthSimilarCoin coin, EthSimilarNetwork network, string url, string transactionHash, int confirmationCount)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrEmpty(transactionHash))
                throw new ArgumentNullException(nameof(transactionHash));
            if (confirmationCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(confirmationCount), confirmationCount, "ConfirmationCount is negative or zero");

            var response = Client.Execute(Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateConfirmedTransactionRequest("CONFIRMED_TX", url, confirmationCount, transactionHash)));

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateEthConfirmedTransactionWebHookResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateEthConfirmedTransactionWebHookResponse>(response);
        }

        public CreateBtcAddressWebHookResponse CreateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string url, string address)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            var response = Client.Execute(Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateAddressRequest("ADDRESS", url, address)));

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateBtcAddressWebHookResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateBtcAddressWebHookResponse>(response);
        }

        public CreateEthAddressWebHookResponse CreateAddress(EthSimilarCoin coin, EthSimilarNetwork network, string url, string address)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            var response = Client.Execute(Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateAddressRequest("ADDRESS", url, address)));

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateEthAddressWebHookResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateEthAddressWebHookResponse>(response);
        }

        public CreateEthAddressWebHookResponse CreateToken(EthSimilarCoin coin, EthSimilarNetwork network, string url, string address)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            var response = Client.Execute(Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateAddressRequest("TOKEN", url, address)));

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateEthAddressWebHookResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateEthAddressWebHookResponse>(response);
        }

        public CreateEthWebHookResponse CreateTransactionPool(EthSimilarCoin coin, EthSimilarNetwork network, string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            var response = Client.Execute(Request.Post($"{Consts.Blockchain}/{coin}/{network}/hooks",
                new CreateWebHookRequest("TXPOOL", url)));

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateEthWebHookResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateEthWebHookResponse>(response);
        }

        public GetBtcHooksResponse GetHooks(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/hooks");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetBtcHooksResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetBtcHooksResponse>(response);
        }

        public GetEthHooksResponse GetHooks(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/hooks");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetEthHooksResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetEthHooksResponse>(response);
        }

        public DeleteWebhookResponse Delete(BtcSimilarCoin coin, BtcSimilarNetwork network, string hookId)
        {
            if (string.IsNullOrEmpty(hookId))
                throw new ArgumentNullException(nameof(hookId));

            var request = Request.Delete($"{Consts.Blockchain}/{coin}/{network}/hooks/{hookId}");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<DeleteWebhookResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<DeleteWebhookResponse>(response);
        }

        public DeleteWebhookResponse Delete(EthSimilarCoin coin, EthSimilarNetwork network, string hookId)
        {
            if (string.IsNullOrEmpty(hookId))
                throw new ArgumentNullException(nameof(hookId));

            var request = Request.Delete($"{Consts.Blockchain}/{coin}/{network}/hooks/{hookId}");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<DeleteWebhookResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<DeleteWebhookResponse>(response);
        }
    }
}