using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Transactions
{
    internal partial class BlockchainTransactionModule
    {
        public Task<BtcTransactionInfoResponse> GetInfoAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string transactionId)
        {
            var request = Requests.GetInfo(coin, network, transactionId);
            return GetAsyncResponse<BtcTransactionInfoResponse>(request, cancellationToken);
        }

        public Task<EthTransactionInfoResponse> GetInfoAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string transactionHash)
        {
            var request = Requests.GetInfo(coin, network, transactionHash);
            return GetAsyncResponse<EthTransactionInfoResponse>(request, cancellationToken);
        }

        public Task<EthTransactionInfoResponse> GetInfoAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string blockHash, int transactionIndex)
        {
            var request = Requests.GetInfo(coin, network, blockHash, transactionIndex);
            return GetAsyncResponse<EthTransactionInfoResponse>(request, cancellationToken);
        }

        public Task<EthTransactionInfoResponse> GetInfoAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight, int transactionIndex)
        {
            var request = Requests.GetInfo(coin, network, blockHeight, transactionIndex);
            return GetAsyncResponse<EthTransactionInfoResponse>(request, cancellationToken);
        }

        public Task<GetBtcTransactionInfosResponse> GetInfosAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, int blockHeight, int skip = 0, int limit = 50)
        {
            var request = Requests.GetInfos(coin, network, blockHeight, skip, limit);
            return GetAsyncResponse<GetBtcTransactionInfosResponse>(request, cancellationToken);
        }

        public Task<GetBtcTransactionInfosResponse> GetInfosAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string blockHash, int skip = 0, int limit = 50)
        {
            var request = Requests.GetInfos(coin, network, blockHash, skip, limit);
            return GetAsyncResponse<GetBtcTransactionInfosResponse>(request, cancellationToken);
        }

        public Task<GetEthTransactionInfosResponse> GetInfosAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight, int skip = 0, int limit = 50)
        {
            var request = Requests.GetInfos(coin, network, blockHeight, skip, limit);
            return GetAsyncResponse<GetEthTransactionInfosResponse>(request, cancellationToken);
        }

        public Task<GetUnconfirmedTransactionsResponse> GetUnconfirmedTransactionsAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, int skip = 0, int limit = 50)
        {
            var request = Requests.GetUnconfirmedTransactions(coin, network, skip, limit);
            return GetAsyncResponse<GetUnconfirmedTransactionsResponse>(request, cancellationToken);
        }

        public Task<BtcDecodeTransactionResponse> DecodeTransactionAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string hexEncodedInfo)
        {
            var request = Requests.DecodeTransaction(coin, network, hexEncodedInfo);
            return GetAsyncResponse<BtcDecodeTransactionResponse>(request, cancellationToken);
        }

        public Task<CreateBtcTransactionResponse> CreateTransactionAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, Fee fee)
        {
            var request = Requests.CreateTransaction(coin, network, inputAddresses, outputAddresses, fee);
            return GetAsyncResponse<CreateBtcTransactionResponse>(request, cancellationToken);
        }

        public Task<CreateEthTransactionResponse> CreateTransactionAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string password)
        {
            var request = Requests.CreateTransaction(coin, network, fromAddress, toAddress, value, password);
            return GetAsyncResponse<CreateEthTransactionResponse>(request, cancellationToken);
        }

        public Task<CreateEthTransactionResponse> CreateTransactionAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress,
            double value, string password, double gasPrice, double gasLimit)
        {
            var request = Requests.CreateTransaction(coin, network, fromAddress, toAddress, value, password, gasPrice, gasLimit);
            return GetAsyncResponse<CreateEthTransactionResponse>(request, cancellationToken);
        }

        public Task<CreateEthTransactionResponse> CreateTransactionAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress,
            string privateKey, double value)
        {
            var request = Requests.CreateTransaction(coin, network, fromAddress, toAddress, privateKey, value);
            return GetAsyncResponse<CreateEthTransactionResponse>(request, cancellationToken);
        }

        public Task<CreateEthTransactionResponse> CreateTransactionAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress,
            string privateKey, double value, double gasPrice, double gasLimit)
        {
            var request = Requests.CreateTransaction(coin, network, fromAddress, toAddress, privateKey, value, gasPrice, gasLimit);
            return GetAsyncResponse<CreateEthTransactionResponse>(request, cancellationToken);
        }

        public Task<CreateEthTransactionResponse> SendAllAmountUsingPasswordAsync(CancellationToken cancellationToken, EthSimilarCoin coin,
            EthSimilarNetwork network, string fromAddress, string toAddress, string password)
        {
            var request = Requests.SendAllAmountUsingPassword(coin, network, fromAddress, toAddress, password);
            return GetAsyncResponse<CreateEthTransactionResponse>(request, cancellationToken);
        }

        public Task<CreateEthTransactionResponse> SendAllAmountUsingPrivateKeyAsync(CancellationToken cancellationToken, EthSimilarCoin coin,
            EthSimilarNetwork network, string fromAddress, string toAddress, string privateKey)
        {
            var request = Requests.SendAllAmountUsingPrivateKey(coin, network, fromAddress, toAddress, privateKey);
            return GetAsyncResponse<CreateEthTransactionResponse>(request, cancellationToken);
        }

        public Task<SignBtcTransactionResponse> SignTransactionAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string hexEncodedInfo, IEnumerable<string> wifs)
        {
            var request = Requests.SignTransaction(coin, network, hexEncodedInfo, wifs);
            return GetAsyncResponse<SignBtcTransactionResponse>(request, cancellationToken);
        }

        public Task<SendBtcTransactionResponse> SendTransactionAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network, string hexEncodedInfo)
        {
            var request = Requests.SendTransaction(coin, network, hexEncodedInfo);
            return GetAsyncResponse<SendBtcTransactionResponse>(request, cancellationToken);
        }

        public Task<LocallySignTransactionResponse> LocallySignTransactionAsync(CancellationToken cancellationToken, EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value)
        {
            var request = Requests.LocallySignTransaction(coin, network, fromAddress, toAddress, value);
            return GetAsyncResponse<LocallySignTransactionResponse>(request, cancellationToken);
        }

        public Task<NewBtcTransactionResponse> NewTransactionAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses,
            Fee fee, IEnumerable<string> wifs)
        {
            var request = Requests.NewTransaction(coin, network, inputAddresses, outputAddresses, fee, wifs);
            return GetAsyncResponse<NewBtcTransactionResponse>(request, cancellationToken);
        }

        public Task<NewBtcTransactionResponse> NewHdTransactionAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network,
            string wallet, string password, IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses,
            Fee fee, long lockTime = 0)
        {
            var request = Requests.NewHdTransaction(coin, network, wallet, password, inputAddresses, outputAddresses, fee, lockTime);
            return GetAsyncResponse<NewBtcTransactionResponse>(request, cancellationToken);
        }

        public Task<PushTransactionResponse> PushTransactionAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network, string hexEncodedInfo)
        {
            var request = Requests.PushTransaction(coin, network, hexEncodedInfo);
            return GetAsyncResponse<PushTransactionResponse>(request, cancellationToken);
        }

        public Task<EstimateTransactionGasResponse> EstimateTransactionGasAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string data = null)
        {
            var request = Requests.EstimateTransactionGas(coin, network, fromAddress, toAddress, value, data);
            return GetAsyncResponse<EstimateTransactionGasResponse>(request, cancellationToken);
        }

        public Task<PendingTransactionsResponse> PendingTransactionsAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.PendingTransactions(coin, network);
            return GetAsyncResponse<PendingTransactionsResponse>(request, cancellationToken);
        }

        public Task<QueuedTransactionsResponse> QueuedTransactionsAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.QueuedTransactions(coin, network);
            return GetAsyncResponse<QueuedTransactionsResponse>(request, cancellationToken);
        }

        public Task<BtcTransactionsFeeResponse> TransactionsFeeAsync(CancellationToken cancellationToken,
            BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.TransactionsFee(coin, network);
            return GetAsyncResponse<BtcTransactionsFeeResponse>(request, cancellationToken);
        }

        public Task<EthTransactionsFeeResponse> TransactionsFeeAsync(CancellationToken cancellationToken,
            EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.TransactionsFee(coin, network);
            return GetAsyncResponse<EthTransactionsFeeResponse>(request, cancellationToken);
        }
    }
}