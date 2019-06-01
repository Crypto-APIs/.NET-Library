using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;

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
        CreateBtcNewBlockWebHookResponse CreateNewBlock(BtcSimilarCoin coin, BtcSimilarNetwork network, string url);

        /// <summary>
        /// Triggered for every new block. The payload is a Block.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        CreateEthWebHookResponse CreateNewBlock(EthSimilarCoin coin, EthSimilarNetwork network, string url);

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
        CreateBtcConfirmedTransactionWebHookResponse CreateConfirmedTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, 
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
        CreateEthConfirmedTransactionWebHookResponse CreateConfirmedTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string url, string transactionHash, int confirmationCount);

        /// <summary>
        /// Triggered any time an address appears in new block added to the blockchain.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="address">.</param>
        CreateBtcAddressWebHookResponse CreateAddress(BtcSimilarCoin coin, BtcSimilarNetwork network, string url, string address);

        /// <summary>
        /// Simplifies listening to confirmations on all transactions for a given address up to a provided threshold. The payload is a TX.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="address">.</param>
        CreateEthAddressWebHookResponse CreateAddress(EthSimilarCoin coin, EthSimilarNetwork network, string url, string address);

        /// <summary>
        /// Simplifies listening to confirmations on all token transfers for a given address up to a provided threshold. 
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        /// <param name="address">.</param>
        CreateEthAddressWebHookResponse CreateToken(EthSimilarCoin coin, EthSimilarNetwork network, string url, string address);

        /// <summary>
        /// Triggered for every queued transaction in the Ethereum Blockchain before it’s confirmed in a block. 
        /// The payload is a list with queued transactions.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="url">Webhook callback url.</param>
        CreateEthWebHookResponse CreateTransactionPool(EthSimilarCoin coin, EthSimilarNetwork network, string url);

        /// <summary>
        /// Provides a list with the webhooks for a given user id.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        GetBtcHooksResponse GetHooks(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Provides a list with the webhooks for a given user id.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        GetEthHooksResponse GetHooks(EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Delete webhook.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="hookId">Webhook id.</param>
        DeleteWebhookResponse Delete(BtcSimilarCoin coin, BtcSimilarNetwork network, string hookId);

        /// <summary>
        /// Delete webhook.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="hookId">Webhook id.</param>
        DeleteWebhookResponse Delete(EthSimilarCoin coin, EthSimilarNetwork network, string hookId);
    }
}