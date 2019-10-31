using System.Collections.Generic;
using System.Threading;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;

namespace CryptoApisLibrary.Modules.Blockchains.Transactions
{
    internal partial class BlockchainTransactionModule
    {
        public T GetInfo<T>(NetworkCoin networkCoin, string transactionId)
            where T : BtcTransactionInfoResponse, new()
        {
            return GetInfoAsync<T>(CancellationToken.None, networkCoin, transactionId).GetAwaiter().GetResult();
        }

        public T GetInfoByTransactionHash<T>(NetworkCoin networkCoin, string transactionHash)
            where T : EthTransactionInfoResponse, new()
        {
            return GetInfoByTransactionHashAsync<T>(CancellationToken.None, networkCoin, transactionHash).GetAwaiter().GetResult();
        }

        public T GetInfo<T>(NetworkCoin networkCoin,
            string blockHash, int transactionIndex)
            where T : EthTransactionInfoResponse, new()
        {
            return GetInfoAsync<T>(CancellationToken.None, networkCoin, blockHash, transactionIndex).GetAwaiter().GetResult();
        }

        public T GetInfo<T>(NetworkCoin networkCoin,
            int blockHeight, int transactionIndex)
            where T : EthTransactionInfoResponse, new()
        {
            return GetInfoAsync<T>(CancellationToken.None, networkCoin, blockHeight, transactionIndex).GetAwaiter().GetResult();
        }

        public T GetInfos<T>(NetworkCoin networkCoin, int blockHeight, int skip = 0, int limit = 50)
            where T : GetTransactionInfosResponse, new()
        {
            return GetInfosAsync<T>(CancellationToken.None, networkCoin, blockHeight, skip, limit).GetAwaiter().GetResult();
            /*var request = Requests.GetInfos(networkCoin, blockHeight, skip, limit);
            var result = GetSync<T>(request);
            // todo: Eth need to sort
            //result.Transactions?.Sort((info1, info2) => info1.Index.CompareTo(info2.Index));

            return result;*/
        }

        public T GetInfos<T>(NetworkCoin networkCoin,
            string blockHash, int skip = 0, int limit = 50)
            where T : GetBtcTransactionInfosResponse, new()
        {
            return GetInfosAsync<T>(CancellationToken.None, networkCoin, blockHash, skip, limit).GetAwaiter().GetResult();
        }

        public T GetUnconfirmedTransactions<T>(NetworkCoin networkCoin, int skip = 0, int limit = 50)
            where T : GetUnconfirmedTransactionsResponse, new()
        {
            return GetUnconfirmedTransactionsAsync<T>(CancellationToken.None, networkCoin, skip, limit).GetAwaiter().GetResult();
        }

        public T DecodeTransaction<T>(NetworkCoin networkCoin, string hexEncodedInfo)
            where T : BtcDecodeTransactionResponse, new()
        {
            return DecodeTransactionAsync<T>(CancellationToken.None, networkCoin, hexEncodedInfo).GetAwaiter().GetResult();
        }

        public T CreateTransaction<T>(NetworkCoin networkCoin,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, Fee fee)
            where T : CreateBtcTransactionResponse, new()
        {
            return CreateTransactionAsync<T>(CancellationToken.None, networkCoin, inputAddresses, outputAddresses, fee).GetAwaiter().GetResult();
        }

        public T CreateTransaction<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, double value, string password)
            where T : CreateEthTransactionResponse, new()
        {
            return CreateTransactionAsync<T>(CancellationToken.None, networkCoin,
                fromAddress, toAddress, value, password).GetAwaiter().GetResult();
        }

        public T CreateTransaction<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, double value, string password, double gasPrice, double gasLimit)
            where T : CreateEthTransactionResponse, new()
        {
            return CreateTransactionAsync<T>(CancellationToken.None, networkCoin,
                fromAddress, toAddress, value, password, gasPrice, gasLimit).GetAwaiter().GetResult();
        }

        public T CreateTransaction<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string privateKey, double value)
            where T : CreateEthTransactionResponse, new()
        {
            return CreateTransactionAsync<T>(CancellationToken.None, networkCoin,
                fromAddress, toAddress, privateKey, value).GetAwaiter().GetResult();
        }

        public T CreateTransaction<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string privateKey, double value, double gasPrice, double gasLimit)
            where T : CreateEthTransactionResponse, new()
        {
            return CreateTransactionAsync<T>(CancellationToken.None, networkCoin,
                fromAddress, toAddress, privateKey, value, gasPrice, gasLimit).GetAwaiter().GetResult();
        }

        public T SendAllAmountUsingPassword<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string password)
            where T : CreateEthTransactionResponse, new()
        {
            return SendAllAmountUsingPasswordAsync<T>(CancellationToken.None, networkCoin,
                fromAddress, toAddress, password).GetAwaiter().GetResult();
        }

        public T SendAllAmountUsingPrivateKey<T>(
            NetworkCoin networkCoin, string fromAddress, string toAddress, string privateKey)
            where T : CreateEthTransactionResponse, new()
        {
            return SendAllAmountUsingPrivateKeyAsync<T>(CancellationToken.None, networkCoin,
                fromAddress, toAddress, privateKey).GetAwaiter().GetResult();
        }

        // todo: need unit-tests
        public T SignTransaction<T>(NetworkCoin networkCoin, string hexEncodedInfo, IEnumerable<string> wifs)
            where T : SignBtcTransactionResponse, new()
        {
            return SignTransactionAsync<T>(CancellationToken.None, networkCoin, hexEncodedInfo, wifs).GetAwaiter().GetResult();
        }

        public T SendTransaction<T>(NetworkCoin networkCoin, string hexEncodedInfo)
            where T : SendBtcTransactionResponse, new()
        {
            return SendTransactionAsync<T>(CancellationToken.None, networkCoin, hexEncodedInfo).GetAwaiter().GetResult();
        }

        public T LocallySignTransaction<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, double value)
            where T : LocallySignTransactionResponse, new()
        {
            return LocallySignTransactionAsync<T>(CancellationToken.None, networkCoin, fromAddress, toAddress, value).GetAwaiter().GetResult();
        }

        public T NewTransaction<T>(NetworkCoin networkCoin,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, Fee fee,
            IEnumerable<string> wifs)
            where T : NewBtcTransactionResponse, new()
        {
            return NewTransactionAsync<T>(CancellationToken.None, networkCoin, inputAddresses, outputAddresses, fee, wifs).GetAwaiter().GetResult();
        }

        public T NewHdTransaction<T>(NetworkCoin networkCoin, string wallet,
            string password, IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses,
            Fee fee, long lockTime = 0)
            where T : NewBtcTransactionResponse, new()
        {
            return NewHdTransactionAsync<T>(CancellationToken.None, networkCoin, wallet, password,
                inputAddresses, outputAddresses, fee, lockTime).GetAwaiter().GetResult();
        }

        public T PushTransaction<T>(NetworkCoin networkCoin, string hexEncodedInfo)
            where T : PushTransactionResponse, new()
        {
            return PushTransactionAsync<T>(CancellationToken.None, networkCoin, hexEncodedInfo).GetAwaiter().GetResult();
        }

        public T EstimateTransactionGas<T>(NetworkCoin networkCoin,
            string fromAddress, string toAddress, double value, string data = null)
            where T : EstimateTransactionGasResponse, new()
        {
            return EstimateTransactionGasAsync<T>(CancellationToken.None, networkCoin,
                fromAddress, toAddress, value, data).GetAwaiter().GetResult();
        }

        public T PendingTransactions<T>(NetworkCoin networkCoin)
            where T : PendingTransactionsResponse, new()
        {
            return PendingTransactionsAsync<T>(CancellationToken.None, networkCoin).GetAwaiter().GetResult();
        }

        public T QueuedTransactions<T>(NetworkCoin networkCoin)
            where T : QueuedTransactionsResponse, new()
        {
            return QueuedTransactionsAsync<T>(CancellationToken.None, networkCoin).GetAwaiter().GetResult();
        }

        public T TransactionsFee<T>(NetworkCoin networkCoin)
            where T : TransactionsFeeResponse, new()
        {
            return TransactionsFeeAsync<T>(CancellationToken.None, networkCoin).GetAwaiter().GetResult();
        }

        public T GetInternalTransactions<T>(NetworkCoin networkCoin, string transactionHash) 
            where T : GetInternalTransactionsResponse, new()
        {
            return GetInternalTransactionsAsync<T>(CancellationToken.None, networkCoin, transactionHash).GetAwaiter().GetResult();
        }

        public T RefundTransaction<T>(NetworkCoin networkCoin, string transactionId, string wif, double? fee = null) 
            where T : RefundTransactionResponse, new()
        {
            return RefundTransactionAsync<T>(CancellationToken.None, networkCoin, transactionId, wif, fee).GetAwaiter().GetResult();
        }

        public T RefundTransactionUsingPrivateKey<T>(NetworkCoin networkCoin, string transactionHash, string privateKey,
            double? gasPrice = null) where T : RefundTransactionResponse, new()
        {
            return RefundTransactionUsingPrivateKeyAsync<T>(
                CancellationToken.None, networkCoin, transactionHash, privateKey, gasPrice).GetAwaiter().GetResult();
        }

        public T RefundTransactionUsingPassword<T>(NetworkCoin networkCoin, string transactionHash, string password,
            double? gasPrice = null) where T : RefundTransactionResponse, new()
        {
            return RefundTransactionUsingPasswordAsync<T>(
                CancellationToken.None, networkCoin, transactionHash, password, gasPrice).GetAwaiter().GetResult();
        }
    }
}