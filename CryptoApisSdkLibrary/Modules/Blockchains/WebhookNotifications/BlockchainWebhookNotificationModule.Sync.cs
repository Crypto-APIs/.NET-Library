using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;

namespace CryptoApisSdkLibrary.Modules.Blockchains.WebhookNotifications
{
    internal partial class BlockchainWebhookNotificationModule
    {
        public T CreateNewBlock<T>(NetworkCoin networkCoin, string url)
            where T : WebHookResponse, new()
        {
            return CreateNewBlockAsync<T>(CancellationToken.None, networkCoin, url).GetAwaiter().GetResult();
        }

        public T CreateConfirmedTransaction<T>(NetworkCoin networkCoin, string url, string transactionHash, int confirmationCount)
            where T : CreateConfirmedTransactionWebHookResponse, new()
        {
            return CreateConfirmedTransactionAsync<T>(CancellationToken.None, networkCoin,
                url, transactionHash, confirmationCount).GetAwaiter().GetResult();
        }

        public T CreateAddress<T>(NetworkCoin networkCoin, string url, string address)
            where T : CreateAddressWebHookResponse, new()
        {
            return CreateAddressAsync<T>(CancellationToken.None, networkCoin, url, address).GetAwaiter().GetResult();
        }

        public T CreateToken<T>(NetworkCoin networkCoin, string url, string address)
            where T : CreateEthAddressWebHookResponse, new()
        {
            return CreateTokenAsync<T>(CancellationToken.None, networkCoin, url, address).GetAwaiter().GetResult();
        }

        public T CreateTransactionPool<T>(NetworkCoin networkCoin, string url)
            where T : EthWebHookResponse, new()
        {
            return CreateTransactionPoolAsync<T>(CancellationToken.None, networkCoin, url).GetAwaiter().GetResult();
        }

        public T GetHooks<T>(NetworkCoin networkCoin)
            where T : GetHooksResponse, new()
        {
            return GetHooksAsync<T>(CancellationToken.None, networkCoin).GetAwaiter().GetResult();
        }

        public T Delete<T>(NetworkCoin networkCoin, string hookId)
            where T : DeleteWebhookResponse, new()
        {
            return DeleteAsync<T>(CancellationToken.None, networkCoin, hookId).GetAwaiter().GetResult();
        }
    }
}