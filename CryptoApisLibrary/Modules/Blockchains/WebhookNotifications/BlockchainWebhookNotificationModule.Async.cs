using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Blockchains.WebhookNotifications
{
    internal partial class BlockchainWebhookNotificationModule
    {
        public Task<T> CreateNewBlockAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string url)
            where T : WebHookResponse, new()
        {
            var request = Requests.CreateNewBlock(networkCoin, url);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> CreateConfirmedTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string url, string transactionHash, int confirmationCount)
            where T : CreateConfirmedTransactionWebHookResponse, new()
        {
            var request = Requests.CreateConfirmedTransaction(networkCoin, url, transactionHash, confirmationCount);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> CreateAddressAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string url, string address)
            where T : CreateAddressWebHookResponse, new()
        {
            var request = Requests.CreateAddress(networkCoin, url, address);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> CreateTokenAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string url, string address)
            where T : CreateEthAddressWebHookResponse, new()
        {
            var request = Requests.CreateToken(networkCoin, url, address);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> CreateTransactionPoolAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string url, string address)
            where T : EthWebHookResponse, new()
        {
            var request = Requests.CreateTransactionPool(networkCoin, url, address);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> CreateTransactionConfirmationsAsync<T>(CancellationToken cancellationToken, 
            NetworkCoin networkCoin, string url, string address, int confirmations) 
            where T : CreateTransactionConfirmationsResponse, new()
        {
            var request = Requests.CreateTransactionConfirmations(networkCoin, url, address, confirmations);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetHooksAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GetHooksResponse, new()
        {
            var request = Requests.GetHooks(networkCoin);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> DeleteAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string hookId)
            where T : DeleteWebhookResponse, new()
        {
            var request = Requests.Delete(networkCoin, hookId);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> DeleteAllAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin) 
            where T : DeleteAllWebhookResponse, new()
        {
            var request = Requests.DeleteAll(networkCoin);
            return GetAsyncResponse<T>(request, cancellationToken);
        }
    }
}