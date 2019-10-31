using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Blockchains;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisLibrary.Modules.Blockchains.Transactions
{
    internal partial class BlockchainTransactionModule
    {
        public Task<T> GetInfoAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string transactionId)
            where T : BtcTransactionInfoResponse, new()
        {
            var request = Requests.GetInfo(networkCoin, transactionId);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetInfoByTransactionHashAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string transactionHash)
            where T : EthTransactionInfoResponse, new()
        {
            var request = Requests.GetInfoByTransactionHash(networkCoin, transactionHash);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetInfoAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string blockHash, int transactionIndex)
            where T : EthTransactionInfoResponse, new()
        {
            var request = Requests.GetInfo(networkCoin, blockHash, transactionIndex);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetInfoAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, int blockHeight, int transactionIndex)
            where T : EthTransactionInfoResponse, new()
        {
            var request = Requests.GetInfo(networkCoin, blockHeight, transactionIndex);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetInfosAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, int blockHeight, int skip = 0, int limit = 50)
            where T : GetTransactionInfosResponse, new()
        {
            var request = Requests.GetInfos(networkCoin, blockHeight, skip, limit);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetInfosAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string blockHash, int skip = 0, int limit = 50)
            where T : GetBtcTransactionInfosResponse, new()
        {
            var request = Requests.GetInfos(networkCoin, blockHash, skip, limit);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetUnconfirmedTransactionsAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, int skip = 0, int limit = 50)
            where T : GetUnconfirmedTransactionsResponse, new()
        {
            var request = Requests.GetUnconfirmedTransactions(networkCoin, skip, limit);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> DecodeTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string hexEncodedInfo)
            where T : BtcDecodeTransactionResponse, new()
        {
            var request = Requests.DecodeTransaction(networkCoin, hexEncodedInfo);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> CreateTransactionAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, Fee fee)
            where T : CreateBtcTransactionResponse, new()
        {
            var request = Requests.CreateTransaction(networkCoin, inputAddresses, outputAddresses, fee);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> CreateTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress, double value, string password)
            where T : CreateEthTransactionResponse, new()
        {
            var request = Requests.CreateTransaction(networkCoin, fromAddress, toAddress, value, password);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> CreateTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress,
            double value, string password, double gasPrice, double gasLimit)
            where T : CreateEthTransactionResponse, new()
        {
            var request = Requests.CreateTransaction(networkCoin, fromAddress, toAddress, value, password, gasPrice, gasLimit);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> CreateTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress, string privateKey, double value)
            where T : CreateEthTransactionResponse, new()
        {
            var request = Requests.CreateTransaction(networkCoin, fromAddress, toAddress, privateKey, value);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> CreateTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress,
            string privateKey, double value, double gasPrice, double gasLimit)
            where T : CreateEthTransactionResponse, new()
        {
            var request = Requests.CreateTransaction(networkCoin, fromAddress, toAddress, privateKey, value, gasPrice, gasLimit);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> SendAllAmountUsingPasswordAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress, string password)
            where T : CreateEthTransactionResponse, new()
        {
            var request = Requests.SendAllAmountUsingPassword(networkCoin, fromAddress, toAddress, password);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> SendAllAmountUsingPrivateKeyAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress, string privateKey)
            where T : CreateEthTransactionResponse, new()
        {
            var request = Requests.SendAllAmountUsingPrivateKey(networkCoin, fromAddress, toAddress, privateKey);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> SignTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string hexEncodedInfo, IEnumerable<string> wifs)
            where T : SignBtcTransactionResponse, new()
        {
            var request = Requests.SignTransaction(networkCoin, hexEncodedInfo, wifs);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> SendTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string hexEncodedInfo)
            where T : SendBtcTransactionResponse, new()
        {
            var request = Requests.SendTransaction(networkCoin, hexEncodedInfo);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> LocallySignTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress, double value)
            where T : LocallySignTransactionResponse, new()
        {
            var request = Requests.LocallySignTransaction(networkCoin, fromAddress, toAddress, value);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> NewTransactionAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses,
            Fee fee, IEnumerable<string> wifs)
            where T : NewBtcTransactionResponse, new()
        {
            var request = Requests.NewTransaction(networkCoin, inputAddresses, outputAddresses, fee, wifs);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> NewHdTransactionAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            string wallet, string password, IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses,
            Fee fee, long lockTime = 0)
            where T : NewBtcTransactionResponse, new()
        {
            var request = Requests.NewHdTransaction(networkCoin, wallet, password, inputAddresses, outputAddresses, fee, lockTime);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> PushTransactionAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string hexEncodedInfo)
            where T : PushTransactionResponse, new()
        {
            var request = Requests.PushTransaction(networkCoin, hexEncodedInfo);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> EstimateTransactionGasAsync<T>(CancellationToken cancellationToken,
            NetworkCoin networkCoin, string fromAddress, string toAddress, double value, string data = null)
            where T : EstimateTransactionGasResponse, new()
        {
            var request = Requests.EstimateTransactionGas(networkCoin, fromAddress, toAddress, value, data);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> PendingTransactionsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : PendingTransactionsResponse, new()
        {
            var request = Requests.PendingTransactions(networkCoin);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> QueuedTransactionsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : QueuedTransactionsResponse, new()
        {
            var request = Requests.QueuedTransactions(networkCoin);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> TransactionsFeeAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin)
            where T : TransactionsFeeResponse, new()
        {
            var request = Requests.TransactionsFee(networkCoin);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> GetInternalTransactionsAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            string transactionHash) where T : GetInternalTransactionsResponse, new()
        {
            var request = Requests.GetInternalTransactions(networkCoin, transactionHash);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> RefundTransactionAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin, string transactionId,
            string wif, double? fee = null) where T : RefundTransactionResponse, new()
        {
            var request = Requests.RefundTransaction(networkCoin, transactionId, wif, fee);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> RefundTransactionUsingPrivateKeyAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            string transactionHash, string privateKey, double? gasPrice = null) where T : RefundTransactionResponse, new()
        {
            var request = Requests.RefundTransactionUsingPrivateKey(networkCoin, transactionHash, privateKey, gasPrice);
            return GetAsyncResponse<T>(request, cancellationToken);
        }

        public Task<T> RefundTransactionUsingPasswordAsync<T>(CancellationToken cancellationToken, NetworkCoin networkCoin,
            string transactionHash, string password, double? gasPrice = null) where T : RefundTransactionResponse, new()
        {
            var request = Requests.RefundTransactionUsingPassword(networkCoin, transactionHash, password, gasPrice);
            return GetAsyncResponse<T>(request, cancellationToken);
        }
    }
}