using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Transactions
{
    internal partial class BlockchainTransactionModule
    {
        public BtcTransactionInfoResponse GetInfo(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string transactionId)
        {
            var request = Requests.GetInfo(coin, network, transactionId);
            return GetSync<BtcTransactionInfoResponse>(request);
        }

        public EthTransactionInfoResponse GetInfo(EthSimilarCoin coin, EthSimilarNetwork network,
            string blockHash, int transactionIndex)
        {
            var request = Requests.GetInfo(coin, network, blockHash, transactionIndex);
            return GetSync<EthTransactionInfoResponse>(request);
        }

        public EthTransactionInfoResponse GetInfo(EthSimilarCoin coin, EthSimilarNetwork network,
            int blockHeight, int transactionIndex)
        {
            var request = Requests.GetInfo(coin, network, blockHeight, transactionIndex);
            return GetSync<EthTransactionInfoResponse>(request);
        }

        public EthTransactionInfoResponse GetInfo(EthSimilarCoin coin, EthSimilarNetwork network,
            string transactionHash)
        {
            var request = Requests.GetInfo(coin, network, transactionHash);
            return GetSync<EthTransactionInfoResponse>(request);
        }

        public GetBtcTransactionInfosResponse GetInfos(BtcSimilarCoin coin, BtcSimilarNetwork network,
            int blockHeight, int skip = 0, int limit = 50)
        {
            var request = Requests.GetInfos(coin, network, blockHeight, skip, limit);
            return GetSync<GetBtcTransactionInfosResponse>(request);
        }

        public GetBtcTransactionInfosResponse GetInfos(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string blockHash, int skip = 0, int limit = 50)
        {
            var request = Requests.GetInfos(coin, network, blockHash, skip, limit);
            return GetSync<GetBtcTransactionInfosResponse>(request);
        }

        public GetEthTransactionInfosResponse GetInfos(EthSimilarCoin coin, EthSimilarNetwork network,
            int blockHeight, int skip = 0, int limit = 50)
        {
            var request = Requests.GetInfos(coin, network, blockHeight, skip, limit);
            var result = GetSync<GetEthTransactionInfosResponse>(request);
            result.Transactions?.Sort((info1, info2) => info1.Index.CompareTo(info2.Index));

            return result;
        }

        public GetUnconfirmedTransactionsResponse GetUnconfirmedTransactions(BtcSimilarCoin coin, BtcSimilarNetwork network,
            int skip = 0, int limit = 50)
        {
            var request = Requests.GetUnconfirmedTransactions(coin, network, skip, limit);
            return GetSync<GetUnconfirmedTransactionsResponse>(request);
        }

        public NewBtcTransactionResponse NewTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, Fee fee,
            IEnumerable<string> wifs)
        {
            var request = Requests.NewTransaction(coin, network, inputAddresses, outputAddresses, fee, wifs);
            return GetSync<NewBtcTransactionResponse>(request);
        }

        public NewBtcTransactionResponse NewHdTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, string wallet,
            string password, IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses,
            Fee fee, long lockTime = 0)
        {
            var request = Requests.NewHdTransaction(coin, network, wallet, password,
                inputAddresses, outputAddresses, fee, lockTime);
            return GetSync<NewBtcTransactionResponse>(request);
        }

        public CreateBtcTransactionResponse CreateTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, Fee fee)
        {
            var request = Requests.CreateTransaction(coin, network, inputAddresses, outputAddresses, fee);
            return GetSync<CreateBtcTransactionResponse>(request);
        }

        public CreateEthTransactionResponse CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string password)
        {
            var request = Requests.CreateTransaction(coin, network, fromAddress, toAddress, value, password);
            return GetSync<CreateEthTransactionResponse>(request);
        }

        public CreateEthTransactionResponse CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string password, double gasPrice, double gasLimit)
        {
            var request = Requests.CreateTransaction(coin, network, fromAddress, toAddress, value, password, gasPrice, gasLimit);
            return GetSync<CreateEthTransactionResponse>(request);
        }

        public CreateEthTransactionResponse SendAllAmountUsingPassword(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string password)
        {
            var request = Requests.SendAllAmountUsingPassword(coin, network, fromAddress, toAddress, password);
            return GetSync<CreateEthTransactionResponse>(request);
        }

        public CreateEthTransactionResponse SendAllAmountUsingPrivateKey(
            EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress, string privateKey)
        {
            var request = Requests.SendAllAmountUsingPrivateKey(coin, network, fromAddress, toAddress, privateKey);
            return GetSync<CreateEthTransactionResponse>(request);
        }

        // todo: need unit-tests
        public SignBtcTransactionResponse SignTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, string hexEncodedInfo,
            IEnumerable<string> wifs)
        {
            var request = Requests.SignTransaction(coin, network, hexEncodedInfo, wifs);
            return GetSync<SignBtcTransactionResponse>(request);
        }

        public CreateEthTransactionResponse CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string privateKey, double value)
        {
            var request = Requests.CreateTransaction(coin, network, fromAddress, toAddress, privateKey, value);
            return GetSync<CreateEthTransactionResponse>(request);
        }

        public CreateEthTransactionResponse CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string privateKey, double value, double gasPrice, double gasLimit)
        {
            var request = Requests.CreateTransaction(coin, network, fromAddress, toAddress, privateKey, value, gasPrice, gasLimit);
            return GetSync<CreateEthTransactionResponse>(request);
        }

        public SendBtcTransactionResponse SendTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, string hexEncodedInfo)
        {
            var request = Requests.SendTransaction(coin, network, hexEncodedInfo);
            return GetSync<SendBtcTransactionResponse>(request);
        }

        public LocallySignTransactionResponse LocallySignTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value)
        {
            var request = Requests.LocallySignTransaction(coin, network, fromAddress, toAddress, value);
            return GetSync<LocallySignTransactionResponse>(request);
        }

        public PushTransactionResponse PushTransaction(EthSimilarCoin coin, EthSimilarNetwork network, string hexEncodedInfo)
        {
            var request = Requests.PushTransaction(coin, network, hexEncodedInfo);
            return GetSync<PushTransactionResponse>(request);
        }

        public EstimateTransactionGasResponse EstimateTransactionGas(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string data = null)
        {
            var request = Requests.EstimateTransactionGas(coin, network, fromAddress, toAddress, value, data);
            return GetSync<EstimateTransactionGasResponse>(request);
        }

        public PendingTransactionsResponse PendingTransactions(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.PendingTransactions(coin, network);
            return GetSync<PendingTransactionsResponse>(request);
        }

        public QueuedTransactionsResponse QueuedTransactions(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.QueuedTransactions(coin, network);
            return GetSync<QueuedTransactionsResponse>(request);
        }

        public BtcTransactionsFeeResponse TransactionsFee(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Requests.TransactionsFee(coin, network);
            return GetSync<BtcTransactionsFeeResponse>(request);
        }

        public EthTransactionsFeeResponse TransactionsFee(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Requests.TransactionsFee(coin, network);
            return GetSync<EthTransactionsFeeResponse>(request);
        }

        public BtcDecodeTransactionResponse DecodeTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, string hexEncodedInfo)
        {
            var request = Requests.DecodeTransaction(coin, network, hexEncodedInfo);
            return GetSync<BtcDecodeTransactionResponse>(request);
        }
    }
}