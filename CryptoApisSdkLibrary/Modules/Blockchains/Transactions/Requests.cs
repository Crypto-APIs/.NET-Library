using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.RequestTypes;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Transactions
{
    internal class Requests
    {
        public Requests(CryptoApiRequest request)
        {
            Request = request;
        }

        public IRestRequest GetInfo(BtcSimilarCoin coin, BtcSimilarNetwork network, string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
                throw new ArgumentNullException(nameof(transactionId));

            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/txid/{transactionId}");
        }

        public IRestRequest GetInfo(EthSimilarCoin coin, EthSimilarNetwork network,
            string blockHash, int transactionIndex)
        {
            if (string.IsNullOrEmpty(blockHash))
                throw new ArgumentNullException(nameof(blockHash));
            if (transactionIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(transactionIndex), transactionIndex, "TransactionIndex is negative");

            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/block/{blockHash}/{transactionIndex}");
        }

        public IRestRequest GetInfo(EthSimilarCoin coin, EthSimilarNetwork network,
            int blockHeight, int transactionIndex)
        {
            if (blockHeight < 0)
                throw new ArgumentOutOfRangeException(nameof(blockHeight), blockHeight, "BlockHeight is negative");
            if (transactionIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(transactionIndex), transactionIndex, "TransactionIndex is negative");

            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/block/{blockHeight}/{transactionIndex}");
        }

        public IRestRequest GetInfo(EthSimilarCoin coin, EthSimilarNetwork network, string transactionHash)
        {
            if (string.IsNullOrEmpty(transactionHash))
                throw new ArgumentNullException(nameof(transactionHash));

            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/hash/{transactionHash}");
        }

        public IRestRequest GetInfos(BtcSimilarCoin coin, BtcSimilarNetwork network,
            int blockHeight, int skip, int limit)
        {
            if (blockHeight < 0)
                throw new ArgumentOutOfRangeException(nameof(blockHeight), blockHeight, "BlockHeight is negative");
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/block/{blockHeight}");
            request.AddQueryParameter("index", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest GetInfos(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string blockHash, int skip, int limit)
        {
            if (string.IsNullOrEmpty(blockHash))
                throw new ArgumentOutOfRangeException(nameof(blockHash), blockHash, "BlockHash is null or empty");
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/block/{blockHash}");
            request.AddQueryParameter("index", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest GetInfos(EthSimilarCoin coin, EthSimilarNetwork network,
            int blockHeight, int skip, int limit)
        {
            if (blockHeight < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "BlockHeight is negative");
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/block/{blockHeight}");
            request.AddQueryParameter("index", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest GetUnconfirmedTransactions(BtcSimilarCoin coin, BtcSimilarNetwork network,
            int skip, int limit)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/unconfirmed");
            request.AddQueryParameter("index", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest NewTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses,
            Fee fee, IEnumerable<string> wifs)
        {
            if (inputAddresses == null)
                throw new ArgumentNullException(nameof(inputAddresses));
            if (outputAddresses == null)
                throw new ArgumentNullException(nameof(outputAddresses));
            if (fee == null)
                throw new ArgumentNullException(nameof(fee));
            if (wifs == null)
                throw new ArgumentNullException(nameof(wifs));

            var inputs = inputAddresses as TransactionAddress[] ?? inputAddresses.ToArray();
            if (!inputs.Any())
                throw new ArgumentNullException(nameof(inputAddresses), "InputAddresses is empty");

            var outputs = outputAddresses as TransactionAddress[] ?? outputAddresses.ToArray();
            if (!outputs.Any())
                throw new ArgumentNullException(nameof(outputAddresses), "OutputAddresses is empty");

            var wifsArray = wifs as string[] ?? wifs.ToArray();
            if (!wifsArray.Any())
                throw new ArgumentNullException(nameof(wifs), "Wifs is empty");

            if (fee.Value < 0)
                throw new ArgumentOutOfRangeException(nameof(fee), fee, "Fee is negative");

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/new",
                new NewBtcTransactionRequest(inputs, outputs, fee, wifsArray));
        }

        public IRestRequest NewHdTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, string wallet,
            string password, IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses,
            Fee fee, long lockTime)
        {
            if (string.IsNullOrEmpty(wallet))
                throw new ArgumentNullException(nameof(wallet));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));
            if (inputAddresses == null)
                throw new ArgumentNullException(nameof(inputAddresses));
            if (outputAddresses == null)
                throw new ArgumentNullException(nameof(outputAddresses));
            if (fee == null)
                throw new ArgumentNullException(nameof(fee));

            var inputs = inputAddresses as TransactionAddress[] ?? inputAddresses.ToArray();
            if (!inputs.Any())
                throw new ArgumentNullException(nameof(inputAddresses), "InputAddresses is empty");

            var outputs = outputAddresses as TransactionAddress[] ?? outputAddresses.ToArray();
            if (!outputs.Any())
                throw new ArgumentNullException(nameof(outputAddresses), "OutputAddresses is empty");

            if (fee.Value < 0)
                throw new ArgumentOutOfRangeException(nameof(fee), fee, "Fee is negative");

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/new",
                new NewHdBtcTransactionRequest(wallet, password, inputs, outputs, fee, lockTime));
        }

        public IRestRequest CreateTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, Fee fee)
        {
            if (inputAddresses == null)
                throw new ArgumentNullException(nameof(inputAddresses));
            if (outputAddresses == null)
                throw new ArgumentNullException(nameof(outputAddresses));
            if (fee == null)
                throw new ArgumentNullException(nameof(fee));

            var inputs = inputAddresses as TransactionAddress[] ?? inputAddresses.ToArray();
            if (!inputs.Any())
                throw new ArgumentNullException(nameof(inputAddresses), "InputAddresses is empty");

            var outputs = outputAddresses as TransactionAddress[] ?? outputAddresses.ToArray();
            if (!outputs.Any())
                throw new ArgumentNullException(nameof(outputAddresses), "OutputAddresses is empty");

            if (fee.Value < 0)
                throw new ArgumentOutOfRangeException(nameof(fee), fee, "Fee is negative");

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/create",
                new CreateBtcTransactionRequest(inputs, outputs, fee));
        }

        public IRestRequest CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string password)
        {
            return InternalCreateTransaction(coin, network,
                new CreateEthTransactionUsingPasswordRequest(fromAddress, toAddress, value, password));
        }

        public IRestRequest CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string password, double gasPrice, double gasLimit)
        {
            return InternalCreateTransaction(coin, network,
                new CreateEthTransactionUsingPasswordAndGasRequest(fromAddress, toAddress, value, password, gasPrice, gasLimit));
        }

        public IRestRequest SendAllAmountUsingPassword(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string password)
        {
            if (string.IsNullOrEmpty(fromAddress))
                throw new ArgumentNullException(nameof(fromAddress));
            if (string.IsNullOrEmpty(toAddress))
                throw new ArgumentNullException(nameof(toAddress));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/new/all",
                new CreateEthTransactionAllAmountUsingPasswordRequest(fromAddress, toAddress, password));
        }

        public IRestRequest SendAllAmountUsingPrivateKey(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string privateKey)
        {
            if (string.IsNullOrEmpty(fromAddress))
                throw new ArgumentNullException(nameof(fromAddress));
            if (string.IsNullOrEmpty(toAddress))
                throw new ArgumentNullException(nameof(toAddress));
            if (string.IsNullOrEmpty(privateKey))
                throw new ArgumentNullException(nameof(privateKey));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/new-pvtkey/all",
                new CreateEthTransactionAllAmountUsingPrivateKeyRequest(fromAddress, toAddress, privateKey));
        }

        // todo: need unit-tests
        public IRestRequest SignTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string hexEncodedInfo, IEnumerable<string> wifs)
        {
            if (string.IsNullOrEmpty(hexEncodedInfo))
                throw new ArgumentNullException(nameof(hexEncodedInfo));
            if (wifs == null || wifs.Any())
                throw new ArgumentNullException(nameof(wifs));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/sign",
                new SignTransactionRequest(hexEncodedInfo, wifs));
        }

        public IRestRequest CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string privateKey, double value)
        {
            return InternalCreateTransaction(coin, network,
                new CreateEthTransactionUsingPrivateKeyRequest(fromAddress, toAddress, value, privateKey));
        }

        public IRestRequest CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string privateKey, double value, double gasPrice, double gasLimit)
        {
            return InternalCreateTransaction(coin, network,
                new CreateEthTransactionUsingPrivateKeyAndGasRequest(fromAddress, toAddress, value, privateKey, gasPrice, gasLimit));
        }

        public IRestRequest SendTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, string hexEncodedInfo)
        {
            if (string.IsNullOrEmpty(hexEncodedInfo))
                throw new ArgumentNullException(nameof(hexEncodedInfo));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/send",
                new SendBtcTransactionRequest(hexEncodedInfo));
        }

        public IRestRequest LocallySignTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value)
        {
            if (string.IsNullOrEmpty(fromAddress))
                throw new ArgumentNullException(nameof(fromAddress));
            if (string.IsNullOrEmpty(toAddress))
                throw new ArgumentNullException(nameof(toAddress));
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Value is negative or zero");

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/send",
                new SendEthTransactionRequest(fromAddress, toAddress, value));
        }

        public IRestRequest PushTransaction(EthSimilarCoin coin, EthSimilarNetwork network, string hexEncodedInfo)
        {
            if (string.IsNullOrEmpty(hexEncodedInfo))
                throw new ArgumentNullException(nameof(hexEncodedInfo));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/push",
                new PushTransactionRequest(hexEncodedInfo));
        }

        public IRestRequest EstimateTransactionGas(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string data)
        {
            if (string.IsNullOrEmpty(fromAddress))
                throw new ArgumentNullException(nameof(fromAddress));
            if (string.IsNullOrEmpty(toAddress))
                throw new ArgumentNullException(nameof(toAddress));
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Value is negative or zero");

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/gas",
                new EstimateTransactionRequest(fromAddress, toAddress, value, data));
        }

        public IRestRequest PendingTransactions(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/pending");
        }

        public IRestRequest QueuedTransactions(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/queued");
        }

        public IRestRequest TransactionsFee(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/fee");
        }

        public IRestRequest TransactionsFee(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            return Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/fee");
        }

        public IRestRequest DecodeTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, string hexEncodedInfo)
        {
            if (string.IsNullOrEmpty(hexEncodedInfo))
                throw new ArgumentNullException(nameof(hexEncodedInfo));

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/decode",
                new DecodeTransactionRequest(hexEncodedInfo));
        }

        private IRestRequest InternalCreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            CreateEthTransactionUsingPasswordRequest request)
        {
            if (string.IsNullOrEmpty(request.FromAddress))
                throw new ArgumentNullException(nameof(request.FromAddress));
            if (string.IsNullOrEmpty(request.ToAddress))
                throw new ArgumentNullException(nameof(request.ToAddress));
            if (string.IsNullOrEmpty(request.Password))
                throw new ArgumentNullException(nameof(request.Password));
            if (request.Value <= 0)
                throw new ArgumentOutOfRangeException(nameof(request.Value), request.Value, "Value is negative or zero");

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/new", request);
        }

        private IRestRequest InternalCreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            CreateEthTransactionUsingPrivateKeyRequest request)
        {
            if (string.IsNullOrEmpty(request.FromAddress))
                throw new ArgumentNullException(nameof(request.FromAddress));
            if (string.IsNullOrEmpty(request.ToAddress))
                throw new ArgumentNullException(nameof(request.ToAddress));
            if (string.IsNullOrEmpty(request.PrivateKey))
                throw new ArgumentNullException(nameof(request.PrivateKey));
            if (request.Value <= 0)
                throw new ArgumentOutOfRangeException(nameof(request.Value), request.Value, "Value is negative or zero");

            return Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/new-pvtkey", request);
        }

        private CryptoApiRequest Request { get; }
    }
}