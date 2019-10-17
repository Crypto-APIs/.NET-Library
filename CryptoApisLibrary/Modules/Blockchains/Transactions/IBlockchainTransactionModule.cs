using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisLibrary.Modules.Blockchains.Transactions
{
    public interface IBlockchainTransactionModule
    {
        /// <summary>
        /// Returns detailed information about a given transaction based on its id.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="transactionId">Id (block hash) of the transaction in blockchain.</param>
        T GetInfo<T>(NetworkCoin networkCoin, string transactionId)
            where T : BtcTransactionInfoResponse, new();

        /// <summary>
        /// Returns detailed information about a given transaction based on its id.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="transactionId">Id (block hash) of the transaction in blockchain.</param>
        Task<T> GetInfoAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string transactionId)
            where T : BtcTransactionInfoResponse, new();

        /// <summary>
        /// Returns detailed information about a given transaction based on its block hash.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHash">Id (block hash) of the transaction in blockchain.</param>
        T GetInfoByBlockHash<T>(NetworkCoin networkCoin, string blockHash)
            where T : EthTransactionInfoResponse, new();

        /// <summary>
        /// Returns detailed information about a given transaction based on its block hash.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHash">Block hash of the transaction in blockchain.</param>
        Task<T> GetInfoByBlockHashAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string blockHash)
            where T : EthTransactionInfoResponse, new();

        /// <summary>
        /// Returns detailed information about a given transaction based on its index and block hash.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHash">Blockhash in blockchain.</param>
        /// <param name="transactionIndex">Index of the transaction in block.</param>
        T GetInfo<T>(NetworkCoin networkCoin, string blockHash, int transactionIndex)
            where T : EthTransactionInfoResponse, new();

        /// <summary>
        /// Returns detailed information about a given transaction based on its index and block hash.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHash">Blockhash in blockchain.</param>
        /// <param name="transactionIndex">Index of the transaction in block.</param>
        Task<T> GetInfoAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string blockHash, int transactionIndex)
            where T : EthTransactionInfoResponse, new();

        /// <summary>
        /// Returns detailed information about a given transaction based on its index and block height.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHeight">Block height.</param>
        /// <param name="transactionIndex">Index of the transaction in block.</param>
        T GetInfo<T>(NetworkCoin networkCoin, int blockHeight, int transactionIndex)
            where T : EthTransactionInfoResponse, new();

        /// <summary>
        /// Returns detailed information about a given transaction based on its index and block height.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHeight">Block height.</param>
        /// <param name="transactionIndex">Index of the transaction in block.</param>
        Task<T> GetInfoAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, int blockHeight, int transactionIndex)
            where T : EthTransactionInfoResponse, new();

        /// <summary>
        /// Returns detailed information about transactions for the block height defined, starting from the index defined up to the limit defined.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHeight">Block height.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        T GetInfos<T>(NetworkCoin networkCoin, int blockHeight, int skip = 0, int limit = 50)
            where T : GetTransactionInfosResponse, new();

        /// <summary>
        /// Returns detailed information about transactions for the block height defined, starting from the index defined up to the limit defined.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHeight">Block height.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        Task<T> GetInfosAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, int blockHeight, int skip = 0, int limit = 50)
            where T : GetTransactionInfosResponse, new();

        /// <summary>
        /// Returns detailed information about a given set of transactions based on theirs hashes.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHash">Hash of block.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        T GetInfos<T>(NetworkCoin networkCoin, string blockHash, int skip = 0, int limit = 50)
            where T : GetBtcTransactionInfosResponse, new();

        /// <summary>
        /// Returns detailed information about a given set of transactions based on theirs hashes.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="blockHash">Hash of block.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        Task<T> GetInfosAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string blockHash, int skip = 0, int limit = 50)
            where T : GetBtcTransactionInfosResponse, new();

        /// <summary>
        /// Returns an array of the latest transactions relayed by nodes in a blockchain that haven’t been included in any blocks.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        T GetUnconfirmedTransactions<T>(NetworkCoin networkCoin, int skip = 0, int limit = 50)
            where T : GetUnconfirmedTransactionsResponse, new();

        /// <summary>
        /// Returns an array of the latest transactions relayed by nodes in a blockchain that haven’t been included in any blocks.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        Task<T> GetUnconfirmedTransactionsAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, int skip = 0, int limit = 50)
            where T : GetUnconfirmedTransactionsResponse, new();

        /// <summary>
        /// Decode raw transactions without sending propagating them to the network.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="hexEncodedInfo">Hex of raw transaction.</param>
        T DecodeTransaction<T>(NetworkCoin networkCoin, string hexEncodedInfo)
            where T : BtcDecodeTransactionResponse, new();

        /// <summary>
        /// Decode raw transactions without sending propagating them to the network.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="hexEncodedInfo">Hex of raw transaction.</param>
        Task<T> DecodeTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string hexEncodedInfo)
            where T : BtcDecodeTransactionResponse, new();

        /// <summary>
        /// Create the transactions.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="inputAddresses">Input address(es).</param>
        /// <param name="outputAddresses">Output address(es).</param>
        /// <param name="fee">Fee.</param>
        T CreateTransaction<T>(NetworkCoin networkCoin,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, Fee fee)
            where T : CreateBtcTransactionResponse, new();

        /// <summary>
        /// Create the transactions.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="inputAddresses">Input address(es).</param>
        /// <param name="outputAddresses">Output address(es).</param>
        /// <param name="fee">Fee.</param>
        Task<T> CreateTransactionAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, Fee fee)
            where T : CreateBtcTransactionResponse, new();

        /// <summary>
        /// Create the transactions.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        /// <param name="password">The password associated with the keyfile should also be specified in order to unlock the account.</param>
        T CreateTransaction<T>(NetworkCoin networkCoin, string fromAddress, string toAddress, double value, string password)
            where T : CreateEthTransactionResponse, new();

        /// <summary>
        /// Create the transactions.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        /// <param name="password">The password associated with the keyfile should also be specified in order to unlock the account.</param>
        Task<T> CreateTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress, double value, string password)
            where T : CreateEthTransactionResponse, new();

        /// <summary>
        /// Create the transactions.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        /// <param name="password">The password associated with the keyfile should also be specified in order to unlock the account.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        T CreateTransaction<T>(NetworkCoin networkCoin, string fromAddress, string toAddress,
            double value, string password, double gasPrice, double gasLimit)
            where T : CreateEthTransactionResponse, new();

        /// <summary>
        /// Create the transactions.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        /// <param name="password">The password associated with the keyfile should also be specified in order to unlock the account.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        Task<T> CreateTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress,
            double value, string password, double gasPrice, double gasLimit)
            where T : CreateEthTransactionResponse, new();

        /// <summary>
        /// Sending transactions for address that are not hold on our servers.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="privateKey">Private key.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        T CreateTransaction<T>(NetworkCoin networkCoin, string fromAddress, string toAddress, string privateKey, double value)
            where T : CreateEthTransactionResponse, new();

        /// <summary>
        /// Sending transactions for address that are not hold on our servers.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="privateKey">Private key.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        Task<T> CreateTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress, string privateKey, double value)
            where T : CreateEthTransactionResponse, new();

        /// <summary>
        /// Sending transactions for address that are not hold on our servers.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        /// <param name="privateKey">Private key.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        T CreateTransaction<T>(NetworkCoin networkCoin, string fromAddress, string toAddress,
            string privateKey, double value, double gasPrice, double gasLimit)
            where T : CreateEthTransactionResponse, new();

        /// <summary>
        /// Sending transactions for address that are not hold on our servers.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        /// <param name="privateKey">Private key.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        Task<T> CreateTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress,
            string privateKey, double value, double gasPrice, double gasLimit)
            where T : CreateEthTransactionResponse, new();

        /// <summary>
        /// Send All Amount Endpoint using keystore file stored on our server.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="password">The password associated with the keyfile should also be specified in order to unlock the account.</param>
        T SendAllAmountUsingPassword<T>(NetworkCoin networkCoin, string fromAddress, string toAddress, string password)
            where T : CreateEthTransactionResponse, new();

        /// <summary>
        /// Send All Amount Endpoint using keystore file stored on our server.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="password">The password associated with the keyfile should also be specified in order to unlock the account.</param>
        Task<T> SendAllAmountUsingPasswordAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress, string password)
            where T : CreateEthTransactionResponse, new();

        /// <summary>
        /// Send All Amount Endpoint using keystore file stored on our server.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="privateKey">Private key.</param>
        T SendAllAmountUsingPrivateKey<T>(NetworkCoin networkCoin, string fromAddress, string toAddress, string privateKey)
            where T : CreateEthTransactionResponse, new();

        /// <summary>
        /// Send All Amount Endpoint using keystore file stored on our server.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="privateKey">Private key.</param>
        Task<T> SendAllAmountUsingPrivateKeyAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress, string privateKey)
            where T : CreateEthTransactionResponse, new();

        /// <summary>
        /// The Sign Transactions Endpoint allows users to sign a raw transaction.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="hexEncodedInfo">Hex of raw transaction.</param>
        /// <param name="wifs">wifs</param>
        T SignTransaction<T>(NetworkCoin networkCoin, string hexEncodedInfo, IEnumerable<string> wifs)
            where T : SignBtcTransactionResponse, new();

        /// <summary>
        /// The Sign Transactions Endpoint allows users to sign a raw transaction.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="hexEncodedInfo">Hex of raw transaction.</param>
        /// <param name="wifs">wifs</param>
        Task<T> SignTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string hexEncodedInfo, IEnumerable<string> wifs)
            where T : SignBtcTransactionResponse, new();

        /// <summary>
        /// Send Transaction Endpoint.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="hexEncodedInfo">Hex of raw transaction.</param>
        T SendTransaction<T>(NetworkCoin networkCoin, string hexEncodedInfo)
            where T : SendBtcTransactionResponse, new();

        /// <summary>
        /// Send Transaction Endpoint.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="hexEncodedInfo">Hex of raw transaction.</param>
        Task<T> SendTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string hexEncodedInfo)
            where T : SendBtcTransactionResponse, new();

        /// <summary>
        /// Crypto APIs provides the opportunity to locally sign your transaction.
        /// If you want to use third-pary tools for signing your raw transactions you can send to the Locally Sign Your Transaction Endpoint.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        T LocallySignTransaction<T>(NetworkCoin networkCoin, string fromAddress, string toAddress, double value)
            where T : LocallySignTransactionResponse, new();

        /// <summary>
        /// Crypto APIs provides the opportunity to locally sign your transaction.
        /// If you want to use third-pary tools for signing your raw transactions you can send to the Locally Sign Your Transaction Endpoint.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        Task<T> LocallySignTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress, double value)
            where T : LocallySignTransactionResponse, new();

        /// <summary>
        /// This endpoint combines the other three endpoints: Create, Sign and Send Endpoints.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="inputAddresses">Input address(es).</param>
        /// <param name="outputAddresses">Output address(es).</param>
        /// <param name="fee">Fee.</param>
        /// <param name="wifs">Private ECDSA keys.</param>
        T NewTransaction<T>(NetworkCoin networkCoin, IEnumerable<TransactionAddress> inputAddresses,
            IEnumerable<TransactionAddress> outputAddresses, Fee fee, IEnumerable<string> wifs)
            where T : NewBtcTransactionResponse, new();

        /// <summary>
        /// This endpoint combines the other three endpoints: Create, Sign and Send Endpoints.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="inputAddresses">Input address(es).</param>
        /// <param name="outputAddresses">Output address(es).</param>
        /// <param name="fee">Fee.</param>
        /// <param name="wifs">Private ECDSA keys.</param>
        Task<T> NewTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, IEnumerable<TransactionAddress> inputAddresses,
            IEnumerable<TransactionAddress> outputAddresses, Fee fee, IEnumerable<string> wifs)
            where T : NewBtcTransactionResponse, new();

        /// <summary>
        /// Provides the possibility to create, sign and send new transactions using your HDWallet.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="wallet">HD wallet name</param>
        /// <param name="password"></param>
        /// <param name="inputAddresses">Input address(es).</param>
        /// <param name="outputAddresses">Output address(es).</param>
        /// <param name="fee">Fee.</param>
        /// <param name="lockTime">Use locktime if a transaction should be delayed to a specific time.</param>
        T NewHdTransaction<T>(NetworkCoin networkCoin, string wallet, string password,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses,
            Fee fee, long lockTime = 0)
            where T : NewBtcTransactionResponse, new();

        /// <summary>
        /// Provides the possibility to create, sign and send new transactions using your HDWallet.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="wallet">HD wallet name</param>
        /// <param name="password"></param>
        /// <param name="inputAddresses">Input address(es).</param>
        /// <param name="outputAddresses">Output address(es).</param>
        /// <param name="fee">Fee.</param>
        /// <param name="lockTime">Use locktime if a transaction should be delayed to a specific time.</param>
        Task<T> NewHdTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string wallet, string password, IEnumerable<TransactionAddress> inputAddresses,
            IEnumerable<TransactionAddress> outputAddresses, Fee fee, long lockTime = 0)
            where T : NewBtcTransactionResponse, new();

        /// <summary>
        /// Once you’ve finished signing the raw transaction locally, send that raw transaction to our Push Raw Transaction Endpoint.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="hexEncodedInfo">Hex of raw transaction</param>
        T PushTransaction<T>(NetworkCoin networkCoin, string hexEncodedInfo)
            where T : PushTransactionResponse, new();

        /// <summary>
        /// Once you’ve finished signing the raw transaction locally, send that raw transaction to our Push Raw Transaction Endpoint.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="hexEncodedInfo">Hex of raw transaction</param>
        Task<T> PushTransactionAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string hexEncodedInfo)
            where T : PushTransactionResponse, new();

        /// <summary>
        /// Once you’ve finished signing the raw transaction locally, send that raw transaction to our Push Raw Transaction Endpoint.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        /// <param name="data"></param>
        T EstimateTransactionGas<T>(NetworkCoin networkCoin, string fromAddress, string toAddress, double value, string data = null)
            where T : EstimateTransactionGasResponse, new();

        /// <summary>
        /// Once you’ve finished signing the raw transaction locally, send that raw transaction to our Push Raw Transaction Endpoint.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        /// <param name="data"></param>
        Task<T> EstimateTransactionGasAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress, double value, string data = null)
            where T : EstimateTransactionGasResponse, new();

        /// <summary>
        /// Makes a call to the EVM and returns all pending transactions. The response might be limited if you lack credits.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        T PendingTransactions<T>(NetworkCoin networkCoin)
            where T : PendingTransactionsResponse, new();

        /// <summary>
        /// Makes a call to the EVM and returns all pending transactions. The response might be limited if you lack credits.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        Task<T> PendingTransactionsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : PendingTransactionsResponse, new();

        /// <summary>
        /// Makes a call to the EVM and returns all pending transactions. The response might be limited if you lack credits.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        T QueuedTransactions<T>(NetworkCoin networkCoin)
            where T : QueuedTransactionsResponse, new();

        /// <summary>
        /// Makes a call to the EVM and returns all pending transactions. The response might be limited if you lack credits.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        Task<T> QueuedTransactionsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : QueuedTransactionsResponse, new();

        /// <summary>
        /// Gives information about the gas price for the successfull transactions included in the last 1500 blocks.
        /// </summary>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        T TransactionsFee<T>(NetworkCoin networkCoin)
            where T : TransactionsFeeResponse, new();

        /// <summary>
        /// Gives information about the gas price for the successfull transactions included in the last 1500 blocks.
        /// </summary>
        /// <remarks>The request is executed asynchronously.</remarks>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <param name="networkCoin">Coin and network (BTC on Mainnet, ETH on Ropsten, ...)</param>
        Task<T> TransactionsFeeAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : TransactionsFeeResponse, new();
    }
}