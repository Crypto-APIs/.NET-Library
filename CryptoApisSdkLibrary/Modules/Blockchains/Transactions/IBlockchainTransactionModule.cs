using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Transactions
{
    public interface IBlockchainTransactionModule
    {
        /// <summary>
        /// Returns detailed information about a given transaction based on its id.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="transactionId">Id of the transaction in blockchain.</param>
        BtcTransactionInfoResponse GetInfo(BtcSimilarCoin coin, BtcSimilarNetwork network, string transactionId);

        /// <summary>
        /// Returns detailed information about a given transaction based on its hash.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="transactionHash">Hash of the transaction in blockchain.</param>
        EthTransactionInfoResponse GetInfo(EthSimilarCoin coin, EthSimilarNetwork network, string transactionHash);

        /// <summary>
        /// Returns detailed information about a given transaction based on its index and block hash.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="blockHash">Blockhash in blockchain.</param>
        /// <param name="transactionIndex">Index of the transaction in block.</param>
        EthTransactionInfoResponse GetInfo(EthSimilarCoin coin, EthSimilarNetwork network, string blockHash, int transactionIndex);

        /// <summary>
        /// Returns detailed information about a given transaction based on its index and block height.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="blockHeight">Block height.</param>
        /// <param name="transactionIndex">Index of the transaction in block.</param>
        EthTransactionInfoResponse GetInfo(EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight, int transactionIndex);

        /// <summary>
        /// Returns detailed information about transactions for the block height defined, starting from the index defined up to the limit defined.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="blockHeight">Block height.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        GetBtcTransactionInfosResponse GetInfos(BtcSimilarCoin coin, BtcSimilarNetwork network, int blockHeight,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Returns detailed information about a given set of transactions based on theirs hashes.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="blockHash">Hash of block.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        GetBtcTransactionInfosResponse GetInfos(BtcSimilarCoin coin, BtcSimilarNetwork network, string blockHash,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Returns detailed information about transactions for the block height defined, starting from the index defined up to the limit defined.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="blockHeight">Block height.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        GetEthTransactionInfosResponse GetInfos(EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Returns an array of the latest transactions relayed by nodes in a blockchain that haven’t been included in any blocks.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="skip">The offset of items to start from.</param>
        /// <param name="limit">Amount of items to return.</param>
        GetUnconfirmedTransactionsResponse GetUnconfirmedTransactions(BtcSimilarCoin coin, BtcSimilarNetwork network,
            int skip = 0, int limit = 50);

        /// <summary>
        /// Decode raw transactions without sending propagating them to the network.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="hexEncodedInfo">Hex of raw transaction.</param>
        BtcDecodeTransactionResponse DecodeTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, string hexEncodedInfo);

        /// <summary>
        /// Create the transactions.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="inputAddresses">Input address(es).</param>
        /// <param name="outputAddresses">Output address(es).</param>
        /// <param name="fee">Fee.</param>
        CreateBtcTransactionResponse CreateTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, Fee fee);

        /// <summary>
        /// Create the transactions.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        /// <param name="password">The password associated with the keyfile should also be specified in order to unlock the account.</param>
        CreateEthTransactionResponse CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string password);

        /// <summary>
        /// Create the transactions.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        /// <param name="password">The password associated with the keyfile should also be specified in order to unlock the account.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        CreateEthTransactionResponse CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string password, double gasPrice, double gasLimit);

        /// <summary>
        /// Sending transactions for address that are not hold on our servers.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="privateKey">Private key.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        CreateEthTransactionResponse CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string privateKey, double value);

        /// <summary>
        /// Sending transactions for address that are not hold on our servers.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        /// <param name="privateKey">Private key.</param>
        /// <param name="gasPrice">Gas price.</param>
        /// <param name="gasLimit">Gas limit.</param>
        CreateEthTransactionResponse CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string privateKey, double value, double gasPrice, double gasLimit);

        /// <summary>
        /// Send All Amount Endpoint using keystore file stored on our server.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="password">The password associated with the keyfile should also be specified in order to unlock the account.</param>
        CreateEthTransactionResponse SendAllAmountUsingPassword(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string password);

        /// <summary>
        /// Send All Amount Endpoint using keystore file stored on our server.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="privateKey">Private key.</param>
        CreateEthTransactionResponse SendAllAmountUsingPrivateKey(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string privateKey);

        /// <summary>
        /// The Sign Transactions Endpoint allows users to sign a raw transaction.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="hexEncodedInfo">Hex of raw transaction.</param>
        /// <param name="wifs">wifs</param>
        SignBtcTransactionResponse SignTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string hexEncodedInfo, IEnumerable<string> wifs);

        /// <summary>
        /// Send Transaction Endpoint.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="hexEncodedInfo">Hex of raw transaction.</param>
        SendBtcTransactionResponse SendTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, string hexEncodedInfo);

        /// <summary>
        /// Crypto APIs provides the opportunity to locally sign your transaction. 
        /// If you want to use third-pary tools for signing your raw transactions you can send to the Locally Sign Your Transaction Endpoint.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        LocallySignTransactionResponse LocallySignTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value);

        /// <summary>
        /// This endpoint combines the other three endpoints: Create, Sign and Send Endpoints. 
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="inputAddresses">Input address(es).</param>
        /// <param name="outputAddresses">Output address(es).</param>
        /// <param name="fee">Fee.</param>
        /// <param name="wifs">Private ECDSA keys.</param>
        NewBtcTransactionResponse NewTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, Fee fee,
            IEnumerable<string> wifs);

        /// <summary>
        /// Provides the possibility to create, sign and send new transactions using your HDWallet.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        /// <param name="wallet">HD wallet name</param>
        /// <param name="password"></param>
        /// <param name="inputAddresses">Input address(es).</param>
        /// <param name="outputAddresses">Output address(es).</param>
        /// <param name="fee">Fee.</param>
        /// <param name="lockTime">Use locktime if a transaction should be delayed to a specific time.</param>
        NewBtcTransactionResponse NewHdTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string wallet, string password,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, 
            Fee fee, long lockTime = 0);

        /// <summary>
        /// Once you’ve finished signing the raw transaction locally, send that raw transaction to our Push Raw Transaction Endpoint.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="hexEncodedInfo">Hex of raw transaction</param>
        PushTransactionResponse PushTransaction(EthSimilarCoin coin, EthSimilarNetwork network, string hexEncodedInfo);

        /// <summary>
        /// Once you’ve finished signing the raw transaction locally, send that raw transaction to our Push Raw Transaction Endpoint.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        /// <param name="fromAddress">Output address.</param>
        /// <param name="toAddress">Input address.</param>
        /// <param name="value">Value to transfer (in Ether).</param>
        /// <param name="data"></param>
        EstimateTransactionGasResponse EstimateTransactionGas(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string data = null);

        /// <summary>
        /// Makes a call to the EVM and returns all pending transactions. The response might be limited if you lack credits.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        PendingTransactionsResponse PendingTransactions(EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Makes a call to the EVM and returns all pending transactions. The response might be limited if you lack credits.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        QueuedTransactionsResponse QueuedTransactions(EthSimilarCoin coin, EthSimilarNetwork network);

        /// <summary>
        /// Gives information about the gas price for the successfull transactions included in the last 1500 blocks.
        /// </summary>
        /// <param name="coin">BTC-similar coin (BTC, BCH, LTC, ...)</param>
        /// <param name="network">Network of BTC-similar coin.</param>
        BtcTransactionsFeeResponse TransactionsFee(BtcSimilarCoin coin, BtcSimilarNetwork network);

        /// <summary>
        /// Gives information about the gas price for the successfull transactions included in the last 1500 blocks.
        /// </summary>
        /// <param name="coin">ETH-similar coin (ETH, ...)</param>
        /// <param name="network">Network of ETH-similar coin.</param>
        EthTransactionsFeeResponse TransactionsFee(EthSimilarCoin coin, EthSimilarNetwork network);

        // New Transaction Using HDWallet Endpoint
    }
}