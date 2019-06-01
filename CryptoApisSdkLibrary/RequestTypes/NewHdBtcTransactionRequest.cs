using CryptoApisSdkLibrary.DataTypes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal class NewHdBtcTransactionRequest
    {
        public NewHdBtcTransactionRequest(string walletName, string password,
            IEnumerable<TransactionAddress> inputs, IEnumerable<TransactionAddress> outputs, Fee fee, long locktime)
        {
            foreach (var input in inputs)
            {
                Inputs.Add(new TransactionItem(input.Address, input.Value));
            }

            foreach (var output in outputs)
            {
                Outputs.Add(new TransactionItem(output.Address, output.Value));
            }

            WalletName = walletName;
            Password = password;
            Fee = new FeeRequest(fee.Value, fee.Address);
            Locktime = locktime;
        }

        [JsonProperty(PropertyName = "walletName")]
        public string WalletName { get; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; }

        [JsonProperty(PropertyName = "inputs")]
        public List<TransactionItem> Inputs { get; } = new List<TransactionItem>();

        [JsonProperty(PropertyName = "outputs")]
        public List<TransactionItem> Outputs { get; } = new List<TransactionItem>();

        [JsonProperty(PropertyName = "fee")]
        public FeeRequest Fee { get; }

        [JsonProperty(PropertyName = "locktime")]
        public long Locktime { get; }
    }
}