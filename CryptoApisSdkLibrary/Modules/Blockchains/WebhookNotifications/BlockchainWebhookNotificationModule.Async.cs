using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.WebhookNotifications
{
    internal partial class BlockchainWebhookNotificationModule
    {
        public Task<CreateBtcNewBlockWebHookResponse> CreateNewBlockAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string url)
        {
            var request = Requests.CreateNewBlock(coin, network, url);
            return GetAsyncResponse<CreateBtcNewBlockWebHookResponse>(request, cancellationToken);
        }

        public Task<CreateEthWebHookResponse> CreateNewBlockAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string url)
        {
            var request = Requests.CreateNewBlock(coin, network, url);
            return GetAsyncResponse<CreateEthWebHookResponse>(request, cancellationToken);
        }

        public Task<CreateBtcConfirmedTransactionWebHookResponse> CreateConfirmedTransactionAsync(CancellationToken cancellationToken, BtcSimilarCoin coin,
            BtcSimilarNetwork network, string url, string transactionHash, int confirmationCount)
        {
            var request = Requests.CreateConfirmedTransaction(coin, network, url, transactionHash, confirmationCount);
            return GetAsyncResponse<CreateBtcConfirmedTransactionWebHookResponse>(request, cancellationToken);
        }

        public Task<CreateEthConfirmedTransactionWebHookResponse> CreateConfirmedTransactionAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string url, string transactionHash, int confirmationCount)
        {
            var request = Requests.CreateConfirmedTransaction(coin, network, url, transactionHash, confirmationCount);
            return GetAsyncResponse<CreateEthConfirmedTransactionWebHookResponse>(request, cancellationToken);
        }

        public Task<CreateBtcAddressWebHookResponse> CreateAddressAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string url, string address)
        {
            var request = Requests.CreateAddress(coin, network, url, address);
            return GetAsyncResponse<CreateBtcAddressWebHookResponse>(request, cancellationToken);
        }

        public Task<CreateEthAddressWebHookResponse> CreateAddressAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string url, string address)
        {
            var request = Requests.CreateAddress(coin, network, url, address);
            return GetAsyncResponse<CreateEthAddressWebHookResponse>(request, cancellationToken);
        }

        public Task<CreateEthAddressWebHookResponse> CreateTokenAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string url, string address)
        {
            var request = Requests.CreateToken(coin, network, url, address);
            return GetAsyncResponse<CreateEthAddressWebHookResponse>(request, cancellationToken);
        }

        public Task<CreateEthWebHookResponse> CreateTransactionPoolAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string url)
        {
            var request = Requests.CreateTransactionPool(coin, network, url);
            return GetAsyncResponse<CreateEthWebHookResponse>(request, cancellationToken);
        }

        public Task<GetBtcHooksResponse> GetHooksAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.GetHooks(coin, network);
            return GetAsyncResponse<GetBtcHooksResponse>(request, cancellationToken);
        }

        public Task<GetEthHooksResponse> GetHooksAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.GetHooks(coin, network);
            return GetAsyncResponse<GetEthHooksResponse>(request, cancellationToken);
        }

        public Task<DeleteWebhookResponse> DeleteAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string hookId)
        {
            var request = Requests.Delete(coin, network, hookId);
            return GetAsyncResponse<DeleteWebhookResponse>(request, cancellationToken);
        }

        public Task<DeleteWebhookResponse> DeleteAsync(CancellationToken cancellationToken, 
            EthSimilarCoin coin, EthSimilarNetwork network, string hookId)
        {
            var request = Requests.Delete(coin, network, hookId);
            return GetAsyncResponse<DeleteWebhookResponse>(request, cancellationToken);
        }
    }
}