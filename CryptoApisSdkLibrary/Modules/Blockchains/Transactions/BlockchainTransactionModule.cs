using CryptoApisSdkLibrary.DataTypes;
using CryptoApisSdkLibrary.Misc;
using CryptoApisSdkLibrary.RequestTypes;
using CryptoApisSdkLibrary.ResponseTypes.Blockchains;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoApisSdkLibrary.Modules.Blockchains.Transactions
{
    internal class BlockchainTransactionModule : BaseModule, IBlockchainTransactionModule
    {
        public BlockchainTransactionModule(IRestClient client, CryptoApiRequest request) : base(client, request)
        {
        }

        public BtcTransactionInfoResponse GetInfo(BtcSimilarCoin coin, BtcSimilarNetwork network, string transactionId)
        {
            if (string.IsNullOrEmpty(transactionId))
                throw new ArgumentNullException(nameof(transactionId));

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/txid/{transactionId}");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<BtcTransactionInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<BtcTransactionInfoResponse>(response);
        }

        public EthTransactionInfoResponse GetInfo(
            EthSimilarCoin coin, EthSimilarNetwork network, string blockHash, int transactionIndex)
        {
            if (string.IsNullOrEmpty(blockHash))
                throw new ArgumentNullException(nameof(blockHash));
            if (transactionIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(transactionIndex), transactionIndex, "TransactionIndex is negative");

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/block/{blockHash}/{transactionIndex}");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<EthTransactionInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<EthTransactionInfoResponse>(response);
        }

        public EthTransactionInfoResponse GetInfo(
            EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight, int transactionIndex)
        {
            if (blockHeight < 0)
                throw new ArgumentOutOfRangeException(nameof(blockHeight), blockHeight, "BlockHeight is negative");
            if (transactionIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(transactionIndex), transactionIndex, "TransactionIndex is negative");

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/block/{blockHeight}/{transactionIndex}");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<EthTransactionInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<EthTransactionInfoResponse>(response);
        }

        public EthTransactionInfoResponse GetInfo(EthSimilarCoin coin, EthSimilarNetwork network, string transactionHash)
        {
            if (string.IsNullOrEmpty(transactionHash))
                throw new ArgumentNullException(nameof(transactionHash));

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/hash/{transactionHash}");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<EthTransactionInfoResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<EthTransactionInfoResponse>(response);
        }

        public GetBtcTransactionInfosResponse GetInfos(
            BtcSimilarCoin coin, BtcSimilarNetwork network, int blockHeight, int skip = 0, int limit = 50)
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
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetBtcTransactionInfosResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetBtcTransactionInfosResponse>(response);
        }

        public GetBtcTransactionInfosResponse GetInfos(BtcSimilarCoin coin, BtcSimilarNetwork network,
            string blockHash, int skip = 0, int limit = 50)
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
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetBtcTransactionInfosResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetBtcTransactionInfosResponse>(response);
        }

        public GetEthTransactionInfosResponse GetInfos(
            EthSimilarCoin coin, EthSimilarNetwork network, int blockHeight, int skip = 0, int limit = 50)
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
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetEthTransactionInfosResponse>(response);
                var data = responseObject.Data;
                data.Transactions.Sort((info1, info2) => info1.Index.CompareTo(info2.Index));
                return data;
            }
            return MakeErrorMessage<GetEthTransactionInfosResponse>(response);
        }

        public GetUnconfirmedTransactionsResponse GetUnconfirmedTransactions(BtcSimilarCoin coin, BtcSimilarNetwork network,
            int skip = 0, int limit = 50)
        {
            if (skip < 0)
                throw new ArgumentOutOfRangeException(nameof(skip), skip, "Skip is negative");
            if (limit <= 0)
                throw new ArgumentOutOfRangeException(nameof(limit), limit, "Limit is negative or zero");

            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/unconfirmed");
            request.AddQueryParameter("index", skip.ToString());
            request.AddQueryParameter("limit", limit.ToString());
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<GetUnconfirmedTransactionsResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<GetUnconfirmedTransactionsResponse>(response);
        }

        public NewBtcTransactionResponse NewTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network,
            IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, Fee fee,
            IEnumerable<string> wifs)
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

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/new",
                new NewBtcTransactionRequest(inputs, outputs, fee, wifsArray));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<NewBtcTransactionResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<NewBtcTransactionResponse>(response);
        }

        public NewBtcTransactionResponse NewHdTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, string wallet,
            string password, IEnumerable<TransactionAddress> inputAddresses, IEnumerable<TransactionAddress> outputAddresses, 
            Fee fee, long lockTime = 0)
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

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/new",
                new NewHdBtcTransactionRequest(wallet, password, inputs, outputs, fee, lockTime));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<NewBtcTransactionResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<NewBtcTransactionResponse>(response);
        }

        public CreateBtcTransactionResponse CreateTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network,
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

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/create",
                new CreateBtcTransactionRequest(inputs, outputs, fee));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateBtcTransactionResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateBtcTransactionResponse>(response);
        }

        public CreateEthTransactionResponse CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string password)
        {
            return InternalCreateTransaction(coin, network,
                new CreateEthTransactionUsingPasswordRequest(fromAddress, toAddress, value, password));
        }

        public CreateEthTransactionResponse CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string password, double gasPrice, double gasLimit)
        {
            return InternalCreateTransaction(coin, network,
                new CreateEthTransactionUsingPasswordAndGasRequest(fromAddress, toAddress, value, password, gasPrice, gasLimit));
        }

        public CreateEthTransactionResponse SendAllAmountUsingPassword(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string password)
        {
            if (string.IsNullOrEmpty(fromAddress))
                throw new ArgumentNullException(nameof(fromAddress));
            if (string.IsNullOrEmpty(toAddress))
                throw new ArgumentNullException(nameof(toAddress));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/new/all",
                new CreateEthTransactionAllAmountUsingPasswordRequest(fromAddress, toAddress, password));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateEthTransactionResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateEthTransactionResponse>(response);
        }

        public CreateEthTransactionResponse SendAllAmountUsingPrivateKey(
            EthSimilarCoin coin, EthSimilarNetwork network, string fromAddress, string toAddress, string privateKey)
        {
            if (string.IsNullOrEmpty(fromAddress))
                throw new ArgumentNullException(nameof(fromAddress));
            if (string.IsNullOrEmpty(toAddress))
                throw new ArgumentNullException(nameof(toAddress));
            if (string.IsNullOrEmpty(privateKey))
                throw new ArgumentNullException(nameof(privateKey));

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/new-pvtkey/all",
                new CreateEthTransactionAllAmountUsingPrivateKeyRequest(fromAddress, toAddress, privateKey));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateEthTransactionResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateEthTransactionResponse>(response);
        }

        // todo: need unit-tests
        public SignBtcTransactionResponse SignTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, string hexEncodedInfo,
            IEnumerable<string> wifs)
        {
            if (string.IsNullOrEmpty(hexEncodedInfo))
                throw new ArgumentNullException(nameof(hexEncodedInfo));
            if (wifs == null || wifs.Any())
                throw new ArgumentNullException(nameof(wifs));

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/sign",
                new SignTransactionRequest(hexEncodedInfo, wifs));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<SignBtcTransactionResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<SignBtcTransactionResponse>(response);
        }

        public CreateEthTransactionResponse CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string privateKey, double value)
        {
            return InternalCreateTransaction(coin, network,
                new CreateEthTransactionUsingPrivateKeyRequest(fromAddress, toAddress, value, privateKey));
        }

        public CreateEthTransactionResponse CreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, string privateKey, double value, double gasPrice, double gasLimit)
        {
            return InternalCreateTransaction(coin, network,
                new CreateEthTransactionUsingPrivateKeyAndGasRequest(fromAddress, toAddress, value, privateKey, gasPrice, gasLimit));
        }

        public SendBtcTransactionResponse SendTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, string hexEncodedInfo)
        {
            if (string.IsNullOrEmpty(hexEncodedInfo))
                throw new ArgumentNullException(nameof(hexEncodedInfo));

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/send",
                new SendBtcTransactionRequest(hexEncodedInfo));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<SendBtcTransactionResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<SendBtcTransactionResponse>(response);
        }

        public LocallySignTransactionResponse LocallySignTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value)
        {
            if (string.IsNullOrEmpty(fromAddress))
                throw new ArgumentNullException(nameof(fromAddress));
            if (string.IsNullOrEmpty(toAddress))
                throw new ArgumentNullException(nameof(toAddress));
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Value is negative or zero");

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/send",
                new SendEthTransactionRequest(fromAddress, toAddress, value));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<LocallySignTransactionResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<LocallySignTransactionResponse>(response);
        }

        public PushTransactionResponse PushTransaction(EthSimilarCoin coin, EthSimilarNetwork network, string hexEncodedInfo)
        {
            if (string.IsNullOrEmpty(hexEncodedInfo))
                throw new ArgumentNullException(nameof(hexEncodedInfo));

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/push",
                new PushTransactionRequest(hexEncodedInfo));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<PushTransactionResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<PushTransactionResponse>(response);
        }

        public EstimateTransactionGasResponse EstimateTransactionGas(EthSimilarCoin coin, EthSimilarNetwork network,
            string fromAddress, string toAddress, double value, string data = null)
        {
            if (string.IsNullOrEmpty(fromAddress))
                throw new ArgumentNullException(nameof(fromAddress));
            if (string.IsNullOrEmpty(toAddress))
                throw new ArgumentNullException(nameof(toAddress));
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Value is negative or zero");

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/gas",
                new EstimateTransactionRequest(fromAddress, toAddress, value, data));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<EstimateTransactionGasResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<EstimateTransactionGasResponse>(response);
        }

        public PendingTransactionsResponse PendingTransactions(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/pending");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<PendingTransactionsResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<PendingTransactionsResponse>(response);
        }

        public QueuedTransactionsResponse QueuedTransactions(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/queued");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<QueuedTransactionsResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<QueuedTransactionsResponse>(response);
        }

        public BtcTransactionsFeeResponse TransactionsFee(BtcSimilarCoin coin, BtcSimilarNetwork network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/fee");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<BtcTransactionsFeeResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<BtcTransactionsFeeResponse>(response);
        }

        public EthTransactionsFeeResponse TransactionsFee(EthSimilarCoin coin, EthSimilarNetwork network)
        {
            var request = Request.Get($"{Consts.Blockchain}/{coin}/{network}/txs/fee");
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<EthTransactionsFeeResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<EthTransactionsFeeResponse>(response);
        }

        public BtcDecodeTransactionResponse DecodeTransaction(BtcSimilarCoin coin, BtcSimilarNetwork network, string hexEncodedInfo)
        {
            if (string.IsNullOrEmpty(hexEncodedInfo))
                throw new ArgumentNullException(nameof(hexEncodedInfo));

            var request = Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/decode",
                new DecodeTransactionRequest(hexEncodedInfo));
            var response = Client.Execute(request);

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<BtcDecodeTransactionResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<BtcDecodeTransactionResponse>(response);
        }

        private CreateEthTransactionResponse InternalCreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
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

            var response = Client.Execute(Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/new", request));

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateEthTransactionResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateEthTransactionResponse>(response);
        }

        private CreateEthTransactionResponse InternalCreateTransaction(EthSimilarCoin coin, EthSimilarNetwork network,
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

            var response = Client.Execute(Request.Post($"{Consts.Blockchain}/{coin}/{network}/txs/new-pvtkey", request));

            if (response.IsSuccessful)
            {
                var responseObject = Client.Deserialize<CreateEthTransactionResponse>(response);
                return responseObject.Data;
            }
            return MakeErrorMessage<CreateEthTransactionResponse>(response);
        }
    }
}