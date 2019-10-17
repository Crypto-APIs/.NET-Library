using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Blockchains.WebhookNotifications
{
    public interface IBlockchainWebhookNotificationModule
    {
        /// <summary>
        /// Triggered for every new block added to the blockchain you’ve selected as your base resource. The payload is a Block.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="url">Webhook callback url.</param>
        T CreateNewBlock<T>(NetworkCoin networkCoin, string url)
            where T : WebHookResponse, new();

        /// <summary>
        /// Triggered for every new block added to the blockchain you’ve selected as your base resource. The payload is a Block.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="url">Webhook callback url.</param>
        Task<T> CreateNewBlockAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string url)
            where T : WebHookResponse, new();

        /// <summary>
        /// Triggered for every new transaction making it into a new block; in other words, for every first transaction confirmation.
        /// This is equivalent to listening to the new-block event and fetching each transaction in the new Block.
        /// The payload is a confirmed transaction.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="transactionHash">Transaction hash.</param>
        /// <param name="confirmationCount">Confirmations of mined transactions.</param>
        T CreateConfirmedTransaction<T>(NetworkCoin networkCoin,
            string url, string transactionHash, int confirmationCount)
            where T : CreateConfirmedTransactionWebHookResponse, new();

        /// <summary>
        /// Triggered for every new transaction making it into a new block; in other words, for every first transaction confirmation.
        /// This is equivalent to listening to the new-block event and fetching each transaction in the new Block.
        /// The payload is a confirmed transaction.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="transactionHash">Transaction hash.</param>
        /// <param name="confirmationCount">Confirmations of mined transactions.</param>
        Task<T> CreateConfirmedTransactionAsync<T>(
            CancellationToken cancellationToken, NetworkCoin networkCoin,
            string url, string transactionHash, int confirmationCount)
            where T : CreateConfirmedTransactionWebHookResponse, new();

        /// <summary>
        /// Triggered any time an address appears in new block added to the blockchain.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="address">.</param>
        T CreateAddress<T>(NetworkCoin networkCoin, string url, string address)
            where T : CreateAddressWebHookResponse, new();

        /// <summary>
        /// Triggered any time an address appears in new block added to the blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="address">.</param>
        Task<T> CreateAddressAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string url, string address)
            where T : CreateAddressWebHookResponse, new();

        /// <summary>
        /// Simplifies listening to confirmations on all token transfers for a given address up to a provided threshold.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="address">.</param>
        T CreateToken<T>(NetworkCoin networkCoin, string url, string address)
            where T : CreateEthAddressWebHookResponse, new();

        /// <summary>
        /// Simplifies listening to confirmations on all token transfers for a given address up to a provided threshold.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="address">.</param>
        Task<T> CreateTokenAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string url, string address)
            where T : CreateEthAddressWebHookResponse, new();

        /// <summary>
        /// Triggered for every queued transaction in the Ethereum Blockchain before it’s confirmed in a block.
        /// The payload is a list with queued transactions.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="url">Webhook callback url.</param>
        T CreateTransactionPool<T>(NetworkCoin networkCoin, string url)
            where T : EthWebHookResponse, new();

        /// <summary>
        /// Triggered for every queued transaction in the Ethereum Blockchain before it’s confirmed in a block.
        /// The payload is a list with queued transactions.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="url">Webhook callback url.</param>
        Task<T> CreateTransactionPoolAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string url)
            where T : EthWebHookResponse, new();

        /// <summary>
        /// Provides a list with the webhooks for a given user id.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        T GetHooks<T>(NetworkCoin networkCoin)
            where T : GetHooksResponse, new();

        /// <summary>
        /// Provides a list with the webhooks for a given user id.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        Task<T> GetHooksAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : GetHooksResponse, new();

        /// <summary>
        /// Delete webhook.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="hookId">Webhook id.</param>
        T Delete<T>(NetworkCoin networkCoin, string hookId)
            where T : DeleteWebhookResponse, new();

        /// <summary>
        /// Delete webhook.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="hookId">Webhook id.</param>
        Task<T> DeleteAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string hookId)
            where T : DeleteWebhookResponse, new();
    }
}