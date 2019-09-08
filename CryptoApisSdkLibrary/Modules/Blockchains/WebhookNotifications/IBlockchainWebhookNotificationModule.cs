using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.WebhookNotifications
{
    public interface IBlockchainWebhookNotificationModule
    {
        /// <summary>
        /// Triggered for every new block added to the blockchain you’ve selected as your base resource. The payload is a Block.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <see cref=""/>
        CreateBtcNewBlockWebHookResponse CreateNewBlock(BtcSimilarCoin coin, BtcSimilarNetwork network, string url);

        /// <summary>
        /// Triggered for every new block added to the blockchain you’ve selected as your base resource. The payload is a Block.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <see cref=""/>
        Task<CreateBtcNewBlockWebHookResponse> CreateNewBlockAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string url);

        /// <summary>
        /// Triggered for every new block. The payload is a Block.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <see cref=""/>
        CreateEthWebHookResponse CreateNewBlock(EthSimilarCoin coin, EthSimilarNetwork network, string url);

        /// <summary>
        /// Triggered for every new block. The payload is a Block.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <see cref=""/>
        Task<CreateEthWebHookResponse> CreateNewBlockAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string url);

        /// <summary>
        /// Triggered for every new transaction making it into a new block; in other words, for every first transaction confirmation.
        /// This is equivalent to listening to the new-block event and fetching each transaction in the new Block.
        /// The payload is a confirmed transaction.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="transactionHash">Transaction hash.</param>
        /// <param name="confirmationCount">Confirmations of mined transactions.</param>
        /// <see cref=""/>
        CreateBtcConfirmedTransactionWebHookResponse CreateConfirmedTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string url, string transactionHash, int confirmationCount);

        /// <summary>
        /// Triggered for every new transaction making it into a new block; in other words, for every first transaction confirmation.
        /// This is equivalent to listening to the new-block event and fetching each transaction in the new Block.
        /// The payload is a confirmed transaction.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="transactionHash">Transaction hash.</param>
        /// <param name="confirmationCount">Confirmations of mined transactions.</param>
        /// <see cref=""/>
        Task<CreateBtcConfirmedTransactionWebHookResponse> CreateConfirmedTransactionAsync(
            CancellationToken cancellationToken, BtcSimilarCoin coin, BtcSimilarNetwork network,
            string url, string transactionHash, int confirmationCount);

        /// <summary>
        /// Triggered for every new transaction making it into a new block; in other words, for every first transaction confirmation.
        /// This is equivalent to listening to the new-block event and fetching each transaction (or filtered transaction) in the new Block.
        /// The payload is a confirmed TX.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="transactionHash">Transaction hash.</param>
        /// <param name="confirmationCount">Confirmations of mined transactions.</param>
        /// <see cref=""/>
        CreateEthConfirmedTransactionWebHookResponse CreateConfirmedTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string url, string transactionHash, int confirmationCount);

        /// <summary>
        /// Triggered for every new transaction making it into a new block; in other words, for every first transaction confirmation.
        /// This is equivalent to listening to the new-block event and fetching each transaction (or filtered transaction) in the new Block.
        /// The payload is a confirmed TX.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="transactionHash">Transaction hash.</param>
        /// <param name="confirmationCount">Confirmations of mined transactions.</param>
        /// <see cref=""/>
        Task<CreateEthConfirmedTransactionWebHookResponse> CreateConfirmedTransactionAsync(
            CancellationToken cancellationToken, EthSimilarCoin coin, EthSimilarNetwork network,
            string url, string transactionHash, int confirmationCount);

        /// <summary>
        /// Triggered any time an address appears in new block added to the blockchain.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="address">.</param>
        /// <see cref=""/>
        CreateBtcAddressWebHookResponse CreateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string url, string address);

        /// <summary>
        /// Triggered any time an address appears in new block added to the blockchain.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="address">.</param>
        /// <see cref=""/>
        Task<CreateBtcAddressWebHookResponse> CreateAddressAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string url, string address);

        /// <summary>
        /// Simplifies listening to confirmations on all transactions for a given address up to a provided threshold. The payload is a TX.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="address">.</param>
        /// <see cref=""/>
        CreateEthAddressWebHookResponse CreateAddress(EthSimilarCoin coin, EthSimilarNetwork network, string url, string address);

        /// <summary>
        /// Simplifies listening to confirmations on all transactions for a given address up to a provided threshold. The payload is a TX.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="address">.</param>
        /// <see cref=""/>
        Task<CreateEthAddressWebHookResponse> CreateAddressAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string url, string address);

        /// <summary>
        /// Simplifies listening to confirmations on all token transfers for a given address up to a provided threshold.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="address">.</param>
        /// <see cref=""/>
        CreateEthAddressWebHookResponse CreateToken(EthSimilarCoin coin, EthSimilarNetwork network, string url, string address);

        /// <summary>
        /// Simplifies listening to confirmations on all token transfers for a given address up to a provided threshold.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="address">.</param>
        /// <see cref=""/>
        Task<CreateEthAddressWebHookResponse> CreateTokenAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string url, string address);

        /// <summary>
        /// Triggered for every queued transaction in the Ethereum Blockchain before it’s confirmed in a block.
        /// The payload is a list with queued transactions.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <see cref=""/>
        CreateEthWebHookResponse CreateTransactionPool(EthSimilarCoin coin, EthSimilarNetwork network, string url);

        /// <summary>
        /// Triggered for every queued transaction in the Ethereum Blockchain before it’s confirmed in a block.
        /// The payload is a list with queued transactions.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <see cref=""/>
        Task<CreateEthWebHookResponse> CreateTransactionPoolAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string url);

        /// <summary>
        /// Provides a list with the webhooks for a given user id.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <see cref=""/>
        GetBtcHooksResponse GetHooks(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Provides a list with the webhooks for a given user id.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <see cref=""/>
        Task<GetBtcHooksResponse> GetHooksAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Provides a list with the webhooks for a given user id.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <see cref=""/>
        GetEthHooksResponse GetHooks(EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Provides a list with the webhooks for a given user id.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <see cref=""/>
        Task<GetEthHooksResponse> GetHooksAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Delete webhook.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="hookId">Webhook id.</param>
        /// <see cref=""/>
        DeleteWebhookResponse Delete(BtcSimilarCoin coin, BtcSimilarNetwork network, string hookId);

        /// <summary>
        /// Delete webhook.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="hookId">Webhook id.</param>
        /// <see cref=""/>
        Task<DeleteWebhookResponse> DeleteAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string hookId);

        /// <summary>
        /// Delete webhook.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="hookId">Webhook id.</param>
        /// <see cref=""/>
        DeleteWebhookResponse Delete(EthSimilarCoin coin, EthSimilarNetwork network, string hookId);

        /// <summary>
        /// Delete webhook.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="hookId">Webhook id.</param>
        /// <see cref=""/>
        Task<DeleteWebhookResponse> DeleteAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string hookId);
    }
}