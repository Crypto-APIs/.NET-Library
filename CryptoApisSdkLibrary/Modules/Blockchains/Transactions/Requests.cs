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

        public IRestRequest GetInfo(NetworkCoin networkCoin, string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
                throw new ArgumentNullException(nameof(transactionId));

            return Request.Get($"{Consts.Blockchain}/{networkCoin}/txs/txid/{transactionId}");
        }

        public IRestRequest GetInfoByBlockHash(NetworkCoin networkCoin, string blockHash)
        {
            if (string.IsNullOrEmpty(blockHash))
                throw new ArgumentNullException(nameof(blockHash));

            return Request.Get($"{Consts.Blockchain}/{networkCoin}/txs/hash/{blockHash}");
        }

        public IRestRequest GetInfo(NetworkCoin networkCoin, string blockHash, int transactionIndex)
        {
            if (string.IsNullOrEmpty(blockHash))
                throw new ArgumentNullException(nameof(blockHash));
            if (transactionIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(transactionIndex), transactionIndex, "TransactionIndex is negative");

            return Request.Get($"{Consts.Blockchain}/{networkCoin}/txs/block/{blockHash}/{transactionIndex}");
        }

        public IRestRequest GetInfo(NetworkCoin networkCoin, int blockHeight, int transactionIndex)
        {
            if (blockHeight < 0)
                throw new ArgumentOutOfRangeException(nameof(blockHeight), blockHeight, "BlockHeight is negative");
            if (transactionIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(transactionIndex), transactionIndex, "TransactionIndex is negative");

            return Request.Get($"{Consts.Blockchain}/{networkCoin}/txs/block/{blockHeight}/{transactionIndex}");
        }

        public IRestRequest GetInfos(NetworkCoin networkCoin, int blockHeight, int skip, int limit)
        {
            if (blockHeight < 0)
                throw new ArgumentOutOfRangeException(nameof(blockHeight), blockHeight, "BlockHeight is negative");
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.Blockchain}/{networkCoin}/txs/block/{blockHeight}");
            request.AddQueryParameter("index", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest GetInfos(NetworkCoin networkCoin, string blockHash, int skip, int limit)
        {
            if (string.IsNullOrEmpty(blockHash))
                throw new ArgumentOutOfRangeException(nameof(blockHash), blockHash, "BlockHash is null or empty");
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.Blockchain}/{networkCoin}/txs/block/{blockHash}");
            request.AddQueryParameter("index", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest GetUnconfirmedTransactions(NetworkCoin networkCoin, int skip, int limit)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.Blockchain}/{networkCoin}/txs/unconfirmed");
            request.AddQueryParameter("index", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());

            return request;
        }

        public IRestRequest NewTransaction(NetworkCoin networkCoin,
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

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/txs/new",
                new NewBtcTransactionRequest(inputs, outputs, fee, wifsArray));
        }

        public IRestRequest NewHdTransaction(NetworkCoin networkCoin, string wallet,
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

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/txs/new",
                new NewHdBtcTransactionRequest(wallet, password, inputs, outputs, fee, lockTime));
        }

        public IRestRequest CreateTransaction(NetworkCoin networkCoin,
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

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/txs/create",
                new CreateBtcTransactionRequest(inputs, outputs, fee));
        }

        public IRestRequest CreateTransaction(NetworkCoin networkCoin,
            string fromAddress, string toAddress, double value, string password)
        {
            return InternalCreateTransaction(networkCoin,
                new CreateEthTransactionUsingPasswordRequest(fromAddress, toAddress, value, password));
        }

        public IRestRequest CreateTransaction(NetworkCoin networkCoin,
            string fromAddress, string toAddress, double value, string password, double gasPrice, double gasLimit)
        {
            return InternalCreateTransaction(networkCoin,
                new CreateEthTransactionUsingPasswordAndGasRequest(fromAddress, toAddress, value, password, gasPrice, gasLimit));
        }

        public IRestRequest SendAllAmountUsingPassword(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string password)
        {
            if (string.IsNullOrEmpty(fromAddress))
                throw new ArgumentNullException(nameof(fromAddress));
            if (string.IsNullOrEmpty(toAddress))
                throw new ArgumentNullException(nameof(toAddress));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/txs/new/all",
                new CreateEthTransactionAllAmountUsingPasswordRequest(fromAddress, toAddress, password));
        }

        public IRestRequest SendAllAmountUsingPrivateKey(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string privateKey)
        {
            if (string.IsNullOrEmpty(fromAddress))
                throw new ArgumentNullException(nameof(fromAddress));
            if (string.IsNullOrEmpty(toAddress))
                throw new ArgumentNullException(nameof(toAddress));
            if (string.IsNullOrEmpty(privateKey))
                throw new ArgumentNullException(nameof(privateKey));

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/txs/new-pvtkey/all",
                new CreateEthTransactionAllAmountUsingPrivateKeyRequest(fromAddress, toAddress, privateKey));
        }

        // todo: need unit-tests
        public IRestRequest SignTransaction(NetworkCoin networkCoin, string hexEncodedInfo, IEnumerable<string> wifs)
        {
            if (string.IsNullOrEmpty(hexEncodedInfo))
                throw new ArgumentNullException(nameof(hexEncodedInfo));
            if (wifs == null || wifs.Any())
                throw new ArgumentNullException(nameof(wifs));

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/txs/sign",
                new SignTransactionRequest(hexEncodedInfo, wifs));
        }

        public IRestRequest CreateTransaction(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string privateKey, double value)
        {
            return InternalCreateTransaction(networkCoin,
                new CreateEthTransactionUsingPrivateKeyRequest(fromAddress, toAddress, value, privateKey));
        }

        public IRestRequest CreateTransaction(NetworkCoin networkCoin,
            string fromAddress, string toAddress, string privateKey, double value, double gasPrice, double gasLimit)
        {
            return InternalCreateTransaction(networkCoin,
                new CreateEthTransactionUsingPrivateKeyAndGasRequest(fromAddress, toAddress, value, privateKey, gasPrice, gasLimit));
        }

        public IRestRequest SendTransaction(NetworkCoin networkCoin, string hexEncodedInfo)
        {
            if (string.IsNullOrEmpty(hexEncodedInfo))
                throw new ArgumentNullException(nameof(hexEncodedInfo));

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/txs/send",
                new SendBtcTransactionRequest(hexEncodedInfo));
        }

        public IRestRequest LocallySignTransaction(NetworkCoin networkCoin,
            string fromAddress, string toAddress, double value)
        {
            if (string.IsNullOrEmpty(fromAddress))
                throw new ArgumentNullException(nameof(fromAddress));
            if (string.IsNullOrEmpty(toAddress))
                throw new ArgumentNullException(nameof(toAddress));
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Value is negative or zero");

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/txs/send",
                new SendEthTransactionRequest(fromAddress, toAddress, value));
        }

        public IRestRequest PushTransaction(NetworkCoin networkCoin, string hexEncodedInfo)
        {
            if (string.IsNullOrEmpty(hexEncodedInfo))
                throw new ArgumentNullException(nameof(hexEncodedInfo));

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/txs/push",
                new PushTransactionRequest(hexEncodedInfo));
        }

        public IRestRequest EstimateTransactionGas(NetworkCoin networkCoin,
            string fromAddress, string toAddress, double value, string data)
        {
            if (string.IsNullOrEmpty(fromAddress))
                throw new ArgumentNullException(nameof(fromAddress));
            if (string.IsNullOrEmpty(toAddress))
                throw new ArgumentNullException(nameof(toAddress));
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Value is negative or zero");

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/txs/gas",
                new EstimateTransactionRequest(fromAddress, toAddress, value, data));
        }

        public IRestRequest PendingTransactions(NetworkCoin networkCoin)
        {
            return Request.Get($"{Consts.Blockchain}/{networkCoin}/txs/pending");
        }

        public IRestRequest QueuedTransactions(NetworkCoin networkCoin)
        {
            return Request.Get($"{Consts.Blockchain}/{networkCoin}/txs/queued");
        }

        public IRestRequest TransactionsFee(NetworkCoin networkCoin)
        {
            return Request.Get($"{Consts.Blockchain}/{networkCoin}/txs/fee");
        }

        public IRestRequest DecodeTransaction(NetworkCoin networkCoin, string hexEncodedInfo)
        {
            if (string.IsNullOrEmpty(hexEncodedInfo))
                throw new ArgumentNullException(nameof(hexEncodedInfo));

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/txs/decode",
                new DecodeTransactionRequest(hexEncodedInfo));
        }

        private IRestRequest InternalCreateTransaction(NetworkCoin networkCoin,
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

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/txs/new", request);
        }

        private IRestRequest InternalCreateTransaction(NetworkCoin networkCoin,
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

            return Request.Post($"{Consts.Blockchain}/{networkCoin}/txs/new-pvtkey", request);
        }

        private CryptoApiRequest Request { get; }
    }
}