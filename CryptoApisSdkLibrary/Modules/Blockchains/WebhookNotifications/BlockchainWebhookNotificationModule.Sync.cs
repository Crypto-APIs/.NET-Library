using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

namespace CryptoApisSdkLibrary.Modules.Blockchains.WebhookNotifications
{
    internal partial class BlockchainWebhookNotificationModule
    {
        public T CreateNewBlock<T>(NetworkCoin networkCoin, string url)
            where T : WebHookResponse, new()
        {
            var request = Requests.CreateNewBlock(networkCoin, url);
            return GetSync<T>(request);
        }

        public T CreateConfirmedTransaction<T>(NetworkCoin networkCoin, string url, string transactionHash, int confirmationCount)
            where T : CreateConfirmedTransactionWebHookResponse, new()
        {
            var request = Requests.CreateConfirmedTransaction(networkCoin, url, transactionHash, confirmationCount);
            return GetSync<T>(request);
        }

        public T CreateAddress<T>(NetworkCoin networkCoin, string url, string address)
            where T : CreateAddressWebHookResponse, new()
        {
            var request = Requests.CreateAddress(networkCoin, url, address);
            return GetSync<T>(request);
        }

        public T CreateToken<T>(NetworkCoin networkCoin, string url, string address)
            where T : CreateEthAddressWebHookResponse, new()
        {
            var request = Requests.CreateToken(networkCoin, url, address);
            return GetSync<T>(request);
        }

        public T CreateTransactionPool<T>(NetworkCoin networkCoin, string url)
            where T : EthWebHookResponse, new()
        {
            var request = Requests.CreateTransactionPool(networkCoin, url);
            return GetSync<T>(request);
        }

        public T GetHooks<T>(NetworkCoin networkCoin)
            where T : GetHooksResponse, new()
        {
            var request = Requests.GetHooks(networkCoin);
            return GetSync<T>(request);
        }

        public T Delete<T>(NetworkCoin networkCoin, string hookId)
            where T : DeleteWebhookResponse, new()
        {
            var request = Requests.Delete(networkCoin, hookId);
            return GetSync<T>(request);
        }
    }
}