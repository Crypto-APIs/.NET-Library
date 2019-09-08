using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.WebhookNotifications
{
    internal partial class BlockchainWebhookNotificationModule
    {
        public CreateBtcNewBlockWebHookResponse CreateNewBlock(BtcSimilarCoin coin, BtcSimilarNetwork network, string url)
        {
            var request = Requests.CreateNewBlock(coin, network, url);
            return GetSync<CreateBtcNewBlockWebHookResponse>(request);
        }

        public CreateEthWebHookResponse CreateNewBlock(EthSimilarCoin coin, EthSimilarNetwork network, string url)
        {
            var request = Requests.CreateNewBlock(coin, network, url);
            return GetSync<CreateEthWebHookResponse>(request);
        }

        public CreateBtcConfirmedTransactionWebHookResponse CreateConfirmedTransaction(
            BtcSimilarCoin coin, BtcSimilarNetwork network, string url,
            string transactionHash, int confirmationCount)
        {
            var request = Requests.CreateConfirmedTransaction(coin, network, url, transactionHash, confirmationCount);
            return GetSync<CreateBtcConfirmedTransactionWebHookResponse>(request);
        }

        public CreateEthConfirmedTransactionWebHookResponse CreateConfirmedTransaction(
            EthSimilarCoin coin, EthSimilarNetwork network, string url, string transactionHash, int confirmationCount)
        {
            var request = Requests.CreateConfirmedTransaction(coin, network, url, transactionHash, confirmationCount);
            return GetSync<CreateEthConfirmedTransactionWebHookResponse>(request);
        }

        public CreateBtcAddressWebHookResponse CreateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string url, string address)
        {
            var request = Requests.CreateAddress(coin, network, url, address);
            return GetSync<CreateBtcAddressWebHookResponse>(request);
        }

        public CreateEthAddressWebHookResponse CreateAddress(EthSimilarCoin coin, EthSimilarNetwork network, string url, string address)
        {
            var request = Requests.CreateAddress(coin, network, url, address);
            return GetSync<CreateEthAddressWebHookResponse>(request);
        }

        public CreateEthAddressWebHookResponse CreateToken(EthSimilarCoin coin, EthSimilarNetwork network, string url, string address)
        {
            var request = Requests.CreateToken(coin, network, url, address);
            return GetSync<CreateEthAddressWebHookResponse>(request);
        }

        public CreateEthWebHookResponse CreateTransactionPool(EthSimilarCoin coin, EthSimilarNetwork network, string url)
        {
            var request = Requests.CreateTransactionPool(coin, network, url);
            return GetSync<CreateEthWebHookResponse>(request);
        }

        public GetBtcHooksResponse GetHooks(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetHooks(coin, network);
            return GetSync<GetBtcHooksResponse>(request);
        }

        public GetEthHooksResponse GetHooks(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.GetHooks(coin, network);
            return GetSync<GetEthHooksResponse>(request);
        }

        public DeleteWebhookResponse Delete(BtcSimilarCoin coin, BtcSimilarNetwork network, string hookId)
        {
            var request = Requests.Delete(coin, network, hookId);
            return GetSync<DeleteWebhookResponse>(request);
        }

        public DeleteWebhookResponse Delete(EthSimilarCoin coin, EthSimilarNetwork network, string hookId)
        {
            var request = Requests.Delete(coin, network, hookId);
            return GetSync<DeleteWebhookResponse>(request);
        }
    }
}