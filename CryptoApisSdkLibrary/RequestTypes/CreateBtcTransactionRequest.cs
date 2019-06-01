using CryptoApisSdkLibrary.DataTypes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoApisSdkLibrary.RequestTypes
{
    internal class CreateBtcTransactionRequest
    {
        public CreateBtcTransactionRequest(IEnumerable<TransactionAddress> inputs, IEnumerable<TransactionAddress> outputs, Fee fee)
        {
            foreach (var input in inputs)
            {
                Inputs.Add(new TransactionItem(input.Address, input.Value));
            }
            foreach (var output in outputs)
            {
                Outputs.Add(new TransactionItem(output.Address, output.Value));
            }
            Fee = new FeeRequest(fee.Value, fee.Address);
        }

        [JsonProperty(PropertyName = "inputs")]
        public List<TransactionItem> Inputs { get; } = new List<TransactionItem>();

        [JsonProperty(PropertyName = "outputs")]
        public List<TransactionItem> Outputs { get; } = new List<TransactionItem>();

        [JsonProperty(PropertyName = "fee")]
        public FeeRequest Fee { get; }
    }

    internal class FeeRequest
    {
        public FeeRequest(double value, string address)
        {
            Value = value;
            Address = address;
        }

        [JsonProperty(PropertyName = "value")]
        public double Value { get; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; }
    }

    internal class TransactionItem
    {
        public TransactionItem(string address, double value)
        {
            Address = address;
            Value = value;
        }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; }

        [JsonProperty(PropertyName = "value")]
        public double Value { get; }
    }
}